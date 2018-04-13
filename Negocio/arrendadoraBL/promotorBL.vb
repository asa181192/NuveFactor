Imports System
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Negocio.Validaciones
Imports System.Reflection
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraBL
  Public Class promotorBL
    Inherits arrendadora.promotor

    Private Campos As System.Collections.Generic.IEnumerable(Of System.Xml.XmlNode)
    Private sConsLlave As List(Of String) = New List(Of String)({"promotor"})
    Private schanges As String
    Private schangeslst As List(Of String)

    Public Property oNewPromotorOuBx() As Entidades.arrendadora.promotor
    Public Property oNewPromotoresOuBx() As List(Of Entidades.arrendadora.promotor)
    Public Property oOriPromotorOuBx() As Entidades.arrendadora.promotor
    Public Property oOriPromotoresOuBx() As List(Of Entidades.arrendadora.promotor)

    ''' <summary>
    ''' Arrendadora
    ''' </summary>    
    ''' <remarks>Arrendadora</remarks>
    Public Sub New()
      MyBase.New()
    End Sub

    ''' <summary>
    ''' Arrendadora
    ''' </summary>
    ''' <param name="scnn">cnnstr</param>
    ''' <remarks>Arrendadora</remarks>
    Public Sub New(ByVal scnn As String)
      MyBase.New(scnn)
    End Sub

    Public Property PaqueteValidacion() As List(Of PaqueteValidacion)

    Public Overrides Function SelectpromotorRegion(ByVal activo As Boolean?, ByVal oficinas As String, Optional ByVal todos As Boolean = False) As List(Of promotorregion_Result)
      Return MyBase.SelectpromotorRegion(activo, oficinas, todos)
    End Function

    Public Overrides Function Selectpromotores(ByVal activo As Boolean?) As List(Of Entidades.arrendadora.promotor)
      Return MyBase.Normaliza(MyBase.Selectpromotores(activo))
    End Function

    Public Overrides Function Selectpromotor(promotor As Integer, Optional oficina As Integer = 0) As promotor
      Return MyBase.Normaliza(MyBase.Selectpromotor(promotor, oficina))
    End Function

    Public Overrides Function SelectPromotorbyNombre(ByVal promotor As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of sp_PromotoresBusquedaXNombre_Result)
      Return MyBase.SelectPromotorbyNombre(promotor, nombre, oficinas)
    End Function

    Public Overrides Function Selectpromotordetalle(Optional ByVal oficinas As String = "") As List(Of sp_PromotoresDetalle_Result)
      Return MyBase.Selectpromotordetalle(oficinas)
    End Function

    Public Overrides Function Selectpromotorcontratos(promotor As Integer) As List(Of promotorcontratos_Result)
      Return MyBase.Selectpromotorcontratos(promotor)
    End Function

    Public Overrides Function Selectpromotorclientes(promotor As Integer) As List(Of promotorclientes_Result)
      Return MyBase.Selectpromotorclientes(promotor)
    End Function

    Public Overrides Function getSaldoInsolutoPromotor(promotor As Integer, Optional SumaIvaInsoluto As Boolean = False) As Decimal
      Return MyBase.getSaldoInsolutoPromotor(promotor, SumaIvaInsoluto)
    End Function

    Public Overrides Function GetColocxM(ByVal ano As Integer, ByVal mes As Integer, ByVal oficina As Integer, ByVal modalidad As Integer, Optional ByVal oficinas As String = "1") As List(Of sp_rpt_colocxm_Result)
      Return MyBase.GetColocxM(ano, mes, oficina, modalidad, oficinas)
    End Function

    Public Overrides Function ExisteRFC(RFC As String, Optional ByVal oficinas As String = "") As Boolean
      Return MyBase.ExisteRFC(RFC, oficinas)
    End Function

    Public Overrides Function SelectPromotorAdeudoClientes(ByVal promotor As Integer) As List(Of sp_AdeudoClientesXPromotor_Result)
      Return MyBase.SelectPromotorAdeudoClientes(promotor)
    End Function

    Public Overrides Function Submit(ByRef promotor As promotor, ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(promotor)
      bTrans = MyBase.Submit(promotor, oficina)
      oNewPromotorOuBx = Me.promotorDL.oNewPromotorOuBx
      oOriPromotorOuBx = Me.promotorDL.oOriPromotorOuBx
      Return bTrans
    End Function

    Public Overrides Function Submit(ByRef promotores As List(Of promotor), ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      MyBase.Normaliza(promotores)
      bTrans = MyBase.Submit(promotores, oficina)
      oNewPromotoresOuBx = Me.promotorDL.oNewPromotoresOuBx
      oOriPromotoresOuBx = Me.promotorDL.oOriPromotoresOuBx
      Return bTrans
    End Function

    Public Function GeneraOutbox(oficina As Integer, Optional ByVal campos As String = "") As Boolean
      Dim bTrans As Boolean = False

      Try
        If Not Me.oNewPromotorOuBx Is Nothing Then Me.promotorDL.oNewPromotorOuBx = Me.oNewPromotorOuBx
        If Not Me.oNewPromotoresOuBx Is Nothing Then Me.promotorDL.oNewPromotoresOuBx = Me.oNewPromotoresOuBx
        If Not Me.oOriPromotorOuBx Is Nothing Then Me.promotorDL.oOriPromotorOuBx = Me.oOriPromotorOuBx
        If Not Me.oOriPromotoresOuBx Is Nothing Then Me.promotorDL.oOriPromotoresOuBx = Me.oOriPromotoresOuBx

        If campos.Trim.Length > 0 Then
          sConsLlave.AddRange(campos.Split(",").ToList.Where(Function(w) Not sConsLlave.Select(Function(s) s.ToLower).ToList.Contains(w.ToLower)).ToList)
        End If

        If Not Me.oNewPromotorOuBx Is Nothing Then
          MyBase.CargaXML(oNewPromotorOuBx.GetType().Name)
          Dim oProps = Me.oNewPromotorOuBx.GetType().GetProperties()
          If oOriPromotorOuBx Is Nothing Then
            schanges = ""
            For Each prop As System.Reflection.PropertyInfo In oProps
              schanges &= MyBase.GenerarOutbox(prop, oNewPromotorOuBx)
            Next
          Else
            schanges &= MyBase.ChangesOutbox(oOriPromotorOuBx, oNewPromotorOuBx, sConsLlave)
          End If
          bTrans = MyBase.Outbox(oficina, "PROMOTOR", "PROMOTOR", "M.PROMOTOR", schanges)
          MyBase.LiberaXML()
        End If

        If Not Me.oNewPromotoresOuBx Is Nothing Then
          MyBase.CargaXML(oNewPromotoresOuBx.GetType().Name)
          Dim oProps = Me.oNewPromotoresOuBx.ElementAt(0).GetType().GetProperties()
          If Not schangeslst Is Nothing Then schangeslst = Nothing
          schangeslst = New List(Of String)
          If Me.oOriPromotoresOuBx Is Nothing Then
            For Each prom As promotor In Me.oNewPromotoresOuBx
              schanges = ""
              For Each prop As System.Reflection.PropertyInfo In oProps
                schanges &= MyBase.GenerarOutbox(prop, prom)
              Next
              schangeslst.Add(schanges)
            Next
          Else
            For Each Newprom As promotor In Me.oNewPromotoresOuBx
              Dim oOldProm = Me.oOriPromotoresOuBx.Where(Function(w) w.promotor_id = Newprom.promotor_id)
              schanges = ""
              If oOldProm.Count() > 0 Then
                schanges = MyBase.ChangesOutbox(oOldProm.Single, Newprom, sConsLlave)
              Else
                For Each prop As System.Reflection.PropertyInfo In oProps
                  schanges &= MyBase.GenerarOutbox(prop, Newprom)
                Next
              End If
              schangeslst.Add(schanges)
            Next
          End If
          bTrans = MyBase.Outbox(oficina, "PROMOTOR", "PROMOTOR", "M.PROMOTOR", schangeslst)
          MyBase.LiberaXML()
        End If
      Catch ex As Exception
        Me.hayErr = True
        If ex.Message = "Error datos" Then
          Me.Err = ex
        ElseIf ex.Message = "Error negocio" Then
          Me.Err = ex
        Else
          Me.Err = New Exception("Error negocio", ex)
        End If
        bTrans = False
      End Try

      Return bTrans
    End Function

    Public Function Validapromotor(ByVal promotor As promotor) As Boolean
      Dim bValida As Boolean = False
      Dim oPaqueteVal As New PaqueteValidacion
      Dim oProps = promotor.GetType().GetProperties()

      With oPaqueteVal
        .Aprovado = True
        .Entidad = promotor
        For Each oProp As System.Reflection.PropertyInfo In oProps
          Dim oComentario As Comentario = Nothing

          Select Case oProp.Name
            Case Is = "promotor_id"
              oComentario = Metodos.ValidaNumero(1, promotor, oProp, False, True, -1, -1)
            Case Is = "codigo"
              oComentario = Metodos.ValidaCadena(2, promotor, oProp, False, True, 6)
            Case Is = "nombre"
              oComentario = Metodos.ValidaCadena(3, promotor, oProp, False, True, 100)
            Case Is = "empresa"
              oComentario = Metodos.ValidaNumero(4, promotor, oProp, False, True, -1, -1)
            Case Is = "activo"
              oComentario = Metodos.ValidaBoleano(5, promotor, oProp, False)
            Case Is = "valor_fin"
              oComentario = Metodos.ValidaNumero(6, promotor, oProp, False, True, -1, -1)
            Case Is = "valor_com"
              oComentario = Metodos.ValidaNumero(7, promotor, oProp, False, True, -1, -1)
            Case Is = "telefono"
              oComentario = Metodos.ValidaCadena(8, promotor, oProp, False, True, 20)
            Case Is = "tipo"
              oComentario = Metodos.ValidaCadena(9, promotor, oProp, False, True, 1)
            Case Is = "comision"
              oComentario = Metodos.ValidaNumero(10, promotor, oProp, False, True, -1, -1)
            Case Is = "void"
              oComentario = Metodos.ValidaBoleano(11, promotor, oProp, False)
            Case Is = "enviado"
              oComentario = Metodos.ValidaFecha(12, promotor, oProp, True)
            Case Is = "rfc"
              oComentario = Metodos.ValidaCadena(13, promotor, oProp, True, True, 13)
            Case Is = "domicilio"
              oComentario = Metodos.ValidaCadena(14, promotor, oProp, True, True, 100)
            Case Is = "colonia"
              oComentario = Metodos.ValidaCadena(15, promotor, oProp, True, True, 100)
            Case Is = "municipio"
              oComentario = Metodos.ValidaCadena(16, promotor, oProp, True, True, 100)
            Case Is = "estado"
              oComentario = Metodos.ValidaCadena(17, promotor, oProp, True, True, 40)
            Case Is = "cp"
              oComentario = Metodos.ValidaNumero(18, promotor, oProp, True, True, -1, -1)
            Case Is = "email"
              oComentario = Metodos.ValidaCadena(19, promotor, oProp, True, True, 50)
            Case Is = "fec_alta"
              oComentario = Metodos.ValidaFecha(20, promotor, oProp, True)
            Case Is = "fec_baja"
              oComentario = Metodos.ValidaFecha(21, promotor, oProp, True)
            Case Is = "pbase"
              oComentario = Metodos.ValidaNumero(22, promotor, oProp, True, True, -1, -1)
            Case Is = "curp"
              oComentario = Metodos.ValidaCadena(23, promotor, oProp, True, True, 18)
            Case Is = "incentivo"
              oComentario = Metodos.ValidaNumero(24, promotor, oProp, True, True, -1, -1)
            Case Is = "renovacion"
              oComentario = Metodos.ValidaCadena(25, promotor, oProp, True, True, 2147483647)
            Case Is = "ultrenovac"
              oComentario = Metodos.ValidaFecha(26, promotor, oProp, True)
            Case Is = "cuenta"
              oComentario = Metodos.ValidaCadena(27, promotor, oProp, True, True, 100)
            Case Is = "nomina"
              oComentario = Metodos.ValidaNumero(28, promotor, oProp, True, True, -1, -1)
            Case Is = "segmento"
              oComentario = Metodos.ValidaNumero(29, promotor, oProp, True, True, -1, -1)
            Case Is = "zona"
              oComentario = Metodos.ValidaNumero(30, promotor, oProp, True, True, -1, -1)
            Case Is = "id_regi"
              oComentario = Metodos.ValidaNumero(31, promotor, oProp, True, True, -1, -1)
            Case Is = "oficina"
              oComentario = Metodos.ValidaNumero(32, promotor, oProp, True, True, -1, -1)
            Case Is = "fordtwoo"
              oComentario = Metodos.ValidaNumero(33, promotor, oProp, True, True, -1, -1)
            Case Is = "pfisica"
              oComentario = Metodos.ValidaBoleano(34, promotor, oProp, True)
            Case Is = "calle"
              oComentario = Metodos.ValidaCadena(35, promotor, oProp, True, True, 150)
            Case Is = "numint"
              oComentario = Metodos.ValidaCadena(36, promotor, oProp, True, True, 20)
            Case Is = "numext"
              oComentario = Metodos.ValidaCadena(37, promotor, oProp, True, True, 20)
            Case Is = "sepomex"
              oComentario = Metodos.ValidaCadena(38, promotor, oProp, True, True, 25)
            Case Is = "id_plaza"
              oComentario = Metodos.ValidaNumero(39, promotor, oProp, True, True, -1, -1)
            Case Is = "contrato"
              oComentario = Metodos.ValidaFecha(40, promotor, oProp, True)
            Case Is = "puesto"
              oComentario = Metodos.ValidaCadena(41, promotor, oProp, True, True, 40)
            Case Is = "conomina"
              oComentario = Metodos.ValidaCadena(42, promotor, oProp, True, True, 40)
          End Select

          If oComentario Is Nothing Then oComentario = New Negocio.Validaciones.Comentario(0, oProp.PropertyType, oProp, "")

          If oComentario.Comentario.Trim.Length > 0 Then
            oPaqueteVal.Aprovado = False
            If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
            oPaqueteVal.Comentarios.Add(New Comentario(i:=oComentario.Indice, Tipo:=oComentario.Tipo, Campo:=oComentario.Campo, Cometario:=oComentario.Comentario))
          End If

          oComentario.Dispose()
        Next
      End With

      bValida = oPaqueteVal.Aprovado
      If oPaqueteVal.Comentarios Is Nothing Then oPaqueteVal.Comentarios = New List(Of Comentario)
      If Me.PaqueteValidacion Is Nothing Then Me.PaqueteValidacion = New List(Of PaqueteValidacion)
      Me.PaqueteValidacion.Add(New PaqueteValidacion(Entidad:=oPaqueteVal.Entidad, Aprovado:=oPaqueteVal.Aprovado, Comentarios:=oPaqueteVal.Comentarios))
      oPaqueteVal.Dispose()

      Return bValida
    End Function

    Public Function Validapromotors(ByVal promotors As List(Of promotor)) As Boolean
      Dim bValida As Boolean = True
      For Each oInst As promotor In promotors
        bValida = bValida And Me.Validapromotor(oInst)
      Next
      Return bValida
    End Function

  End Class
End Namespace

