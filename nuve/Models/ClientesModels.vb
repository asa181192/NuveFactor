Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports Entidades
Imports Entidades.arrendadora
Imports Negocio
Imports Negocio.arrendadoraBL

Namespace clientesModels  
  Public Class cliente
    Inherits Entidades.arrendadora.cliente

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

    <Display(Name:="Aval")> _
    Public Overloads Property aval() As Boolean

    <Display(Name:="Accinista")> _
    Public Overloads Property accionista() As Boolean

    <Display(Name:="Persona Física")> _
    Public Property rbpfisica() As Boolean
      Get
        Return MyBase.pfisica
      End Get
      Set(value As Boolean)
        MyBase.pfisica = value
      End Set
    End Property

    <Display(Name:="Persona Moral")> _
    Public Property rbpmoral() As Boolean
      Get
        Return Not MyBase.pfisica
      End Get
      Set(value As Boolean)
        MyBase.pfisica = Not value
      End Set
    End Property

    <Display(Name:="Actividad Empresarial")> _
    Public Overloads Property pfempre() As Boolean

    <Required()> _
    <DataType(DataType.Date)> _
    <Display(Name:="Cliente desde")> _
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)> _
    Public Overloads Property cltedesde As Date

    <Display(Name:="Primer Nombre")> _
    <StringLength(8000)> _
    Public Overloads Property n() As String

    <Display(Name:="Segundo Nombre")> _
    <StringLength(8000)> _
    Public Overloads Property s() As String

    <Display(Name:="Apellido Paterno")> _
    <StringLength(8000)> _
    Public Overloads Property p() As String

    <Display(Name:="Apellido Materno")> _
    <StringLength(8000)> _
    Public Overloads Property m() As String

    <Display(Name:="Fideicomiso")> _
    Public Overloads Property pmfideicomiso() As Boolean

    <Display(Name:="Nombre")> _
    <StringLength(150)> _
    Public Overloads Property nombre() As String

    <Display(Name:="Sociedad")> _
    <StringLength(200)> _
    Public Overloads Property sociedad() As String

    <Display(Name:="Tipo Sociedad")> _
    Public Overloads Property tiposociedad() As Integer

    Public ReadOnly Property tiposSociedad() As List(Of SelectListItem)
      Get
                Dim fc As New funcionescontroles()
        fc.OFICINAS = Me._OFICINAS
        fc.REMOTE_ADDR = Me._REMOTE_ADDR
        fc.USERID = Me._USERID
        Return fc.TiposSociedad()
      End Get
    End Property

    <Display(Name:="R.F.C.")> _
    <StringLength(13)> _
    <RegularExpression("^([a-zñA-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([a-zA-Z\d]{3})?$", ErrorMessage:="El formato es incorrecto")> _
    Public Overloads Property rfc() As String

    <Display(Name:="C.U.R.P.")> _
    <StringLength(18)> _
    <RegularExpression("^([A-Z][A,E,I,O,U,X][A-Z]{2})(\d{2})((01|03|05|07|08|10|12)(0[1-9]|[12]\d|3[01])|02(0[1-9]|[12]\d)|(04|06|09|11)(0[1-9]|[12]\d|30))([M,H])(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)([B,C,D,F,G,H,J,K,L,M,N,Ñ,P,Q,R,S,T,V,W,X,Y,Z]{3})([0-9,A-Z][0-9])$", ErrorMessage:="El formato es incorrecto")> _
    Public Overloads Property curp() As String

    <Display(Name:="Riesgo PLD:")> _
    Public Overloads Property Riesgopld() As Integer

    <Display(Name:="Cliente BX+")> _
    Public Overloads Property nbrclientecs() As Integer

    <Display(Name:="Domiclio")> _
    Public Overloads Property domicilio() As String

    <Display(Name:="Colonia")> _
    Public Overloads Property colonia() As String

    <Display(Name:="C.P.")> _
    Public Overloads Property cp() As Integer

    <Display(Name:="Municipio")> _
    Public Overloads Property municipio() As String

    <Display(Name:="Estado")> _
    Public Overloads Property estado() As String

    <Display(Name:="Teléfonos")> _
    Public Overloads Property telefono() As String

    <Display(Name:="E-Mail")> _
    <RegularExpression("^[\w-]+(?:\.[\w-]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage:="El formato es incorrecto")> _
    Public Overloads Property email() As String

    <Display(Name:="Núm. Ext.")> _
    Public Overloads Property numext() As String

    <Display(Name:="Núm. Interior")> _
    Public Overloads Property numint() As String

    <Display(Name:="Calle")> _
    Public Overloads Property calle() As String

    <Display(Name:="Contactos")> _
    Public Overloads Property contactos() As String

    <Display(Name:="Oficina")> _
    Public Overloads Property origen() As Decimal

    Public Property enabledalloffice() As Boolean

    Public ReadOnly Property origenes() As List(Of SelectListItem)
      Get
                Dim fc As New funcionescontroles()
        fc.OFICINAS = Me._OFICINAS
        fc.REMOTE_ADDR = Me._REMOTE_ADDR
        fc.USERID = Me._USERID
        Return fc.cargaOficinas(Me.enabledalloffice)
      End Get
    End Property

    Public Property promotoractivo() As Boolean

    <Display(Name:="Promotor")> _
    Public Overloads Property promotor() As Integer

    Public Property promotortxt() As String

    <Display(Name:="Grupo de Riesgo")> _
    Public Overloads Property riesgo() As Decimal

    Public Property riesgotxt() As String

    <Display(Name:="Actividad")> _
    Public Overloads Property actividad() As Decimal

    Public ReadOnly Property actividades() As List(Of SelectListItem)
      Get
                Dim fc As New funcionescontroles()
        fc.OFICINAS = Me._OFICINAS
        fc.REMOTE_ADDR = Me._REMOTE_ADDR
        fc.USERID = Me._USERID
        Return fc.cargaActividades()
      End Get
    End Property

    <Display(Name:="No. empleados")> _
    Public Overloads Property numemp() As Decimal

    Public Property subactivtxt() As String

    <Display(Name:="Sub-Actividad")> _
    Public Overloads Property subactiv() As Nullable(Of Decimal)

    <Display(Name:="Sector económico")> _
    Public Overloads Property sececo() As Integer

    Public ReadOnly Property sececos() As List(Of SelectListItem)
      Get
                Dim fc As New funcionescontroles
        fc.OFICINAS = Me._OFICINAS
        fc.REMOTE_ADDR = Me._REMOTE_ADDR
        fc.USERID = Me._USERID
        Return fc.cargaSectoresEconomicos()
      End Get
    End Property

    <Display(Name:="Cuenta")> _
    Public Overloads Property nbrchequera() As String

    <Display(Name:="Pago domiciliado")> _
    Public Overloads Property pagodomici() As Boolean

    <Display(Name:="Cuenta")> _
    Public Overloads Property metpagocta() As String

    <Display(Name:="Método de Pago")> _
    Public Overloads Property metpago() As Integer

    Public ReadOnly Property metodospago() As List(Of SelectListItem)
      Get
                Dim fc As New funcionescontroles
        fc.OFICINAS = Me._OFICINAS
        fc.REMOTE_ADDR = Me._REMOTE_ADDR
        fc.USERID = Me._USERID
        Return fc.cargaMetodosPago()
      End Get
    End Property

    <Display(Name:="País de origen")> _
    Public Overloads Property pais() As Integer

    Public ReadOnly Property paises() As List(Of SelectListItem)
      Get
                Dim fc As New funcionescontroles()
        fc.OFICINAS = Me._OFICINAS
        fc.REMOTE_ADDR = Me._REMOTE_ADDR
        fc.USERID = Me._USERID
        Return fc.cargaPaises()
      End Get
    End Property

    <Display(Name:="Nacionalidad")> _
    Public Overloads Property pais_actual() As Integer

    <Display(Name:="Alto riesgo")> _
    Public Overloads Property altoriesgo() As Boolean

    <Display(Name:="Cliente relacionado")> _
    Public Overloads Property relacion() As Boolean

    <Display(Name:="Ocupación")> _
    Public Overloads Property ocupacion() As String

    <Display(Name:="Serie FIEL")> _
    Public Overloads Property seriefiel() As String

    <Display(Name:="Tiene proveedor")> _
    Public Overloads Property tieneproveedor() As Boolean

    Public Property esModal() As Boolean
    Public Property bloqueoVariables() As Boolean
    Public Property bloqueoInfoContable() As Boolean

    Public Property persona_proveedores() As List(Of persona)
    Public Property persona_propietarios() As List(Of persona)
    Public Property persona_padre() As persona
    Public Property persona_madre() As persona
    Public Property persona_hijos() As List(Of persona)
    Public Property persona_conyugue() As persona
    Public Property persona_hermanos() As List(Of persona)
    Public Property persona_asimilado() As persona

    <Display(Name:="Relación")> _
    Public Overloads Property peprelacion() As String

    <Display(Name:="¿Es propietario reál de los recursos?")> _
    Public Overloads Property espropietarioreal() As Boolean

    <Display(Name:="Politicamente expuesto")> _
    Public Overloads Property pexpuesto() As Boolean

    <Display(Name:="Puesto público")> _
    Public Overloads Property puestopublico() As String

    <Display(Name:="Trabajo")> _
    Public Overloads Property trabajo() As String

    <Display(Name:="Es expuesto asimilado")> _
    Public Overloads Property pexpuestoasimilado() As Boolean

    <DataType(DataType.Date)> _
    <Display(Name:="Fecha de balance")> _
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)> _
    Public Overloads Property fecbalance() As Date?

    <DataType(DataType.Date)> _
    <Display(Name:="Fecha Estado de Resultados")> _
    <DisplayFormat(DataFormatString:="{0:dd-MM-yyyy}", ApplyFormatInEditMode:=True)> _
    Public Overloads Property fec_edores() As Date?

    <Display(Name:="Ingresos anuales brutos")> _
    Public Overloads Property ingresos() As Decimal?

    <Display(Name:="Activo")> _
    Public Overloads Property activo() As Decimal?

    <Display(Name:="Pasivo")> _
    Public Overloads Property pasivo() As Decimal?

    <Display(Name:="Capital")> _
    Public Overloads Property capital() As Decimal?

    <Display(Name:="Ingresos anuales netos")> _
    Public Overloads Property ingre_neto() As Decimal?

  End Class

  Public Class persona
    Public Property cliente() As Integer
    Public Property nombre() As String
    Public Property rfc() As String
    Public Property accionista() As Boolean
    Public Property representante() As Boolean
    Public Property administrador() As Boolean
    Public Property pfisica() As Boolean
    Public Property ocupacion() As String
    Public Property telefono() As String
    Public Property ar_feccon() As Date
  End Class

  Public Class municipioestado
    Public Property municipio() As String
    Public Property estado() As String
  End Class
End Namespace