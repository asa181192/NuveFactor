Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Linq

Namespace EncryptString

  Public Enum ciphertype
    oldschool = 1
    newschool = 2
  End Enum

  Public NotInheritable Class Cipher

    Private Const Keysize As Integer = 256
    Private Const DerivationIterations As Integer = 1000

    Public Shared Property hayerr As Boolean
    Public Shared Property err As Exception

    Public Shared Function Encrypt(ByVal spath As String, ByVal passPhrase As String, Optional ByVal mode As ciphertype = ciphertype.oldschool) As String
      Dim password As Rfc2898DeriveBytes = Nothing
      Dim plainText As String = ""
      Dim sReturn As String = ""

      Try
        EncryptString.Cipher.hayerr = False
        EncryptString.Cipher.err = Nothing

        Dim buff = System.IO.File.ReadAllBytes(spath)
        Dim sbuff = buff.Select(Function(s) s.ToString).ToList
        plainText = String.Join(",", sbuff)

        If mode = ciphertype.oldschool Then
          sReturn = System.IO.File.ReadAllText(spath, System.Text.Encoding.Default)

        ElseIf mode = ciphertype.newschool Then

          Dim plainTextBytes = Encoding.UTF8.GetBytes(plainText)

          Dim saltStringBytes = Generate256BitsOfRandomEntropy()
          Dim ivStringBytes = Generate256BitsOfRandomEntropy()

          password = New Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations)
          Dim keyBytes = password.GetBytes(Keysize / 8)

          Using symmetricKey = New RijndaelManaged()
            symmetricKey.BlockSize = 256
            symmetricKey.Mode = CipherMode.CBC
            symmetricKey.Padding = PaddingMode.PKCS7
            Using encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes)
              Using memoryStream = New MemoryStream()
                Using cryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
                  cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
                  cryptoStream.FlushFinalBlock()
                  Dim cipherTextBytes = saltStringBytes
                  cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray()
                  cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray()
                  memoryStream.Close()
                  cryptoStream.Close()
                  sReturn = Convert.ToBase64String(cipherTextBytes)
                End Using
              End Using
            End Using
          End Using

        End If
      Catch ex As Exception
        EncryptString.Cipher.hayerr = True
        EncryptString.Cipher.err = ex
        sReturn = ""
      Finally
        If password IsNot Nothing Then password = Nothing
      End Try

      Return sReturn
    End Function

    Public Shared Function Decrypt(ByVal cipherText As String, ByVal passPhrase As String, Optional ByVal mode As ciphertype = ciphertype.oldschool) As Byte()
      Dim result As Byte() = Nothing
      Dim sReturn As String = ""
      Dim password As Rfc2898DeriveBytes = Nothing

      Try
        EncryptString.Cipher.hayerr = False
        EncryptString.Cipher.err = Nothing

        If mode = ciphertype.oldschool Then
          Dim sfile = IO.Path.GetTempFileName
          System.IO.File.WriteAllText(sfile, cipherText, System.Text.Encoding.Default)
          result = System.IO.File.ReadAllBytes(sfile)
          If IO.File.Exists(sfile) Then IO.File.Delete(sfile)

        ElseIf mode = ciphertype.newschool Then

          Dim cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText)
          Dim saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray()
          Dim ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray()
          Dim cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray()

          password = New Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations)
          Dim keyBytes = password.GetBytes(Keysize / 8)

          Using symmetricKey = New RijndaelManaged()
            symmetricKey.BlockSize = 256
            symmetricKey.Mode = CipherMode.CBC
            symmetricKey.Padding = PaddingMode.PKCS7
            Using decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes)
              Using memoryStream = New MemoryStream(cipherTextBytes)
                Using cryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
                  Dim plainTextBytes = New Byte(cipherTextBytes.Length - 1) {}
                  Dim decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
                  memoryStream.Close()
                  cryptoStream.Close()
                  sReturn = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
                End Using
              End Using
            End Using
          End Using

          result = sReturn.Split(",").Select(Function(s) Convert.ToByte(s.Trim)).ToArray

        End If

      Catch ex As Exception
        EncryptString.Cipher.hayerr = True
        EncryptString.Cipher.err = ex
      Finally
        If password IsNot Nothing Then password = Nothing
      End Try

      Return result
    End Function

    Private Shared Function Generate256BitsOfRandomEntropy() As Byte()
      Dim randomBytes = New Byte(31) {}
      Dim rngCsp = New RNGCryptoServiceProvider()
      rngCsp.GetBytes(randomBytes)
      If rngCsp IsNot Nothing Then rngCsp = Nothing
      Return randomBytes
    End Function

  End Class

End Namespace