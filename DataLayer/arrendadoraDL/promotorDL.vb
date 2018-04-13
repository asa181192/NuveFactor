Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data.Linq.SqlClient
Imports Entidades
Imports Entidades.arrendadora

Namespace arrendadoraDL
  Public Class promotorDL
    Inherits ConnClassDL

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


    Private _oNewPromotorOuBx As promotor
    Public Property oNewPromotorOuBx() As promotor
      Get
        Return Me._oNewPromotorOuBx
      End Get
      Set(value As promotor)
        If Not Me._oNewPromotorOuBx Is Nothing Then Me._oNewPromotorOuBx = Nothing
        Me._oNewPromotorOuBx = New promotor()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oNewPromotorOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oNewPromotoresOuBx As List(Of promotor)
    Public Property oNewPromotoresOuBx() As List(Of promotor)
      Get
        Return Me._oNewPromotoresOuBx
      End Get
      Set(value As List(Of promotor))
        If Not Me._oNewPromotoresOuBx Is Nothing Then Me._oNewPromotoresOuBx = Nothing
        Me._oNewPromotoresOuBx = New List(Of promotor)
        For Each prom As promotor In value
          Dim p As New promotor()
          For Each prop As System.Reflection.PropertyInfo In prom.GetType.GetProperties.ToList()
            prop.SetValue(p, prop.GetValue(prom))
          Next
          Me._oNewPromotoresOuBx.Add(p)
          p = Nothing
        Next
      End Set
    End Property
    Public WriteOnly Property oNewPromotoresOuBx_add() As promotor
      Set(ByVal value As promotor)
        If Me._oNewPromotoresOuBx Is Nothing Then Me._oNewPromotoresOuBx = New List(Of promotor)
        Me._oNewPromotoresOuBx.Add(value)
      End Set
    End Property

    Private _oOriPromotorOuBx As promotor
    Public Property oOriPromotorOuBx() As promotor
      Get
        Return Me._oOriPromotorOuBx
      End Get
      Set(value As promotor)
        If Not Me._oOriPromotorOuBx Is Nothing Then Me._oOriPromotorOuBx = Nothing
        Me._oOriPromotorOuBx = New promotor()
        For Each prop As System.Reflection.PropertyInfo In value.GetType.GetProperties.ToList()
          prop.SetValue(_oOriPromotorOuBx, prop.GetValue(value))
        Next
      End Set
    End Property

    Private _oOriPromotoresOuBx As List(Of promotor)
    Public Property oOriPromotoresOuBx() As List(Of promotor)
      Get
        Return Me._oOriPromotoresOuBx
      End Get
      Set(value As List(Of promotor))
        If Not Me._oOriPromotoresOuBx Is Nothing Then Me._oOriPromotoresOuBx = Nothing
        Me._oOriPromotoresOuBx = New List(Of promotor)
        For Each prom As promotor In value
          Dim p As New promotor()
          For Each prop As System.Reflection.PropertyInfo In prom.GetType.GetProperties.ToList()
            prop.SetValue(p, prop.GetValue(prom))
          Next
          Me._oOriPromotoresOuBx.Add(p)
          p = Nothing
        Next
      End Set
    End Property

    Public Function SelectpromotorRegion(ByVal activo As Boolean?, ByVal oficinas As String, Optional ByVal todos As Boolean = False) As List(Of promotorregion_Result)
      Dim promotorregion As List(Of promotorregion_Result) = Nothing
      Try
        MyBase.Start_context()

        Dim nofifinas = oficinas.Split(",").Select(Function(s) Convert.ToInt32(s.Trim)).ToList()

        If todos And nofifinas.Contains(1) Then
          nofifinas = context.oficinas.Where(Function(w) Not w.nombre.Contains("\") AndAlso w.nombre.Trim.Length > 0).Select(Function(s) Convert.ToInt32(s.oficina_id)).ToList()
        End If

        Dim oVar = From prom As promotor In context.promotors
                    Join regi As region In context.regions On prom.id_regi Equals regi.id_regi
                    Where If(activo IsNot Nothing, activo, prom.activo) = prom.activo AndAlso nofifinas.Contains(prom.oficina)
                    Order By prom.nombre Ascending
                    Select New With {.promotor = prom.promotor_id, .nombre = prom.nombre, .name = regi.name}

        If oVar.Count > 0 Then
          promotorregion = oVar.ToList().Select(Function(s) New promotorregion_Result With {.promotor = s.promotor, .nombre = s.nombre.Trim & "(" & s.promotor.ToString("D6") & ")" & "\ " & s.name.ToUpper.Trim}).ToList()
        Else
          promotorregion = New List(Of promotorregion_Result)
        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        promotorregion = New List(Of promotorregion_Result)
      End Try
      Return promotorregion
    End Function

    Public Function Selectpromotores(ByVal activo As Boolean?) As List(Of promotor)
      Dim opromotors As List(Of promotor) = Nothing
      Dim oVar As System.Linq.IQueryable(Of Entidades.arrendadora.promotor) = Nothing
      Try
        MyBase.Start_context()
        If (activo Is Nothing) Then
          oVar = From prom As promotor In context.promotors
                 Select prom
        Else
          oVar = From prom As promotor In context.promotors
                 Where prom.activo = activo
                 Select prom
        End If

        If oVar.Count > 0 Then
          opromotors = oVar.OrderBy(Function(ord) ord.nombre).ToList()
        Else
          opromotors = New List(Of promotor)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        opromotors = New List(Of promotor)
      End Try
      Return opromotors
    End Function

    Public Function Selectpromotor(ByVal promotor As Integer, Optional ByVal oficina As Integer = 0) As promotor
      Dim oPromotor As promotor = Nothing
      Try
        MyBase.Start_context()
        Dim oVar = From prom As promotor In context.promotors
                   Where prom.promotor_id = promotor AndAlso If(oficina > 0, oficina, prom.oficina) = prom.oficina
                   Select prom

        If (oVar.Count() > 0) Then
          oPromotor = oVar.Single()
        Else
          oPromotor = New promotor()
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oPromotor = New promotor()
      End Try
      Return oPromotor
    End Function

    Public Function SelectPromotorbyNombrebyNumero(ByVal promotor As Decimal?, Optional ByVal nombre As String = Nothing, Optional ByVal oficinas As String = Nothing) As List(Of sp_PromotoresBusquedaXNombre_Result)
      Dim oPromotorporNombre As List(Of sp_PromotoresBusquedaXNombre_Result) = Nothing
      Try
        MyBase.Start_context()
        oPromotorporNombre = context.sp_PromotoresBusquedaXNombre(promotor, nombre, oficinas).ToList
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oPromotorporNombre = New List(Of sp_PromotoresBusquedaXNombre_Result)
      End Try
      Return oPromotorporNombre
    End Function

    Public Function Selectpromotordetalle(Optional ByVal oficinas As String = "") As List(Of sp_PromotoresDetalle_Result)
      Dim opromotordetalle As List(Of sp_PromotoresDetalle_Result) = Nothing
      Try
        MyBase.Start_context()
        opromotordetalle = context.sp_PromotoresDetalle(oficinas).ToList
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        opromotordetalle = New List(Of sp_PromotoresDetalle_Result)
      End Try
      Return opromotordetalle
    End Function

    Public Function Selectpromotorcontratos(ByVal promotor As Integer) As List(Of promotorcontratos_Result)
      Dim oPromotorContratos As List(Of promotorcontratos_Result) = Nothing
      Try
        MyBase.Start_context()
        Dim paso = From c As contrato In context.contratos
                   Join l As cliente In context.clientes On l.cliente_id Equals c.cliente
                   Join p As promotor In context.promotors On p.promotor_id Equals c.promotor
                   Where c.promotor = promotor AndAlso c.linea > 0 AndAlso c.estado <> 1 AndAlso c.estado <> 2
                   Select New With {
                                    .oficina = c.oficina,
                                    .linea = c.linea,
                                    .nombre = l.nombre,
                                    .monto_financiado = c.ejercido - c.paganti,
                                    .plazo = c.plazo,
                                    .fec_inic = c.fec_inic,
                                    .pcompgda = c.pcompgda,
                                    .comision = p.comision,
                                    .valor_del_bien = c.i_gravado + c.i_libre,
                                    .seguro = c.seguro,
                                    .paganti = c.paganti,
                                    .pagdife = c.pagdife
                                   }

        Dim oVar = From var In paso.ToList().Select(Function(s) New promotorcontratos_Result With {
                                                                                              .oficina = s.oficina,
                                                                                              .linea = s.linea,
                                                                                              .contrato = Format(s.oficina, "00") & "-" & Format(s.linea, "000000"),
                                                                                              .nombre = s.nombre.Trim,
                                                                                              .monto_financiado = s.monto_financiado,
                                                                                              .plazo = s.plazo,
                                                                                              .fec_inic = s.fec_inic.ToString("dd/MM/yyyy"),
                                                                                              .pcompgda = s.pcompgda,
                                                                                              .comision = s.comision,
                                                                                              .msgcomision = If(s.pcompgda, "PAGADA", "PENDIENTE"),
                                                                                              .valor_del_bien = String.Format("{0:C2}", s.valor_del_bien),
                                                                                              .seguro = String.Format("{0:C2}", s.seguro),
                                                                                              .paganti = String.Format("{0:C2}", s.paganti),
                                                                                              .pagdife = String.Format("{0:C2}", s.pagdife)
                                                                                            })

        If oVar.Count > 0 Then
          oPromotorContratos = oVar.ToList()
        Else
          oPromotorContratos = New List(Of promotorcontratos_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oPromotorContratos = New List(Of promotorcontratos_Result)
      End Try
      Return oPromotorContratos
    End Function

    Public Function Selectpromotorclientes(ByVal promotor As Integer) As List(Of promotorclientes_Result)
      Dim oPromotorClientes As List(Of promotorclientes_Result) = Nothing
      Try
        MyBase.Start_context()
        Dim paso = From l As cliente In context.clientes
                   Join o As oficina In context.oficinas On l.origen Equals o.oficina_id
                   Join p As promotor In context.promotors On l.promotor Equals p.promotor_id
                   Join r As region In context.regions On p.id_regi Equals r.id_regi
                   Join s As segmento In context.segmentos On p.segmento Equals s.id_segm
                   Where l.promotor = promotor
                   Order By l.nombre
                   Select New With {
                                    .id_regi = r.id_regi,
                                    .regional = r.name,
                                    .id_segm = s.id_segm,
                                    .segmento = s.nombre,
                                    .origen = l.origen,
                                    .oficina = o.nombre,
                                    .cliente = l.cliente_id,
                                    .nombre = l.nombre,
                                    .fec_alta = l.fec_alta,
        .telefono = l.telefono
                                   }

        Dim oVar = From var In paso.ToList().Select(Function(s) New promotorclientes_Result With {
                                                                                              .id_regi = s.id_regi,
                                                                                              .regional = s.regional,
                                                                                              .id_segm = s.id_segm,
                                                                                              .segmento = s.segmento,
                                                                                              .origen = s.origen,
                                                                                              .oficina = s.oficina,
                                                                                              .cliente = s.cliente,
                                                                                              .nombre = s.nombre.Trim,
                                                                                              .fec_alta = s.fec_alta.ToString("dd/MM/yyyy"),
                                                                                              .telefono = s.telefono.Trim
                                                                                            })

        If oVar.Count > 0 Then
          oPromotorClientes = oVar.ToList()
        Else
          oPromotorClientes = New List(Of promotorclientes_Result)
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oPromotorClientes = New List(Of promotorclientes_Result)
      End Try
      Return oPromotorClientes
    End Function

    Public Function GetColocxM(ByVal ano As Integer, ByVal mes As Integer, Optional ByVal oficina As Integer? = Nothing, Optional ByVal modalidad As Integer? = Nothing, Optional ByVal oficinas As String = "1") As List(Of sp_rpt_colocxm_Result)
      Dim oColocxm As List(Of sp_rpt_colocxm_Result) = Nothing
      Try
        MyBase.Start_context()
        If oficina <= 0 Then oficina = Nothing
        If modalidad <= 0 Then modalidad = Nothing
        oColocxm = context.sp_rpt_colocxm(ano, mes, oficina, modalidad, oficinas).ToList
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oColocxm = New List(Of sp_rpt_colocxm_Result)
      End Try
      Return oColocxm
    End Function

    Public Function ExisteRFC(ByVal RFC As String, Optional ByVal oficinas As String = "") As Boolean
      Dim bExiste As Boolean = False
      Try
        MyBase.Start_context()
        If oficinas.Trim.Length > 0 Then
          Dim nOficinas = oficinas.Trim.Split(",").Select(Function(s) CType(s.Trim, Nullable(Of Integer))).ToList()
          Dim oVar = From prom As Entidades.arrendadora.promotor In context.promotors
                     Where prom.rfc = RFC AndAlso nOficinas.Contains(prom.oficina)
                     Select prom

          bExiste = oVar.Count > 0
        Else
          Dim oVar = From prom As Entidades.arrendadora.promotor In context.promotors
                     Where prom.rfc = RFC
                     Select prom

          bExiste = oVar.Count > 0
        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bExiste = False
      End Try
      Return bExiste
    End Function

    Public Function getSaldoInsolutoPromotor(ByVal promotor As Integer, Optional SumaIvaInsoluto As Boolean = False) As Decimal
      Dim decSaldoInsoluto As Decimal = 0
      Try
        MyBase.Start_context()
        Dim oVar = context.getSaldoInsolutoPromotor(promotor, SumaIvaInsoluto)
        decSaldoInsoluto = IIf(oVar Is Nothing, 0, oVar)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        decSaldoInsoluto = 0
      End Try
      Return decSaldoInsoluto
    End Function

    Public Function SelectPromotorAdeudoClientes(ByVal promotor As Integer) As List(Of sp_AdeudoClientesXPromotor_Result)
      Dim oPromotorLst As List(Of sp_AdeudoClientesXPromotor_Result) = Nothing
      Try
        MyBase.Start_context()
        oPromotorLst = context.sp_AdeudoClientesXPromotor(promotor).ToList

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        oPromotorLst = New List(Of sp_AdeudoClientesXPromotor_Result)
      End Try
      Return oPromotorLst
    End Function

    Public Function Submit(ByRef promotor As promotor, ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      Try
        Dim ipromotor = promotor.promotor_id
        MyBase.Start_context()
        Dim oPromotor = From p As promotor In context.promotors
                        Where p.promotor_id = ipromotor _
                        AndAlso p.promotor_id > 0
                        Select p

        oNewPromotorOuBx = promotor

        If (oPromotor.Count() > 0) Then
          Me.oOriPromotorOuBx = oPromotor.Single()
          For Each prop In promotor.GetType.GetProperties.ToList
            prop.SetValue(oPromotor.Single(), prop.GetValue(promotor))
          Next
          context.SaveChanges()
          bTrans = True
        Else
          context.sp_Nuevo_Promotor(oficina, promotor.promotor_id)
          oNewPromotorOuBx.promotor_id = promotor.promotor_id
          context.promotors.Add(promotor)
          context.SaveChanges()
          bTrans = True
        End If

      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Function Submit(ByRef promotores As List(Of promotor), ByRef oficina As Integer) As Boolean
      Dim bTrans As Boolean = False
      Dim ioficina = oficina
      Try
        MyBase.Start_context()
        Dim oLlaves = promotores.Select(Function(s) s.promotor_id).ToList()
        Dim oPromotores = From p As promotor In context.promotors
                          Where oLlaves.Contains(p.promotor_id) _
                          AndAlso p.promotor_id > 0
                          Select p

        If (oPromotores.Count() > 0) Then
          If Not Me._oNewPromotoresOuBx Is Nothing Then Me._oNewPromotoresOuBx = Nothing
          Me.oOriPromotoresOuBx = oPromotores.ToList()

          Dim props = promotores.ElementAt(0).GetType.GetProperties()
          Dim oInsert As New List(Of promotor)          

          For Each oUpdate As promotor In oPromotores.ToList()
            Dim oprom = promotores.Where(Function(w) w.promotor_id = oUpdate.promotor_id)
            If oprom.Count() > 0 Then
              For Each oprop As System.Reflection.PropertyInfo In props
                oprop.SetValue(oUpdate, oprop.GetValue(oprom.Single()))
              Next
            Else
              oInsert.Add(oUpdate)
            End If
          Next

          If (oInsert.Count() > 0) Then
            For Each oprom In oInsert.ToList()
              context.sp_Nuevo_Promotor(ioficina, oprom.promotor_id)
              Me.oNewPromotoresOuBx_add = oprom
            Next
            context.promotors.AddRange(DirectCast(oInsert.ToList(), IEnumerable(Of promotor)))
          End If

          context.SaveChanges()
          bTrans = True
        Else
          For Each oNewProm As promotor In promotores
            context.sp_Nuevo_Promotor(ioficina, oNewProm.promotor_id)
          Next
          Me.oNewPromotoresOuBx = promotores
          context.promotors.AddRange(DirectCast(promotores, IEnumerable(Of promotor)))
          context.SaveChanges()
          bTrans = True

        End If
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = New Exception("Error datos", ex)
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overloads Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal changes As String) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Metodos.GeneraOutbox(oficina, archivo, tag, llave, changes)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = ex
        bTrans = False
      End Try
      Return bTrans
    End Function

    Public Overloads Function GeneraOutbox(ByVal oficina As Integer, ByVal archivo As String, ByVal tag As String, ByVal llave As String, ByVal chageslst As List(Of String)) As Boolean
      Dim bTrans As Boolean = False
      Try
        bTrans = Metodos.GeneraOutbox(oficina, archivo, tag, llave, chageslst)
      Catch ex As Exception
        Me.hayErr = True
        Me.Err = ex
        bTrans = False
      End Try
      Return bTrans
    End Function

  End Class
End Namespace