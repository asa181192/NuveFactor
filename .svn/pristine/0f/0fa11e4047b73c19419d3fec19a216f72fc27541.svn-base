Imports System.Web
Imports System.Web.Mvc
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports Entidades
Imports Entidades.arrendadora
Imports Negocio
Imports Negocio.arrendadoraBL

Public Class funcionescontroles
  Inherits Controller

  Protected _OFICINAS As String
  Protected _REMOTE_ADDR As String
  Protected _USERID As String

  Public WriteOnly Property OFICINAS() As String
    Set(value As String)
      Me._OFICINAS = value
    End Set
  End Property

  Public WriteOnly Property REMOTE_ADDR() As String
    Set(value As String)
      Me._REMOTE_ADDR = value
    End Set
  End Property

  Public WriteOnly Property USERID() As String
    Set(value As String)
      Me._USERID = value
    End Set
  End Property

  Public Function cargaOficinas(ByVal EnabledAllOffice As Boolean) As List(Of SelectListItem)
    Dim oOficinaBL As oficinaBL = Nothing
    Dim oOficina As List(Of oficina) = Nothing
    Dim oOficinalst As List(Of SelectListItem) = Nothing
    Try
      oOficinaBL = New oficinaBL()
      oOficina = oOficinaBL.SelectOficina()
      If oOficinaBL.hayErr Then Throw oOficinaBL.Err

      If (oOficina IsNot Nothing) Then
        If (oOficina.Count > 0) Then

          If Me._OFICINAS > 1 Then
            If Not EnabledAllOffice = True Then
              Dim ofas = Me._OFICINAS.ToString.Split(",").Where(Function(w) w.Trim.Length > 0).Select(Function(s) New With {.origen = Convert.ToDecimal(s)}).ToList()
              oOficinalst = (From elem1 As oficina In oOficina
                             Join elem2 In ofas On elem1.origen Equals elem2.origen
                             Where Not elem1.nombre.Contains("\") AndAlso elem1.nombre.Trim.Length > 0
                             Select elem1).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.oficina_id.ToString}).ToList()
            Else
              oOficinalst = (From elem1 As oficina In oOficina
                             Where Not elem1.nombre.Contains("\") AndAlso elem1.nombre.Trim.Length > 0
                             Select elem1).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.oficina_id.ToString}).ToList()
            End If
          Else
            oOficinalst = (From elem1 As oficina In oOficina
                           Where Not elem1.nombre.Contains("\") AndAlso elem1.nombre.Trim.Length > 0
                           Select elem1).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.oficina_id.ToString}).ToList()
          End If
        Else
          oOficinalst = (From elem1 As oficina In oOficina
                         Where Not elem1.nombre.Contains("\") AndAlso elem1.nombre.Trim.Length > 0
                         Select elem1).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.oficina_id.ToString}).ToList()
        End If
      End If
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      oOficinalst = New List(Of SelectListItem)
    Finally
      If oOficinaBL IsNot Nothing Then oOficinaBL.Dispose()
      If oOficinaBL IsNot Nothing Then oOficinaBL = Nothing
      If oOficina IsNot Nothing Then oOficina = Nothing
    End Try
    Return oOficinalst
  End Function

  Public Function cargaEstados() As List(Of SelectListItem)
    Dim oestados As List(Of SelectListItem) = Nothing
    Dim osepomexBL As sepomexBL = Nothing
    Try
      osepomexBL = New sepomexBL()
      oestados = osepomexBL.Selectsepomexedo().OrderBy(Function(o) o.idestado).Select(Function(s) New SelectListItem With {.Text = s.estado.Trim, .Value = s.idestado.ToString}).ToList()
      If osepomexBL.hayErr Then Throw osepomexBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      oestados = New List(Of SelectListItem)
    Finally
      If osepomexBL IsNot Nothing Then osepomexBL.Dispose()
      If osepomexBL IsNot Nothing Then osepomexBL = Nothing
    End Try
    Return oestados
  End Function

  Public Function cargaMunicipios(ByVal nEstado As Integer) As List(Of SelectListItem)
    Dim omunicipios As List(Of SelectListItem) = Nothing
    Dim osepomexBL As sepomexBL = Nothing
    Try
      osepomexBL = New sepomexBL()
      omunicipios = osepomexBL.Selectsepomexmuni(nEstado).OrderBy(Function(o) o.idmunicipio).Select(Function(s) New SelectListItem With {.Text = s.municipio.Trim, .Value = s.idmunicipio.ToString}).ToList()
      If osepomexBL.hayErr Then Throw osepomexBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      omunicipios = New List(Of SelectListItem)
    Finally
      If osepomexBL IsNot Nothing Then osepomexBL.Dispose()
      If osepomexBL IsNot Nothing Then osepomexBL = Nothing
    End Try
    Return omunicipios
  End Function

  Public Function TiposSociedad() As List(Of SelectListItem)
    Dim otiposociedadBL As tiposociedadBL = Nothing
    Dim otiposociedads As List(Of SelectListItem) = Nothing
    Try
      otiposociedadBL = New tiposociedadBL()
      otiposociedads = otiposociedadBL.Selecttiposociedad().OrderBy(Function(o) o.abreviado).Select(Function(s) New SelectListItem With {.Text = s.abreviado, .Value = s.numero.ToString}).ToList
      If otiposociedadBL.hayErr Then Throw otiposociedadBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      otiposociedads = New List(Of SelectListItem)
    Finally
      If otiposociedadBL IsNot Nothing Then otiposociedadBL.Dispose()
      If otiposociedadBL IsNot Nothing Then otiposociedadBL = Nothing
    End Try
    Return otiposociedads
  End Function

  Public Function cargaPaises() As List(Of SelectListItem)
    Dim paiseslst As List(Of SelectListItem) = Nothing
    Dim opaiBL As paiBL = Nothing
    Try
      opaiBL = New paiBL()
      paiseslst = opaiBL.Selectpais().OrderBy(Function(o) o.folio).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.folio.ToString}).ToList()
      If opaiBL.hayErr Then Throw opaiBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      paiseslst = New List(Of SelectListItem)
    Finally
      If opaiBL IsNot Nothing Then opaiBL.Dispose()
      If opaiBL IsNot Nothing Then opaiBL = Nothing
    End Try
    Return paiseslst
  End Function

  Public Function cargaActividades() As List(Of SelectListItem)
    Dim actividadeslst As List(Of SelectListItem) = Nothing
    Dim oactivBL As activBL = Nothing
    Try
      oactivBL = New activBL()
      actividadeslst = oactivBL.Selectactiv().OrderBy(Function(o) o.clave).Select(Function(s) New SelectListItem With {.Text = s.actividad.Trim, .Value = s.clave.ToString}).ToList()
      If oactivBL.hayErr Then Throw oactivBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      actividadeslst = New List(Of SelectListItem)
    Finally
      If oactivBL IsNot Nothing Then oactivBL.Dispose()
      If oactivBL IsNot Nothing Then oactivBL = Nothing
    End Try
    Return actividadeslst
  End Function

  Public Function cargaSubActividades() As List(Of SelectListItem)
    Dim subactivlst As List(Of SelectListItem) = Nothing
    Dim osubactivBL As subactivBL = Nothing
    Try
      osubactivBL = New subactivBL()
      subactivlst = osubactivBL.Selectsubactiv().OrderBy(Function(o) o.sdescrip).Select(Function(s) New SelectListItem With {.Text = s.sdescrip.Trim & "/" & s.descrip.Trim, .Value = s.subactiv_id.Value.ToString}).ToList()
      If osubactivBL.hayErr Then Throw osubactivBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      subactivlst = New List(Of SelectListItem)
    Finally
      If osubactivBL IsNot Nothing Then osubactivBL.Dispose()
      If osubactivBL IsNot Nothing Then osubactivBL = Nothing
    End Try
    Return subactivlst
  End Function

  Public Function cargaSectoresEconomicos() As List(Of SelectListItem)
    Dim sececolst As List(Of SelectListItem) = Nothing
    Dim osececoBL As sececoBL = Nothing
    Try
      osececoBL = New sececoBL()
      sececolst = osececoBL.Selectsececo().OrderBy(Function(s) s.numero.Value).Select(Function(s) New SelectListItem With {.Text = s.descripcion.Trim, .Value = s.numero.Value.ToString}).ToList()
      If osececoBL.hayErr Then Throw osececoBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      sececolst = New List(Of SelectListItem)
    Finally
      If osececoBL IsNot Nothing Then osececoBL.Dispose()
      If osececoBL IsNot Nothing Then osececoBL = Nothing
    End Try
    Return sececolst
  End Function

  Public Function cargaGruposRiesgo() As List(Of SelectListItem)
    Dim riesgos As List(Of SelectListItem) = Nothing
    Dim oriesgoBL As arrendadoraBL.riesgoBL = Nothing
    Try
      oriesgoBL = New riesgoBL()
      riesgos = oriesgoBL.SelectGrupoNombre(Me._OFICINAS).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.grupo.ToString}).ToList()
      If oriesgoBL.hayErr Then Throw oriesgoBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      riesgos = New List(Of SelectListItem)
    Finally
      If oriesgoBL IsNot Nothing Then oriesgoBL.Dispose()
      If oriesgoBL IsNot Nothing Then oriesgoBL = Nothing
    End Try
    Return riesgos
  End Function

  Public Function cargaColonias(ByVal zipcode As String) As List(Of SelectListItem)
    Dim osepomexlst As List(Of SelectListItem) = Nothing
    Dim osepomexBL As sepomexBL = Nothing
    Dim osepomexs As List(Of sepomex) = Nothing
    Try
      osepomexBL = New sepomexBL()
      If zipcode.Trim.Length > 0 Then
        osepomexBL = New sepomexBL()
        osepomexs = osepomexBL.Selectsepomex(codigo:=CDbl(zipcode.Trim))
        If osepomexBL.hayErr Then Throw osepomexBL.Err
        If osepomexs.Count > 0 Then
          osepomexlst = New List(Of SelectListItem)
          osepomexlst.Add(New SelectListItem With {.Text = "", .Value = "0"})
          osepomexlst.AddRange(osepomexs.OrderBy(Function(s) s.id_unico).Select(Function(s) New SelectListItem With {.Text = s.d_asenta.Trim, .Value = s.id_unico.ToString}).ToList())
        Else
          osepomexlst = New List(Of SelectListItem)
          osepomexlst.Add(New SelectListItem With {.Text = "", .Value = "0"})
        End If
      Else
        osepomexlst = New List(Of SelectListItem)
        osepomexlst.Add(New SelectListItem With {.Text = "", .Value = "0"})
      End If
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      osepomexlst = New List(Of SelectListItem)
    Finally
      If osepomexBL IsNot Nothing Then osepomexBL.Dispose()
      If osepomexBL IsNot Nothing Then osepomexBL = Nothing
      If osepomexs IsNot Nothing Then osepomexs = Nothing
    End Try
    Return osepomexlst
  End Function

  Public Function cargaMeses() As List(Of SelectListItem)
    Dim omeseslst As List(Of SelectListItem) = Nothing
    omeseslst.Add(New SelectListItem With {.Value = "01", .Text = "Enero"})
    omeseslst.Add(New SelectListItem With {.Value = "02", .Text = "Febrero"})
    omeseslst.Add(New SelectListItem With {.Value = "03", .Text = "Marzo"})
    omeseslst.Add(New SelectListItem With {.Value = "04", .Text = "Abril"})
    omeseslst.Add(New SelectListItem With {.Value = "05", .Text = "Mayo"})
    omeseslst.Add(New SelectListItem With {.Value = "06", .Text = "Junio"})
    omeseslst.Add(New SelectListItem With {.Value = "07", .Text = "Julio"})
    omeseslst.Add(New SelectListItem With {.Value = "08", .Text = "Agosto"})
    omeseslst.Add(New SelectListItem With {.Value = "09", .Text = "Septiembre"})
    omeseslst.Add(New SelectListItem With {.Value = "10", .Text = "Octubre"})
    omeseslst.Add(New SelectListItem With {.Value = "11", .Text = "Noviembre"})
    omeseslst.Add(New SelectListItem With {.Value = "12", .Text = "Diciembre"})
    Return omeseslst
  End Function

  Public Function cargaMetodosPago() As List(Of SelectListItem)
    Dim metpagos As List(Of SelectListItem) = Nothing
    Dim ometpagoBL As metpagoBL = Nothing
    Try
      ometpagoBL = New metpagoBL()
      metpagos = ometpagoBL.Selectmetpago().OrderBy(Function(o) o.metpago_id).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.metpago_id.ToString}).ToList()
      If ometpagoBL.hayErr Then Throw ometpagoBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      metpagos = New List(Of SelectListItem)
    Finally
      If ometpagoBL IsNot Nothing Then ometpagoBL.Dispose()
      If ometpagoBL IsNot Nothing Then ometpagoBL = Nothing
    End Try
    Return metpagos
  End Function

  Public Function cargaPromotores(ByVal activo As Boolean, ByVal todos As Boolean) As List(Of SelectListItem)
    Dim promotores As List(Of SelectListItem) = Nothing
    Dim opromotorBL As promotorBL = Nothing
    Try
      opromotorBL = New promotorBL()
      Dim bactivo As Nullable(Of Boolean) = Nothing
      If activo = True Then
        bactivo = activo
      End If
      promotores = opromotorBL.SelectpromotorRegion(bactivo, Me._OFICINAS, todos).Select(Function(s) New SelectListItem With {.Text = s.nombre.Trim, .Value = s.promotor.ToString}).ToList()
      If opromotorBL.hayErr Then Throw opromotorBL.Err
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      promotores = New List(Of SelectListItem)
    Finally
      If opromotorBL IsNot Nothing Then opromotorBL.Dispose()
      If opromotorBL IsNot Nothing Then opromotorBL = Nothing
    End Try
    Return promotores
  End Function

  Public Function Encriptartexto(ByVal texto As String) As String
    Dim ctexto As String = ""
    Dim crypt As cryptomd5 = Nothing
    Try
      crypt = New cryptomd5()
      ctexto = crypt.Encriptar(texto)
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      ctexto = String.Empty
    Finally
      If crypt IsNot Nothing Then crypt.Dispose()
      If crypt IsNot Nothing Then crypt = Nothing
    End Try
    Return ctexto
  End Function

  Public Function DesEncriptartexto(ByVal texto As String) As String
    Dim ctexto As String = ""
    Dim crypt As cryptomd5 = Nothing
    Try
      crypt = New cryptomd5()
      ctexto = crypt.Desencriptar(ctexto)
    Catch ex As Exception
      BaseController.BitacoraError(ex, Me._USERID, Me._REMOTE_ADDR)
      ctexto = String.Empty
    Finally
      If crypt IsNot Nothing Then crypt.Dispose()
      If crypt IsNot Nothing Then crypt = Nothing
    End Try
    Return ctexto
  End Function

End Class
