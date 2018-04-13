Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports DataLayer
Imports Negocio.Validaciones
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json

Public Module Metodos

#Region "CONSTANTES"
  Public Const gnDecimals As Integer = 2
  Public Const gcCurrText As String = "PESOS"
  Public Cientos() As String = {"CERO", _
                                "CIENTO", _
                                "DOSCIENTOS", _
                                "TRESCIENTOS", _
                                "CUATROCIENTOS", _
                                "QUINIENTOS", _
                                "SEISCIENTOS", _
                                "SETECIENTOS", _
                                "OCHOCIENTOS", _
                                "NOVECIENTOS"}

  Public Decenas() As String = {"CERO", _
                                "UN", _
                                "DOS", _
                                "TRES", _
                                "CUATRO", _
                                "CINCO", _
                                "SEIS", _
                                "SIETE", _
                                "OCHO", _
                                "NUEVE", _
                                "DIEZ", _
                                "ONCE", _
                                "DOCE", _
                                "TRECE", _
                                "CATORCE", _
                                "QUINCE", _
                                "DIECISEIS", _
                                "DIECISIETE", _
                                "DIECIOCHO", _
                                "DIECINUEVE", _
                                "VEINTE", _
                                "VEINTIUN", _
                                "VEINTIDOS", _
                                "VEINTITRES", _
                                "VEINTICUATRO", _
                                "VEINTICINCO", _
                                "VEINTISEIS", _
                                "VEINTISIETE", _
                                "VEINTIOCHO", _
                                "VEINTINUEVE", _
                                "TREINTA", _
                                "TREINTA Y UN", _
                                "TREINTA Y DOS", _
                                "TREINTA Y TRES", _
                                "TREINTA Y CUATRO", _
                                "TREINTA Y CINCO", _
                                "TREINTA Y SEIS", _
                                "TREINTA Y SIETE", _
                                "TREINTA Y OCHO", _
                                "TREINTA Y NUEVE", _
                                "CUARENTA", _
                                "CUARENTA Y UN", _
                                "CUARENTA Y DOS", _
                                "CUARENTA Y TRES", _
                                "CUARENTA Y CUATRO", _
                                "CUARENTA Y CINCO", _
                                "CUARENTA Y SEIS", _
                                "CUARENTA Y SIETE", _
                                "CUARENTA Y OCHO", _
                                "CUARENTA Y NUEVE", _
                                "CINCUENTA", _
                                "CINCUENTA Y UN", _
                                "CINCUENTA Y DOS", _
                                "CINCUENTA Y TRES", _
                                "CINCUENTA Y CUATRO", _
                                "CINCUENTA Y CINCO", _
                                "CINCUENTA Y SEIS", _
                                "CINCUENTA Y SIETE", _
                                "CINCUENTA Y OCHO", _
                                "CINCUENTA Y NUEVE", _
                                "SESENTA", _
                                "SESENTA Y UN", _
                                "SESENTA Y DOS", _
                                "SESENTA Y TRES", _
                                "SESENTA Y CUATRO", _
                                "SESENTA Y CINCO", _
                                "SESENTA Y SEIS", _
                                "SESENTA Y SIETE", _
                                "SESENTA Y OCHO", _
                                "SESENTA Y NUEVE", _
                                "SETENTA", _
                                "SETENTA Y UN", _
                                "SETENTA Y DOS", _
                                "SETENTA Y TRES", _
                                "SETENTA Y CUATRO", _
                                "SETENTA Y CINCO", _
                                "SETENTA Y SEIS", _
                                "SETENTA Y SIETE", _
                                "SETENTA Y OCHO", _
                                "SETENTA Y NUEVE", _
                                "OCHENTA", _
                                "OCHENTA Y UN", _
                                "OCHENTA Y DOS", _
                                "OCHENTA Y TRES", _
                                "OCHENTA Y CUATRO", _
                                "OCHENTA Y CINCO", _
                                "OCHENTA Y SEIS", _
                                "OCHENTA Y SIETE", _
                                "OCHENTA Y OCHO", _
                                "OCHENTA Y NUEVE", _
                                "NOVENTA", _
                                "NOVENTA Y UN", _
                                "NOVENTA Y DOS", _
                                "NOVENTA Y TRES", _
                                "NOVENTA Y CUATRO", _
                                "NOVENTA Y CINCO", _
                                "NOVENTA Y SEIS", _
                                "NOVENTA Y SIETE", _
                                "NOVENTA Y OCHO", _
                                "NOVENTA Y NUEVE"}
#End Region

#Region "  Validaciones "

  ''' <summary>
  ''' Valida una cadena
  ''' </summary>
  ''' <param name="indice">Indice u orden de aparición</param>
  ''' <param name="clase">Clase a validar</param>
  ''' <param name="campo">Property a validar</param>
  ''' <param name="ConNulo">Indica si acepta nulos</param>
  ''' <param name="conVacio">Indica si acepta vacios</param>
  ''' <param name="MaxLen">Longitud máxima</param>
  ''' <returns>Comentario</returns>
  ''' <remarks>Valida una cadena</remarks>
  Public Function ValidaCadena(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo, ByVal ConNulo As Boolean, ByVal conVacio As Boolean, ByVal MaxLen As Integer) As Comentario
    Dim oComentario As New Negocio.Validaciones.Comentario
    oComentario.Indice = indice
    oComentario.Campo = campo
    oComentario.Tipo = campo.PropertyType

    If ConNulo = True AndAlso campo.GetValue(clase) Is Nothing Then
      Return oComentario
    End If

    If campo.GetValue(clase) Is Nothing Then
      oComentario.Comentario = "El campo no puede estar vacio"
      Return oComentario
    End If

    If ((Not conVacio) AndAlso (campo.GetValue(clase) = "")) Then
      oComentario.Comentario = "El campo no puede estar vacio"
      Return oComentario
    End If

    If (MaxLen <> -1) AndAlso campo.GetValue(clase).ToString.Trim.Length > MaxLen Then
      oComentario.Comentario = String.Format("El campo no puede contener más de {0} caracteres", MaxLen)
      Return oComentario
    End If

    Return oComentario
  End Function

  ''' <summary>
  ''' Valida una fecha
  ''' </summary>
  ''' <param name="indice">Indice u orden de aparición</param>
  ''' <param name="clase">Clase a validar</param>
  ''' <param name="campo">Property a validar</param>
  ''' <param name="ConNulo">Indica si acepta nulos</param>
  ''' <returns>Comentario</returns>
  ''' <remarks>Valida una fecha</remarks>
  Public Function ValidaFecha(ByVal indice As Integer, ByVal clase As Object, ByVal campo As System.Reflection.PropertyInfo, ByVal ConNulo As Boolean) As Comentario
    Dim oComentario As New Comentario
    oComentario.Indice = indice
    oComentario.Campo = campo
    oComentario.Tipo = campo.PropertyType

    If ConNulo = True AndAlso campo.GetValue(clase) Is Nothing Then
      Return oComentario
    End If

    If campo.GetValue(clase) Is Nothing Then
      oComentario.Comentario = "Debe establecer un afecha"
      Return oComentario
    End If

    If campo.GetValue(clase) < New DateTime(1753, 1, 1, 0, 0, 0, 0) Then
      oComentario.Comentario = "Debe establecer una fecha valida"
      Return oComentario
    End If

    If campo.GetValue(clase) > New DateTime(9999, 12, 31, 23, 59, 59, 997) Then
      oComentario.Comentario = "Debe establecer una fecha valida"
      Return oComentario
    End If

    Return oComentario
  End Function

  ''' <summary>
  ''' Valida un booleano
  ''' </summary>
  ''' <param name="indice">Indice u orden de aparición</param>
  ''' <param name="clase">Clase a validar</param>
  ''' <param name="campo">Property a validar</param>
  ''' <param name="ConNulo">Indica si acepta nulos</param>
  ''' <returns>Comentario</returns>
  ''' <remarks>Valida un booleano</remarks>
  Public Function ValidaBoleano(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo, ByVal ConNulo As Boolean) As Comentario
    Dim oComentario As New Comentario
    oComentario.Indice = indice
    oComentario.Campo = campo
    oComentario.Tipo = campo.PropertyType

    If ConNulo = True AndAlso campo.GetValue(clase) Is Nothing Then
      Return oComentario
    End If

    If campo.GetValue(clase) Is Nothing Then
      oComentario.Comentario = "El campo no puede estar vacio"
      Return oComentario
    End If

    Return oComentario
  End Function

  ''' <summary>
  ''' Valida un número
  ''' </summary>
  ''' <param name="indice">Indice u orden de aparición</param>
  ''' <param name="clase">Clase a validar</param>
  ''' <param name="campo">Property a validar</param>
  ''' <param name="ConNulo">Indica si acepta nulos</param>
  ''' <param name="ConNegativo">Indica si acepta negativos</param>
  ''' <param name="MinVal">Valor minimo</param>
  ''' <param name="MaxVal">Valo máximo</param>
  ''' <returns>Comentario</returns>
  ''' <remarks>Valida un número</remarks>
  Public Function ValidaNumero(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo, ByVal ConNulo As Boolean, ByVal ConNegativo As Boolean, ByVal MinVal As Integer, ByVal MaxVal As Integer) As Comentario
    Dim oComentario As New Comentario
    oComentario.Indice = indice
    oComentario.Campo = campo
    oComentario.Tipo = campo.PropertyType

    If ConNulo = True AndAlso campo.GetValue(clase) Is Nothing Then
      Return oComentario
    End If

    If campo.GetValue(clase) Is Nothing Then
      oComentario.Comentario = "El campo no puede estar vacio"
      Return oComentario
    End If

    If Not ConNegativo AndAlso campo.GetValue(clase) < 0 Then
      oComentario.Comentario = "El campo no pemite negativos"
      Return oComentario
    End If

    If MinVal > -1 AndAlso campo.GetValue(clase) < MinVal Then
      oComentario.Comentario = String.Format("El valor del campo no puede se menor a {0}", MinVal)
      Return oComentario
    End If

    If MaxVal > -1 AndAlso campo.GetValue(clase) > MaxVal Then
      oComentario.Comentario = String.Format("El valor del campo no puede se mayor a {0}", MaxVal)
      Return oComentario
    End If

    Return oComentario
  End Function

  ''' <summary>
  ''' Valida un correo
  ''' </summary>
  ''' <param name="indice">Indice u orden de aparición</param>
  ''' <param name="clase">Clase a validar</param>
  ''' <param name="campo">Property a validar</param>
  ''' <param name="ConNulo">Indica si acepta nulos</param>
  ''' <returns>Comentario</returns>
  ''' <remarks>Valida un correo</remarks>
  Public Function ValidaCorreo(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo, ByVal ConNulo As Boolean) As Comentario
    Dim oComentario As New Comentario
    oComentario.Indice = indice
    oComentario.Campo = campo
    oComentario.Tipo = campo.PropertyType
    Dim rex As New RegularExpressions.Regex("^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$")

    If ConNulo = True AndAlso campo.GetValue(clase) Is Nothing Then
      Return oComentario
    End If

    If campo.GetValue(clase) Is Nothing Then
      oComentario.Comentario = "Debe establecer un correo"
      Return oComentario
    End If

    If campo.GetValue(clase).ToString.Trim.Length = 0 Then
      oComentario.Comentario = "Debe establecer un correo"
      Return oComentario
    End If

    If Not rex.IsMatch(campo.GetValue(clase).ToString().Trim().ToLower()) Then
      oComentario.Comentario = "El correo tiene un formato incorrecto"
      Return oComentario
    End If

    Return oComentario
  End Function

  ''' <summary>
  ''' Valida un curp
  ''' </summary>
  ''' <param name="indice">Indice u orden de aparición</param>
  ''' <param name="clase">Clase a validar</param>
  ''' <param name="campo">Property a validar</param>
  ''' <param name="ConNulo">Indica si acepta nulos</param>
  ''' <returns>Comentario</returns>
  ''' <remarks>Valida un curp</remarks>
  Public Function ValidaCURP(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo, ByVal ConNulo As Boolean) As Comentario
    Dim oComentario As New Comentario
    oComentario.Indice = indice
    oComentario.Campo = campo
    oComentario.Tipo = campo.PropertyType
    Dim rex As New RegularExpressions.Regex("^([A-Z][A,E,I,O,U,X][A-Z]{2})(\d{2})((01|03|05|07|08|10|12)(0[1-9]|[12]\d|3[01])|02(0[1-9]|[12]\d)|(04|06|09|11)(0[1-9]|[12]\d|30))([M,H])(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)([B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3})([0-9,A-Z][0-9])$")

    If ConNulo = True AndAlso campo.GetValue(clase) Is Nothing Then
      Return oComentario
    End If

    If campo.GetValue(clase) Is Nothing Then
      oComentario.Comentario = "Debe establecer la CURP"
      Return oComentario
    End If

    If campo.GetValue(clase).ToString.Trim.Length = 0 Then
      oComentario.Comentario = "Debe establecer la CURP"
      Return oComentario
    End If

    If Not rex.IsMatch(campo.GetValue(clase).ToString().Trim().ToUpper()) Then
      oComentario.Comentario = "La CURP tiene un formato incorrecto"
      Return oComentario
    End If

    Return oComentario
  End Function

  ''' <summary>
  ''' Valida un RFC
  ''' </summary>
  ''' <param name="indice">Indice u orden de aparición</param>
  ''' <param name="clase">Clase a validar</param>
  ''' <param name="campo">Property a validar</param>
  ''' <param name="pfisica">Indica si es persona física</param>
  ''' <param name="ConNulo">Indica si acepta nulos</param>
  ''' <returns>Comentario</returns>
  ''' <remarks>Valida un RFC</remarks>
  Public Function ValidaRFC(ByVal indice As Integer, ByVal clase As Object, ByVal campo As PropertyInfo, ByVal pfisica As Boolean, ByVal ConNulo As Boolean) As Comentario
    Dim oComentario As New Comentario
    oComentario.Indice = indice
    oComentario.Campo = campo
    oComentario.Tipo = campo.PropertyType
    Dim rex As New RegularExpressions.Regex("^([a-zñA-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([a-zA-Z\d]{3})?$")

    If ConNulo = True AndAlso campo.GetValue(clase) Is Nothing Then
      Return oComentario
    End If

    If campo.GetValue(clase) Is Nothing Then
      oComentario.Comentario = "Debe establecer un RFC"
      Return oComentario
    End If

    If campo.GetValue(clase).ToString.Trim.Length = 0 Then
      oComentario.Comentario = "Debe establecer un RFC"
      Return oComentario
    End If

    If pfisica = True Then
      Dim rfc As String = campo.GetValue(clase).ToString().Trim()

      If rfc.Length <> 13 Then
        oComentario.Comentario = "El RFC para personas físicas debe contener 13 caracteres"
        Return oComentario
      End If

      If Not IsNumeric(rfc.Substring(4, 6)) Then
        oComentario.Comentario = "El RFC tiene un formato incorrecto"
        Return oComentario
      End If

      If Not rex.IsMatch(rfc) Then
        oComentario.Comentario = "El RFC tiene un formato incorrecto"
        Return oComentario
      End If

    Else
      Dim rfc As String = campo.GetValue(clase).ToString().Trim()

      If rfc.Length <> 12 Then
        oComentario.Comentario = "El RFC para personas morales debe contener 12 caracteres"
        Return oComentario
      End If

      If Not IsNumeric(rfc.Substring(3, 6)) Then
        oComentario.Comentario = "El RFC tiene un formato incorrecto"
        Return oComentario
      End If

      If Not rex.IsMatch(rfc) Then
        oComentario.Comentario = "El RFC tiene un formato incorrecto"
        Return oComentario
      End If

    End If

    Return oComentario
  End Function
#End Region

#Region "  Metodos "
  ''' <summary>
  ''' Convierte List(Of Type) en DataTable
  ''' </summary>
  ''' <typeparam name="T">Type</typeparam>
  ''' <param name="data">List(of Type)</param>
  ''' <returns>DataTable</returns>
  ''' <remarks>Convierte List(Of Type) en DataTable</remarks>
  Public Function ConvertToDataTable(Of T)(data As IList(Of T)) As DataTable
    Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
    Dim table As New DataTable(GetType(T).Name)
    For Each prop As PropertyDescriptor In properties
      table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
    Next
    For Each item As T In data
      Dim row As DataRow = table.NewRow()
      For Each prop As PropertyDescriptor In properties
        row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
      Next
      table.Rows.Add(row)
    Next
    Return table
  End Function

  Public Sub aMayusculasSinAcentos(ByRef objeto As Object, ByVal campo As PropertyInfo)
    Dim sCadena = campo.GetValue(objeto)
    sCadena = sCadena.ToUpper()
    sCadena = sCadena.Replace("Á", "A")
    sCadena = sCadena.Replace("É", "E")
    sCadena = sCadena.Replace("Í", "I")
    sCadena = sCadena.Replace("Ó", "O")
    sCadena = sCadena.Replace("Ú", "U")
    campo.SetValue(objeto, sCadena)
  End Sub

  Public Sub aMinusculas(ByRef objeto As Object, ByVal campo As PropertyInfo)
    Dim sCadena = campo.GetValue(objeto)
    sCadena = sCadena.ToLower()
    campo.SetValue(objeto, sCadena)
  End Sub

  ''' <summary>
  ''' CALCULA LA TASA DE INTERES DANDO EL MONTO A FINANCIAR, EL PLAZO Y EL VALOR DE LOS PAGOS
  ''' </summary>
  ''' <param name="valorpresente">VALOR PRESENTE</param>
  ''' <param name="montoxpago">MONTO DE CADA PAGO PERIODICO</param>
  ''' <param name="plazo">NUMERO DE PERIODOS DE CAPITALIZACION</param>
  ''' <returns>DOUBLE</returns>
  ''' <remarks></remarks>
  Public Function INTEREST(ByVal valorpresente As Double, ByVal montoxpago As Double, ByVal plazo As Double) As Double
    If valorpresente = 0 Or montoxpago = 0 Or plazo = 0 Then
      Return 0
    Else
      Return Financial.Rate(plazo, montoxpago, valorpresente)
    End If
  End Function

  ''' <summary>
  ''' CALCULOS PARA LA CONVERSION DE TASA MENSUAL EFECTIVA A ANUAL EQUIVALENTE
  ''' </summary>
  ''' <param name="plazo">PLAZO EN MESES</param>
  ''' <param name="tasamensual">TASA DE INTERES MENSUAL</param>
  ''' <returns>DOUBLE</returns>
  ''' <remarks></remarks>
  Public Function ANNUAL_TAX(ByVal plazo As Integer, ByVal tasamensual As Double) As Double
    Return INTEREST(1, (1 / (plazo + tasamensual)), Convert.ToDouble(plazo))
  End Function

  ''' <summary>
  ''' CALCULA LA TASA MENSUAL PARTIENDO DE LA TASA MENSUAL EQUIVALENTE
  ''' </summary>
  ''' <param name="nPlazo">Plazo en meses</param>
  ''' <param name="nTasa_anual">Tasa de interes anual</param>
  ''' <returns>Double</returns>
  ''' <remarks></remarks>
  Public Function MONTH_TAX(ByVal nPlazo As Integer, nTasa_anual As Double) As Double
    Return (((nPlazo * Financial.Pmt(nTasa_anual / 12, nPlazo, 1) - 1) / nPlazo) * 100)
  End Function

  Public Function PAYMENT(ByVal financiado As Double, ByVal tasa As Double, ByVal plazo As Integer) As Double
    Return Math.Abs(Financial.Pmt(tasa, plazo, financiado))
  End Function

  Public Function S_MTP(ByVal valorseg As Decimal, ByVal pagofin As Decimal, ByVal plazofin As Integer, ByVal tasafin As Decimal, ByVal diasint As Integer, ByVal tasaiva As Decimal) As Decimal
    If plazofin <> 0 And pagofin <= plazofin Then
      Return (valorseg / plazofin) * (1 + (diasint * (tasafin / 360)) * (plazofin - pagofin + 1) * (1 + tasaiva))
    Else
      Return 0
    End If
  End Function

  ''' <summary>
  ''' GENERA CADENA CON ESTATUS PARA LOS CONTRATOS
  ''' </summary>
  ''' <param name="prm">OBJETO DE CUALQUIER TIPO QUE CUMPLA CON LOS CAMPOS QUE SE NECESITA PARA LA CARGA DEL ESTATUS</param>
  ''' <returns>String</returns>
  ''' <remarks></remarks>
  Public Function GETSTATUS(ByVal prm As Object) As String
    Dim status As String = ""
    status &= If(prm.fec_soli > New Date(1900, 1, 1, 0, 0, 0), "t", "_")     '' en trámite (solicitada la linea de crédito)
    status &= If(prm.fec_auto > New Date(1900, 1, 1, 0, 0, 0), "a", "_")     '' Autorizado
    status &= If(prm.fec_rech > New Date(1900, 1, 1, 0, 0, 0), "r", "_")     '' Rechazado
    status &= If(prm.fec_inic > New Date(1900, 1, 1, 0, 0, 0), "e", "_")     '' Ejercido
    status &= If(prm.fecxmit > New Date(1900, 1, 1, 0, 0, 0), "X", "_")      '' Transmitido
    If (prm.fecautprint Is Nothing) Then                                     '' Liberado para imprimir el contrato
      status &= "_"
    Else
      status &= If(prm.fecautprint > New Date(1900, 1, 1, 0, 0, 0), "L", "_")
    End If
    status &= If(prm.fec_canc > New Date(1900, 1, 1, 0, 0, 0), "B", "_")     '' Cancelado, dado de baja
    status &= If(prm.endoso = True, "E", "_")                                '' Endoso de factura
    status &= If(prm.camb_clte = True, "C", "_")                             '' Cesión de derechos
    status &= If(prm.redoc = True, "R", "_")                                 '' Reestructura de contrato
    status &= If(prm.fec_entrega > New Date(1900, 1, 1, 0, 0, 0), "g", "_")  '' Contrato entregado al cliente
    If prm.fec_inic <= New Date(1900, 1, 1, 0, 0, 0) Then                    '' Terminado plazo del contrato
      status &= "_"
    Else
      status &= If(DateAdd(DateInterval.Month, prm.plazo, prm.fec_inic) < Now.Date, "T", "_")
    End If
    status &= "/[" & String.Format("{0:D2}", prm.modalidad) & "]"            '' Esquema de financiamiento
    Return status
  End Function

  Public Function GETSTATUSCRED(ByVal prm As Object) As String
    Dim status As String = ""
    status &= If(prm.fecalta > New Date(1900, 1, 1, 0, 0, 0), "p", "_")                                                                                ' en proceso(unicamente alta en el Sistema)
    status &= If(prm.fecsoli > New Date(1900, 1, 1, 0, 0, 0), "t", "_")                                                                                ' en trámite(solicitada la linea de crédito)
    status &= If(prm.fecauto > New Date(1900, 1, 1, 0, 0, 0), "a", "_")                                                                                ' Autorizado
    status &= If(prm.fecrech > New Date(1900, 1, 1, 0, 0, 0), "r", "_")                                                                                ' Rechazado
    status &= If(prm.ejercido > 0, "e", "_")                                                                                                           ' Ejercido
    status &= If(prm.fecbaja > New Date(1900, 1, 1, 0, 0, 0), "B", "_")                                                                                ' Cancelado, dado de Baja
    status &= If(prm.endoso = True, "E", "_")                                                                                                          ' Endoso de factura
    status &= If(prm.fecalta = New Date(1900, 1, 1, 0, 0, 0), "_", If(DateAdd(DateInterval.Month, 6, prm.fecalta).AddDays(-1) < Now.Date, "V", "_"))   ' Caratula vencida
    'status &= If(prm.fecentrega > New Date(1900, 1, 1, 0, 0, 0), "g", "_")                                                                             ' Contrato entregado al cliente
    status &= "/[" & String.Format("{0:D2}", prm.modalidad.ToString) & "]"                                                                                      ' esquema de financiamiento

    Return status
  End Function

  ''' <summary>
  ''' Convierte de un tipo a otro
  ''' </summary>
  ''' <param name="origen">Clase de origen</param>
  ''' <param name="destino">Clase de destino</param>
  ''' <remarks>Los campos de ambas clases deben tener el mismo nombre y deben de ser del mismo tipo</remarks>
  Public Sub Convierte(ByRef origen As Object, ByRef destino As Object)
    Dim oInterfaces = origen.GetType().GetInterfaces()
    Dim oTipos As List(Of String) = New List(Of String)({"IEnumerable", "IList", "ICollection"})
    Dim oInterface = oInterfaces.Where(Function(s) oTipos.Contains(s.Name))
    Try
      If oInterface.Count > 0 Then
        Dim oPaso = Activator.CreateInstance(Type.GetType(destino(0).GetType.ToString()))
        destino.Clear()
        For Each oOri In origen
          Dim oDest = Activator.CreateInstance(Type.GetType(oPaso.GetType.ToString()))
          origen_destino(oOri, oDest)
          destino.Add(oDest)
          oDest = Nothing
        Next
      Else
        origen_destino(origen, destino)
      End If
    Catch ex As Exception
      Throw ex
    Finally
      oInterfaces = Nothing
      oInterface = Nothing
    End Try
  End Sub

  ''' <summary>
  ''' Convierte de un tipo a otro
  ''' </summary>
  ''' <param name="origen">clase origen</param>
  ''' <param name="destino">clase destino</param>
  ''' <remarks>los campos de las clases deben tener el mismo nombre y ser del mismo tipo</remarks>
  Public Sub origen_destino(ByRef origen As Object, ByRef destino As Object)
    Dim oDCprops() As System.Reflection.PropertyInfo
    Dim oProps() As System.Reflection.PropertyInfo
    Try
      oDCprops = destino.GetType().GetProperties
      oProps = origen.GetType().GetProperties
      For Each clienteprop As System.Reflection.PropertyInfo In oProps
        For Each dcclienteprop As System.Reflection.PropertyInfo In oDCprops
          If dcclienteprop.Name = clienteprop.Name Then
            dcclienteprop.SetValue(destino, clienteprop.GetValue(origen))
          End If
        Next
      Next
    Catch ex As Exception
      Throw ex
    Finally
      oDCprops = Nothing
      oProps = Nothing
    End Try
  End Sub

  ''' <summary>
  ''' sustituye a LDD, regresa la fecha en el ultimo dia del mes de la fecha proporcionada
  ''' </summary>
  ''' <param name="dfecha">fecha nullable</param>
  ''' <returns>Fecha</returns>
  ''' <remarks>si la fecha es nula o igual a 1900-01-01 regresa 1900-01-01</remarks>
  Public Function LAST_DAY(ByVal dfecha As Date?) As Date
    If dfecha Is Nothing Then
      Return New Date(1900, 1, 1, 0, 0, 0)
    Else
      If dfecha = New Date(1900, 1, 1, 0, 0, 0) Then
        Return New Date(1900, 1, 1, 0, 0, 0)
      Else
        Return New Date(dfecha.Value.Year, dfecha.Value.Month, 1, 0, 0, 0).AddMonths(1).AddDays(-1)
      End If
    End If
  End Function

  Public Function GlobalSerializationSettings() As Newtonsoft.Json.JsonSerializerSettings
    Dim njss = New Newtonsoft.Json.JsonSerializerSettings()
    njss.Culture = System.Globalization.CultureInfo.CurrentCulture
    njss.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local
    Return njss
  End Function
#End Region

#Region "PARA EXPORTAR DBF'S"

  Public Class classdatil
    Implements IDisposable

    Public Property prop() As System.Reflection.PropertyInfo
    Public Property attrColumn() As System.Reflection.CustomAttributeData
    Public Property attrDataType() As System.Reflection.CustomAttributeData
    Public Property attrDataMember() As System.Reflection.CustomAttributeData
    Public Property attrStringLength() As System.Reflection.CustomAttributeData
    Public Property attrKey() As System.Reflection.CustomAttributeData

    Public Property DBName() As String
    Public Property DBOrder() As Integer
    Public Property DBType() As String
    Public Property DBNull() As Boolean
    Public Property DBCompose() As String
    Public Property DBCharSize() As Nullable(Of Integer)
    Public Property DBKey() As Boolean

    Public Property PropName() As String
    Public Property PropType() As String
    Public Property PropNull() As Boolean
    Public Property PropValue() As Object

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Me.prop IsNot Nothing Then Me.prop = Nothing
          If Me.attrColumn IsNot Nothing Then Me.attrColumn = Nothing
          If Me.attrDataType IsNot Nothing Then Me.attrDataType = Nothing
          If Me.attrDataMember IsNot Nothing Then Me.attrDataMember = Nothing
          If Me.attrStringLength IsNot Nothing Then Me.attrStringLength = Nothing
          If Me.attrKey IsNot Nothing Then Me.attrKey = Nothing
          If Me.PropName IsNot Nothing Then Me.PropName = Nothing
          If Me.PropValue IsNot Nothing Then Me.PropValue = Nothing
        End If
      End If
      Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
      Dispose(False)
      MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

  Public Class classdetails
    Implements IDisposable

    Public Property details() As List(Of classdatil)
    Public Property classname() As String
    Public Property tablename() As String

    Public Sub New()
      Me.details = New List(Of classdatil)
    End Sub

    Public Sub import(Of t)(obj As t)
      Me.classname = obj.GetType().FullName
      Me.tablename = obj.GetType().GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "TableAttribute").SingleOrDefault().ConstructorArguments.SingleOrDefault().Value.ToString
      If Me.details Is Nothing Then Me.details = New List(Of classdatil) Else Me.details.Clear()
      For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties.ToList
        Me.details.Add(New classdatil With {
                         .prop = p,
                         .attrDataMember = If(p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "DataMemberAttribute").Count > 0, p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "DataMemberAttribute").Single(), Nothing),
                         .attrColumn = If(p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "ColumnAttribute").Count > 0, p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "ColumnAttribute").Single(), Nothing),
                         .attrDataType = If(p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "DataTypeAttribute").Count > 0, p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "DataTypeAttribute").Single(), Nothing),
                         .attrStringLength = If(p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "StringLengthAttribute").Count > 0, p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "StringLengthAttribute").Single(), Nothing),
                         .attrKey = If(p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "KeyAttribute").Count > 0, p.GetCustomAttributesData().Where(Function(w) w.AttributeType.Name = "KeyAttribute").Single(), Nothing)
                        })
      Next
      For Each d In Me.details
        d.DBName = d.attrColumn.ConstructorArguments.SingleOrDefault().Value.ToString
        d.DBOrder = CType(d.attrColumn.NamedArguments.SingleOrDefault().TypedValue.Value.ToString, Integer)
        d.DBType = d.attrDataType.ConstructorArguments.SingleOrDefault().Value.ToString.Split(" ").ElementAt(0)
        d.DBNull = Not d.attrDataType.ConstructorArguments.Single().Value.ToString.Contains("NOT NULL")
        With d.attrDataType.ConstructorArguments.SingleOrDefault().Value.ToString
          d.DBCompose = If(.Replace(.Split(" ").ElementAt(0), "").Contains("NOT NULL"), .Replace(.Split(" ").ElementAt(0), "").Replace("NOT NULL", ""), .Replace(.Split(" ").ElementAt(0), "").Replace("NULL", ""))
        End With
        d.DBKey = If(d.attrKey IsNot Nothing, True, False)
        d.DBCharSize = If(d.attrStringLength IsNot Nothing, CType(d.attrStringLength.ConstructorArguments.SingleOrDefault().Value.ToString, Integer), Nothing)
        d.PropName = d.prop.Name
        d.PropNull = d.prop.PropertyType.Name.Contains("Nullable")
        If d.PropNull Then
          d.PropType = Nullable.GetUnderlyingType(d.prop.PropertyType).Name
        Else
          d.PropType = d.prop.PropertyType.Name
        End If
        d.PropValue = d.prop.GetValue(obj)
      Next
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          If Me.details IsNot Nothing Then Me.details = Nothing
        End If
      End If
      Me.disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
      Dispose(False)
      MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

  Public Sub ExportDBF(Of T)(dataset As IList(Of T), ByVal path As String, ByVal tablename As String)
    Dim vfptable = String.Empty
    Dim vfpinsert = String.Empty
    Dim odeslst = objectdescription(dataset)
    If path.LastIndexOf("\") < path.Length - 1 Then path = path & "\"
    vfptable = createVFPtable(odeslst, tablename)
    vfpinsert = createVFPInsert(odeslst, tablename)
    If System.IO.File.Exists(path & tablename & ".DBF") Then System.IO.File.Delete(path & tablename & ".DBF")
    If System.IO.File.Exists(path & tablename & ".FPT") Then System.IO.File.Delete(path & tablename & ".FPT")
    If System.IO.File.Exists(path & tablename & ".CDX") Then System.IO.File.Delete(path & tablename & ".CDX")
    System.IO.File.Create(path & tablename & ".DBF").Close()
    Using vfpConn As New OleDb.OleDbConnection("Provider=VFPOLEDB; Data Source=" & path & tablename & ".dbf; Collating Sequence=general;")
      Using vfpCmd As New OleDb.OleDbCommand("", vfpConn)
        vfpCmd.CommandText = vfptable
        vfpConn.Open()
        vfpCmd.ExecuteNonQuery()
        addcmdparams(vfpCmd, odeslst)
        For Each obj In dataset
          vfpCmd.CommandText = vfpinsert
          For Each det In odeslst.Select(Function(s) s.details).SingleOrDefault
            Dim propname = det.DBName.Substring(0, If(det.DBName.Length > 10, 10, det.DBName.Length))
            vfpCmd.Parameters(propname).Value = det.prop.GetValue(obj)
          Next
          vfpCmd.ExecuteNonQuery()
        Next
      End Using
    End Using
  End Sub

  Private Sub addcmdparams(ByRef vfpCmd As OleDb.OleDbCommand, ByRef odeslst As List(Of classdetails))
    Dim tiposTexto As List(Of String) = New List(Of String)({"Char", "String"})
    Dim tiposInt As List(Of String) = New List(Of String)({"Int16", "Int32", "Int64", "UInt16", "UInt32", "UInt64", "Byte", "Single", "SByte", "Integer", "Long", "Short", "UInteger", "ULong", "UShort"})
    Dim tiposDecimal As List(Of String) = New List(Of String)({"Decimal", "Double"})
    Dim tiposFecha As List(Of String) = New List(Of String)({"Date", "DateTime"})
    For Each det In odeslst.Select(Function(s) s.details).SingleOrDefault

      Dim propname As String = det.DBName

      If tiposTexto.Contains(If(det.prop.PropertyType.Name.Contains("Nullable"), Nullable.GetUnderlyingType(det.prop.PropertyType).Name, det.prop.PropertyType.Name)) Then
        If det.DBType.Contains("text") Then
          vfpCmd.Parameters.Add(New OleDb.OleDbParameter(propname, OleDb.OleDbType.LongVarChar))
        Else
          Dim nlenfield = CType(det.DBCompose.Substring(det.DBCompose.IndexOf("(") + 1, det.DBCompose.IndexOf(")") - det.DBCompose.IndexOf("(") - 1), Integer)
          If nlenfield > 254 Then
            vfpCmd.Parameters.Add(New OleDb.OleDbParameter(propname, OleDb.OleDbType.LongVarChar))
          Else
            vfpCmd.Parameters.Add(New OleDb.OleDbParameter(propname, OleDb.OleDbType.Char))
          End If
        End If
      End If
      If tiposInt.Contains(If(det.prop.PropertyType.Name.Contains("Nullable"), Nullable.GetUnderlyingType(det.prop.PropertyType).Name, det.prop.PropertyType.Name)) Then
        vfpCmd.Parameters.Add(New OleDb.OleDbParameter(propname, OleDb.OleDbType.Integer))
      End If
      If tiposDecimal.Contains(If(det.prop.PropertyType.Name.Contains("Nullable"), Nullable.GetUnderlyingType(det.prop.PropertyType).Name, det.prop.PropertyType.Name)) Then
        vfpCmd.Parameters.Add(New OleDb.OleDbParameter(propname, OleDb.OleDbType.Decimal))
      End If
      If If(det.prop.PropertyType.Name.Contains("Nullable"), Nullable.GetUnderlyingType(det.prop.PropertyType).Name, det.prop.PropertyType.Name) = "Boolean" Then
        vfpCmd.Parameters.Add(New OleDb.OleDbParameter(propname, OleDb.OleDbType.Boolean))
      End If
      If tiposFecha.Contains(If(det.prop.PropertyType.Name.Contains("Nullable"), Nullable.GetUnderlyingType(det.prop.PropertyType).Name, det.prop.PropertyType.Name)) Then
        vfpCmd.Parameters.Add(New OleDb.OleDbParameter(propname, OleDb.OleDbType.Date))
      End If
    Next
  End Sub

  Private Function objectdescription(Of T)(data As IList(Of T)) As List(Of classdetails)
    Dim oclassdetails As New List(Of classdetails)
    Dim oclassdetail As Negocio.classdetails = Nothing
    For Each elem In data.ToList      
      oclassdetail = New Negocio.classdetails()
      oclassdetail.import(elem)
      oclassdetail.details = oclassdetail.details.Where(Function(w) w.DBName.Length <= 10).ToList
      oclassdetails.Add(oclassdetail)      
    Next
    Return oclassdetails
  End Function

  Private Function createVFPtable(ByRef details As List(Of classdetails), ByVal tablename As String) As String
    Dim vfptable = "CREATE TABLE " & tablename & " FREE ( {0} )"
    Dim scolumns As String = ""
    Dim tiposTexto As List(Of String) = New List(Of String)({"Char", "String"})
    Dim tiposInt As List(Of String) = New List(Of String)({"Int16", "Int32", "Int64", "UInt16", "UInt32", "UInt64", "Byte", "Single", "SByte", "Integer", "Long", "Short", "UInteger", "ULong", "UShort"})
    Dim tiposDecimal As List(Of String) = New List(Of String)({"Decimal", "Double"})
    Dim tiposFecha As List(Of String) = New List(Of String)({"Date", "DateTime"})
    For Each det In details.Select(Function(s) s.details).SingleOrDefault

      scolumns += det.DBName

      If tiposTexto.Contains(det.PropType) Then
        If det.DBType.Contains("text") Then
          scolumns += " M" & If(det.DBNull, " NULL", " NOT NULL")
        Else
          Dim nlenfield = det.DBCharSize.Value
          If nlenfield > 254 Then
            scolumns += " M" & If(det.DBNull, " NULL", " NOT NULL")
          Else
            scolumns += " C(" & nlenfield.ToString & ")" & If(det.DBNull, " NULL", " NOT NULL")
          End If
        End If
      End If
      If tiposInt.Contains(det.PropType) Then
        scolumns += " I" & If(det.DBNull, " NULL", " NOT NULL")
      End If
      If tiposDecimal.Contains(det.PropType) Then
        If det.DBType.Contains("money") Then
          scolumns += " Y" & If(det.DBNull, " NULL", " NOT NULL")
        Else
          Dim srangeN = det.DBCompose.Replace("(", "").Replace(")", "").Trim
          If srangeN.Trim.Length <= 0 Then
            scolumns += " N"
          Else
            scolumns += " N(" & srangeN & ")" & If(det.DBNull, " NULL", " NOT NULL")
          End If
        End If
      End If
      If det.PropType = "Boolean" Then
        scolumns += " L" & If(det.DBNull, " NULL", " NOT NULL")
      End If
      If tiposFecha.Contains(det.PropType) Then
        scolumns += " T" & If(det.DBNull, " NULL", " NOT NULL")
      End If
      If details.Select(Function(s) s.details).SingleOrDefault.IndexOf(det) < details.Select(Function(s) s.details).SingleOrDefault.Count - 1 Then
        scolumns += ", "
      End If
    Next
    vfptable = String.Format(vfptable, scolumns)
    Return vfptable
  End Function

  Private Function createVFPInsert(ByVal details As List(Of classdetails), ByVal tablename As String) As String
    Dim VFPInsert = "INSERT INTO " & tablename & " ({0}) VALUES ({1})"
    Dim scolumns = String.Empty
    Dim svalues = String.Empty
    For Each det In details.Select(Function(s) s.details).SingleOrDefault
      scolumns += det.DBName
      svalues += "?"
      If details.Select(Function(s) s.details).SingleOrDefault.IndexOf(det) < details.Select(Function(s) s.details).SingleOrDefault.Count - 1 Then
        scolumns += ", "
        svalues += ", "
      End If
    Next
    VFPInsert = String.Format(VFPInsert, scolumns, svalues)
    Return VFPInsert
  End Function
#End Region

End Module
