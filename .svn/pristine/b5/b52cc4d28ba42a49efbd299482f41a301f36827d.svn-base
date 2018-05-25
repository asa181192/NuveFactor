Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports nuve.Helpers
Imports System.IO
Imports System.Runtime.Serialization.Json
Imports System.Globalization
Imports Negocio.arrendadoraBL
Imports Entidades
Imports Entidades.arrendadora

Public Class ClientesController
  Inherits BaseController

  <CustomAuthorize()> _
  <HttpGet()> _
  Public Function consulta(ByVal cliente As Integer?, ByVal returnUrl As String) As ActionResult
    ViewData("ReturnUrl") = returnUrl
    Dim oclienteBL As clienteBL = Nothing
    Dim ocliente As cliente = Nothing
    Dim osubactivBL As subactivBL = Nothing
    Dim osubactiv As subactiv = Nothing
    Dim oriesgoBL As riesgoBL = Nothing
    Dim oriesgo As riesgo = Nothing
    Dim opromotorBL As promotorBL = Nothing
    Dim opromotor As promotor = Nothing
        Dim model As New clientesModels.cliente
    Try
      oclienteBL = New clienteBL()
      ocliente = oclienteBL.Selectcliente(If(cliente IsNot Nothing, cliente.Value, 0))
      If oclienteBL.hayErr Then Throw oclienteBL.Err

      model.OFICINAS = CType(Session("OFICINAS"), String)
      model.REMOTE_ADDR = Request.ServerVariables("REMOTE_ADDR")
      model.USERID = CType(Session("USERID"), String)
      model.enabledalloffice = False
      model.promotoractivo = True

      Negocio.origen_destino(ocliente, model)

      If cliente Is Nothing Then
        ViewData("lblsuperior") = "CLIENTE NUEVO"
      Else
        ViewData("lblsuperior") = String.Format("CLIENTE - ({0}) {1}", model.cliente_id.ToString.PadLeft(6, "0"), model.nombre.Trim())
      End If

      osubactivBL = New subactivBL()
      osubactiv = osubactivBL.Selectsubactiv(ocliente.subactiv.Value)
      If osubactivBL.hayErr Then Throw osubactivBL.Err

      oriesgoBL = New riesgoBL()
      oriesgo = oriesgoBL.Selectriesgo(ocliente.riesgo)
      If oriesgoBL.hayErr Then Throw oriesgoBL.Err

      opromotorBL = New promotorBL()
      opromotor = opromotorBL.Selectpromotor(ocliente.promotor, ocliente.origen)
      If opromotorBL.hayErr Then Throw opromotorBL.Err

      model.subactivtxt = osubactiv.sdescrip.Trim & "/" & osubactiv.descrip.Trim
      model.riesgotxt = oriesgo.nombre.Trim
      model.promotortxt = opromotor.nombre.Trim

      cargapersonas(model, "proveedores")
      cargapersonas(model, "propietarios")
      cargapersonas(model, "padre")
      cargapersonas(model, "madre")
      cargapersonas(model, "hijos")
      cargapersonas(model, "conyugue")
      cargapersonas(model, "hermanos")
      cargapersonas(model, "asimilado")

    Catch ex As Exception
      BitacoraError(ex, CType(Session("USERID"), String), Request.ServerVariables("REMOTE_ADDR"))
      ModelState.AddModelError("", "Ocurrio un error")
      Return View(model)
    Finally
      If oclienteBL IsNot Nothing Then oclienteBL.Dispose()
      If oclienteBL IsNot Nothing Then oclienteBL = Nothing
      If ocliente IsNot Nothing Then ocliente = Nothing
      If osubactivBL IsNot Nothing Then osubactivBL.Dispose()
      If osubactivBL IsNot Nothing Then osubactivBL = Nothing
      If osubactiv IsNot Nothing Then osubactiv = Nothing
      If oriesgoBL IsNot Nothing Then oriesgoBL.Dispose()
      If oriesgoBL IsNot Nothing Then oriesgoBL = Nothing
      If oriesgo IsNot Nothing Then oriesgo = Nothing
      If opromotorBL IsNot Nothing Then opromotorBL.Dispose()
      If opromotorBL IsNot Nothing Then opromotorBL = Nothing
      If opromotor IsNot Nothing Then opromotor = Nothing
    End Try
    Return View(model)
  End Function

  Private Sub cargapersonas(ByRef model As clientesModels.cliente, ByVal para As String)
    Dim oclienteBL As clienteBL = Nothing
    Dim ocliente As cliente = Nothing
    Dim oclientes As List(Of cliente) = Nothing
    Dim opersoBL As persoBL = Nothing
    Dim opersos As List(Of perso) = Nothing
    Dim l_err As Exception = Nothing
    Try
      oclienteBL = New clienteBL()

      If (para = "proveedores") Then
        If String.IsNullOrEmpty(model.proveedores.Trim) Then
          oclientes = New List(Of cliente)
        Else
          oclientes = oclienteBL.Selectcliente(model.proveedores.Split(vbCrLf).Where(Function(w) IsNumeric(w.Trim)).Select(Function(s) CType(s.Trim, Decimal)).ToList)
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If oclientes.Count > 0 Then
          model.persona_proveedores = oclientes.Select(Function(s) New clientesModels.persona With {.cliente = s.cliente_id, .nombre = s.nombre, .rfc = s.rfc, .accionista = s.accionista, .representante = s.representante, .administrador = s.administrador, .pfisica = s.pfisica, .ocupacion = s.ocupacion, .telefono = s.telefono, .ar_feccon = New Date(1900, 1, 1)}).ToList
        Else
          model.persona_proveedores = New List(Of clientesModels.persona)
        End If

      ElseIf (para = "propietarios") Then
        If String.IsNullOrEmpty(model.propietarios.Trim) Then
          oclientes = New List(Of cliente)
        Else
          oclientes = oclienteBL.Selectcliente(model.propietarios.Split(vbCrLf).Where(Function(w) IsNumeric(w.Trim)).Select(Function(s) CType(s.Trim, Decimal)).ToList)
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If oclientes.Count > 0 Then
          model.persona_propietarios = oclientes.Select(Function(s) New clientesModels.persona With {.cliente = s.cliente_id, .nombre = s.nombre, .rfc = s.rfc, .accionista = s.accionista, .representante = s.representante, .administrador = s.administrador, .pfisica = s.pfisica, .ocupacion = s.ocupacion, .telefono = s.telefono, .ar_feccon = New Date(1900, 1, 1)}).ToList
        Else
          model.persona_propietarios = New List(Of clientesModels.persona)
        End If
        If model.persona_propietarios.Count > 0 Then
          opersoBL = New persoBL()
          opersos = opersoBL.Selectpersos(model.persona_propietarios.Select(Function(s) s.cliente).ToList())
          If opersoBL.hayErr Then Throw opersoBL.Err
          If opersos.Count > 0 Then
            For Each pers In model.persona_propietarios
              If opersos.Where(Function(w) w.cliente = pers.cliente).Count > 0 Then
                pers.ar_feccon = opersos.Where(Function(w) w.cliente = pers.cliente).Single().ar_feccon
              End If
            Next
          End If
        End If

      ElseIf (para = "padre") Then
        If String.IsNullOrEmpty(model.padre.Trim) Then
          ocliente = New cliente With {.cliente_id = 0}
        Else
          ocliente = oclienteBL.Selectcliente(CType(model.padre.Trim, Integer))
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If ocliente.cliente_id > 0 Then
          model.persona_padre = New clientesModels.persona With {.cliente = ocliente.cliente_id, .nombre = ocliente.nombre, .rfc = ocliente.rfc, .accionista = ocliente.accionista, .representante = ocliente.representante, .administrador = ocliente.administrador, .pfisica = ocliente.pfisica, .ocupacion = ocliente.ocupacion, .telefono = ocliente.telefono, .ar_feccon = New Date(1900, 1, 1)}
        Else
          model.persona_padre = New clientesModels.persona With {.cliente = 0, .nombre = "", .rfc = "", .accionista = False, .representante = False, .administrador = False}
        End If

      ElseIf (para = "madre") Then
        If String.IsNullOrEmpty(model.madre.Trim) Then
          ocliente = New cliente With {.cliente_id = 0}
        Else
          ocliente = oclienteBL.Selectcliente(CType(model.madre.Trim, Integer))
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If ocliente.cliente_id > 0 Then
          model.persona_madre = New clientesModels.persona With {.cliente = ocliente.cliente_id, .nombre = ocliente.nombre, .rfc = ocliente.rfc, .accionista = ocliente.accionista, .representante = ocliente.representante, .administrador = ocliente.administrador, .pfisica = ocliente.pfisica, .ocupacion = ocliente.ocupacion, .telefono = ocliente.telefono, .ar_feccon = New Date(1900, 1, 1)}
        Else
          model.persona_madre = New clientesModels.persona With {.cliente = 0, .nombre = "", .rfc = "", .accionista = False, .representante = False, .administrador = False}
        End If

      ElseIf (para = "hijos") Then
        If String.IsNullOrEmpty(model.hijos.Trim) Then
          oclientes = New List(Of cliente)
        Else
          oclientes = oclienteBL.Selectcliente(model.hijos.Split(vbCrLf).Where(Function(w) IsNumeric(w.Trim)).Select(Function(s) CType(s.Trim, Decimal)).ToList)
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If oclientes.Count > 0 Then
          model.persona_hijos = oclientes.Select(Function(s) New clientesModels.persona With {.cliente = s.cliente_id, .nombre = s.nombre, .rfc = s.rfc, .accionista = s.accionista, .representante = s.representante, .administrador = s.administrador, .pfisica = s.pfisica, .ocupacion = s.ocupacion, .telefono = s.telefono, .ar_feccon = New Date(1900, 1, 1)}).ToList
        Else
          model.persona_hijos = New List(Of clientesModels.persona)
        End If

      ElseIf (para = "conyugue") Then
        If String.IsNullOrEmpty(model.conyugue.Trim) Then
          ocliente = New cliente With {.cliente_id = 0}
        Else
          ocliente = oclienteBL.Selectcliente(CType(model.conyugue.Trim, Integer))
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If ocliente.cliente_id > 0 Then
          model.persona_conyugue = New clientesModels.persona With {.cliente = ocliente.cliente_id, .nombre = ocliente.nombre, .rfc = ocliente.rfc, .accionista = ocliente.accionista, .representante = ocliente.representante, .administrador = ocliente.administrador, .pfisica = ocliente.pfisica, .ocupacion = ocliente.ocupacion, .telefono = ocliente.telefono, .ar_feccon = New Date(1900, 1, 1)}
        Else
          model.persona_conyugue = New clientesModels.persona With {.cliente = 0, .nombre = "", .rfc = "", .accionista = False, .representante = False, .administrador = False}
        End If

      ElseIf (para = "hermanos") Then
        If String.IsNullOrEmpty(model.hermanos.Trim) Then
          oclientes = New List(Of cliente)
        Else
          oclientes = oclienteBL.Selectcliente(model.hermanos.Split(vbCrLf).Where(Function(w) IsNumeric(w.Trim)).Select(Function(s) CType(s.Trim, Decimal)).ToList)
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If oclientes.Count > 0 Then
          model.persona_hermanos = oclientes.Select(Function(s) New clientesModels.persona With {.cliente = s.cliente_id, .nombre = s.nombre, .rfc = s.rfc, .accionista = s.accionista, .representante = s.representante, .administrador = s.administrador, .pfisica = s.pfisica, .ocupacion = s.ocupacion, .telefono = s.telefono, .ar_feccon = New Date(1900, 1, 1)}).ToList
        Else
          model.persona_hermanos = New List(Of clientesModels.persona)
        End If

      ElseIf (para = "asimilado") Then
        If String.IsNullOrEmpty(model.pepasimilado.Trim) Then
          ocliente = New cliente With {.cliente_id = 0}
        Else
          ocliente = oclienteBL.Selectcliente(CType(model.pepasimilado.Trim, Integer))
        End If
        If oclienteBL.hayErr Then Throw oclienteBL.Err
        If ocliente.cliente_id > 0 Then
          model.persona_asimilado = New clientesModels.persona With {.cliente = ocliente.cliente_id, .nombre = ocliente.nombre, .rfc = ocliente.rfc, .accionista = ocliente.accionista, .representante = ocliente.representante, .administrador = ocliente.administrador, .pfisica = ocliente.pfisica, .ocupacion = ocliente.ocupacion, .telefono = ocliente.telefono, .ar_feccon = New Date(1900, 1, 1)}
        Else
          model.persona_asimilado = New clientesModels.persona With {.cliente = 0, .nombre = "", .rfc = "", .accionista = False, .representante = False, .administrador = False, .pfisica = False, .ocupacion = "", .telefono = "", .ar_feccon = New Date(1900, 1, 1)}
        End If

      End If

    Catch ex As Exception
      l_err = New Exception(String.Format("Error: {0}", ex.Message), ex)
    Finally
      If oclienteBL IsNot Nothing Then oclienteBL.Dispose()
      If oclienteBL IsNot Nothing Then oclienteBL = Nothing
      If ocliente IsNot Nothing Then ocliente = Nothing
      If oclientes IsNot Nothing Then oclientes = Nothing
      If opersoBL IsNot Nothing Then opersoBL.Dispose()
      If opersoBL IsNot Nothing Then opersoBL = Nothing
      If opersos IsNot Nothing Then opersos = Nothing
      If l_err IsNot Nothing Then Throw l_err
    End Try
  End Sub

  <HttpGet()> _
  Public Function consulta_cargacolonias(ByVal cp As Integer) As JsonResult
        Dim fc As New funcionescontroles()
    fc.OFICINAS = CType(Session("OFICINAS"), String)
    fc.REMOTE_ADDR = Request.ServerVariables("REMOTE_ADDR")
    fc.USERID = CType(Session("USERID"), String)
    Dim sreturn = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(fc.cargaColonias(cp.ToString))
    Return Json(sreturn, JsonRequestBehavior.AllowGet)
  End Function

  <HttpGet()> _
  Public Function consulta_cargamunicipioestado(ByVal CP As String, ByVal id_unico As String) As JsonResult
    Dim omunicipioestado As clientesModels.municipioestado = Nothing
    Dim osepomexBL As sepomexBL = Nothing
    Dim osepomexlst As List(Of sepomex) = Nothing
    Dim sreturn As String = String.Empty
    Try
      omunicipioestado = New clientesModels.municipioestado
      osepomexBL = New sepomexBL()
      osepomexlst = osepomexBL.Selectsepomex(Convert.ToDouble(CP.Trim))
      If osepomexBL.hayErr Then Throw osepomexBL.Err
      If Convert.ToInt64(id_unico) = 0 Then
        omunicipioestado.estado = ""
        omunicipioestado.municipio = ""
      Else
        omunicipioestado.estado = osepomexlst.Where(Function(w) w.id_unico = Convert.ToInt64(id_unico.Trim)).Select(Function(s) s.d_estado).First()
        omunicipioestado.municipio = osepomexlst.Where(Function(w) w.id_unico = Convert.ToInt64(id_unico.Trim)).Select(Function(s) s.D_mnpio).First()
      End If      
    Catch ex As Exception
      BitacoraError(ex, CType(Session("USERID"), String), Request.ServerVariables("REMOTE_ADDR"))
      omunicipioestado = New clientesModels.municipioestado()
    Finally
      If osepomexBL IsNot Nothing Then osepomexBL.Dispose()
      If osepomexBL IsNot Nothing Then osepomexBL = Nothing
      If osepomexlst IsNot Nothing Then osepomexlst = Nothing
    End Try
    sreturn = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(omunicipioestado)
    Return Json(sreturn, JsonRequestBehavior.AllowGet)
  End Function

  <HttpGet()> _
  Public Function consulta_cargariesgos() As JsonResult
        Dim fc As New funcionescontroles()
    fc.OFICINAS = CType(Session("OFICINAS"), String)
    fc.REMOTE_ADDR = Request.ServerVariables("REMOTE_ADDR")
    fc.USERID = CType(Session("USERID"), String)
    Dim sreturn = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(fc.cargaGruposRiesgo())
    Return Json(sreturn, JsonRequestBehavior.AllowGet)
  End Function

  <HttpGet()> _
  Public Function consulta_cargasubactividades() As JsonResult
        Dim fc As New funcionescontroles()
    fc.OFICINAS = CType(Session("OFICINAS"), String)
    fc.REMOTE_ADDR = Request.ServerVariables("REMOTE_ADDR")
    fc.USERID = CType(Session("USERID"), String)
    Dim sreturn = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(fc.cargaSubActividades())
    Return Json(sreturn, JsonRequestBehavior.AllowGet)
  End Function

  <HttpGet()> _
  Public Function consulta_cargapromotores(ByVal promotoractivo As Boolean) As JsonResult
        Dim fc As New funcionescontroles()
    fc.OFICINAS = CType(Session("OFICINAS"), String)
    fc.REMOTE_ADDR = Request.ServerVariables("REMOTE_ADDR")
    fc.USERID = CType(Session("USERID"), String)
    Dim sreturn = New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(fc.cargaPromotores(promotoractivo, False))
    Return Json(sreturn, JsonRequestBehavior.AllowGet)
  End Function

  <CustomAuthorize()> _
  <HttpPost()> _
  <ValidateAntiForgeryToken()> _
  Public Function consulta(ByVal model As clientesModels.cliente, ByVal returnUrl As String) As ActionResult
    ViewData("ReturnUrl") = returnUrl
    model.OFICINAS = CType(Session("OFICINAS"), String)
    model.REMOTE_ADDR = Request.ServerVariables("REMOTE_ADDR")
    model.USERID = CType(Session("USERID"), String)
    model.enabledalloffice = False
    model.promotoractivo = True
    Return View(model)
  End Function

End Class