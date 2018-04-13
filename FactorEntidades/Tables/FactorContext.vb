Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class FactorContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=FactorContext")
    End Sub

    Public Overridable Property actividad As DbSet(Of actividad)
    Public Overridable Property adeudos As DbSet(Of adeudos)
    Public Overridable Property apoderados As DbSet(Of apoderados)
    Public Overridable Property aseguradora As DbSet(Of aseguradora)
    Public Overridable Property bancos As DbSet(Of bancos)
    Public Overridable Property baskets As DbSet(Of baskets)
    Public Overridable Property ccosto As DbSet(Of ccosto)
    Public Overridable Property cesiones As DbSet(Of cesiones)
    Public Overridable Property ciudades As DbSet(Of ciudades)
    Public Overridable Property clientes As DbSet(Of clientes)
    Public Overridable Property comprador As DbSet(Of comprador)
    Public Overridable Property contratos As DbSet(Of contratos)
    Public Overridable Property ctaprove As DbSet(Of ctaprove)
    Public Overridable Property ctasaldos As DbSet(Of ctasaldos)
    Public Overridable Property cuentas As DbSet(Of cuentas)
    Public Overridable Property depositos As DbSet(Of depositos)
    Public Overridable Property detalle As DbSet(Of detalle)
    Public Overridable Property dev_iv As DbSet(Of dev_iv)
    Public Overridable Property dev_moratorio As DbSet(Of dev_moratorio)
    Public Overridable Property dev_mvencido As DbSet(Of dev_mvencido)
    Public Overridable Property devengue As DbSet(Of devengue)
    Public Overridable Property doctos As DbSet(Of doctos)
    Public Overridable Property edoseguro As DbSet(Of edoseguro)
    Public Overridable Property estadosdemexico As DbSet(Of estadosdemexico)
    Public Overridable Property estudios As DbSet(Of estudios)
    Public Overridable Property evento As DbSet(Of evento)
    Public Overridable Property fiscalpf As DbSet(Of fiscalpf)
    Public Overridable Property foliosat As DbSet(Of foliosat)
    Public Overridable Property garantia As DbSet(Of garantia)
    Public Overridable Property grupos As DbSet(Of grupos)
    Public Overridable Property lavado As DbSet(Of lavado)
    Public Overridable Property movcuentas As DbSet(Of movcuentas)
    Public Overridable Property operaciones As DbSet(Of operaciones)
    Public Overridable Property pagosgarantia As DbSet(Of pagosgarantia)
    Public Overridable Property pmensual As DbSet(Of pmensual)
    Public Overridable Property promotor As DbSet(Of promotor)
    Public Overridable Property proveedor As DbSet(Of proveedor)
    Public Overridable Property siniestros As DbSet(Of siniestros)
    Public Overridable Property sucursal As DbSet(Of sucursal)
    Public Overridable Property usersregs As DbSet(Of usersregs)
    Public Overridable Property webbancos As DbSet(Of webbancos)
    Public Overridable Property webmonitor As DbSet(Of webmonitor)
    Public Overridable Property wsbitacora As DbSet(Of wsbitacora)
    Public Overridable Property anexo As DbSet(Of anexo)
    Public Overridable Property avisos As DbSet(Of avisos)
    Public Overridable Property basketitems As DbSet(Of basketitems)
    Public Overridable Property cfiscales As DbSet(Of cfiscales)
    Public Overridable Property cifrascontrol As DbSet(Of cifrascontrol)
    Public Overridable Property cobranza As DbSet(Of cobranza)
    Public Overridable Property codigogarantia As DbSet(Of codigogarantia)
    Public Overridable Property comisiones As DbSet(Of comisiones)
    Public Overridable Property contmovi As DbSet(Of contmovi)
    Public Overridable Property control As DbSet(Of control)
    Public Overridable Property controlArrend As DbSet(Of controlArrend)
    Public Overridable Property descuento As DbSet(Of descuento)
    Public Overridable Property edocuenta As DbSet(Of edocuenta)
    Public Overridable Property envios As DbSet(Of envios)
    Public Overridable Property estadosmexicocnbv As DbSet(Of estadosmexicocnbv)
    Public Overridable Property fiscalpv As DbSet(Of fiscalpv)
    Public Overridable Property histremanentes As DbSet(Of histremanentes)
    Public Overridable Property indicadores As DbSet(Of indicadores)
    Public Overridable Property ipolizas As DbSet(Of ipolizas)
    Public Overridable Property linea As DbSet(Of linea)
    Public Overridable Property memos As DbSet(Of memos)
    Public Overridable Property monitor As DbSet(Of monitor)
    Public Overridable Property pagares As DbSet(Of pagares)
    Public Overridable Property pagosadeudos As DbSet(Of pagosadeudos)
    Public Overridable Property paridad As DbSet(Of paridad)
    Public Overridable Property perfiles As DbSet(Of perfiles)
    Public Overridable Property polizas As DbSet(Of polizas)
    Public Overridable Property producto As DbSet(Of producto)
    Public Overridable Property remanentes As DbSet(Of remanentes)
    Public Overridable Property tipogarantia As DbSet(Of tipogarantia)
    Public Overridable Property usuarios As DbSet(Of usuarios)
    Public Overridable Property usuariosArrend As DbSet(Of usuariosArrend)
    Public Overridable Property vencida As DbSet(Of vencida)
    Public Overridable Property wbregistry As DbSet(Of wbregistry)
    Public Overridable Property webcontrol As DbSet(Of webcontrol)
    Public Overridable Property webservice As DbSet(Of webservice)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of actividad)() _
            .Property(Function(e) e.descrip) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of actividad)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of actividad)() _
            .Property(Function(e) e.descripcnb) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of adeudos)() _
            .Property(Function(e) e.tipo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of adeudos)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of adeudos)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(4, 2)

        modelBuilder.Entity(Of adeudos)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of adeudos)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.apoderado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ap_domicilio) _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ap_ecivil) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ap_ocupa) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_localidad) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_numero) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_folio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_libro) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_auxiliar) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_volumen) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ep_poderlocal) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.nacion) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.ap_colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.n) _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.s) _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.p) _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.m) _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.curp) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.porcentaje) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of apoderados)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.calle) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.noext) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.noint) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.pais) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of aseguradora)() _
            .Property(Function(e) e.email) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of bancos)() _
            .Property(Function(e) e.idbanco) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of bancos)() _
            .Property(Function(e) e.banco) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of bancos)() _
            .Property(Function(e) e.shortname) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of baskets)() _
            .Property(Function(e) e.idtransact) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ccosto)() _
            .Property(Function(e) e.ccosto1) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ccosto)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ccosto)() _
            .Property(Function(e) e.orden) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.sumadoctos) _
            .HasPrecision(20, 0)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.impanticipado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.interes) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.ivainteres) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasahono) _
            .HasPrecision(6, 4)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.honorario) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.ivahonorario) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tnafin) _
            .HasPrecision(8, 5)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.cartera) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.pagos) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.totalpagar) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.movto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.userid) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.acuse) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.costonafin) _
            .HasPrecision(6, 4)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasa_ord) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.folioevento) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.disperfile) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.tasaganafin) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.garantnafin) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.ivaganafin) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.imvfacnafin) _
            .HasPrecision(6, 4)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.gliquida) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.cfdi) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(5, 0)

        modelBuilder.Entity(Of cesiones)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of ciudades)() _
            .Property(Function(e) e.ciudad) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.n) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.s) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.p) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.m) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.curp) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.domicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_localid) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_numero) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_folio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_libro) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_auxilia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_volumen) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ac_actaloc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.fenlace) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.puesto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.password) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.email) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.sirac) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.path_exped) _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.actividad) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.inbox) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.outbox) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.loaded) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.filenaming) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.epo) _
            .HasPrecision(5, 0)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.calcliente) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.calle) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.noext) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.noint) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.enviafact) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.riesgo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.riesgogpo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.repeco) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.clientet24) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.nombret24) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.consolida) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.fira_idacr) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.idlocalidad) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.pjuridica) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.ingresos) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.idtransact) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of clientes)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.domicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.responsable) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.plaza) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.giro) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.curp) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.notas) _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.cobertura) _
            .HasPrecision(15, 2)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.idmapfre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.calle) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.noext) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.noint) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.email) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.enviafact) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.idtransact) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comprador)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.codigo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.tasa_ord) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.tasa_ext) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.com_cont) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.hon_admon) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.porc_anti) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.linea) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.com_prom) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.notas) _
            .IsUnicode(False)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.bancos) _
            .IsUnicode(False)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.utilizado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.cobertura) _
            .HasPrecision(15, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.idmapfre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.pgeseguro) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.ctoobrapub) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.tasa_opera) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.tasa_mora) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.digitov) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.infolinea) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.dispercom) _
            .HasPrecision(15, 2)

        modelBuilder.Entity(Of contratos)() _
            .Property(Function(e) e.idtransact) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctaprove)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctaprove)() _
            .Property(Function(e) e.plaza) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctaprove)() _
            .Property(Function(e) e.sucursal) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctaprove)() _
            .Property(Function(e) e.clabe) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctaprove)() _
            .Property(Function(e) e.updaterec) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctasaldos)() _
            .Property(Function(e) e.ctabanco) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctasaldos)() _
            .Property(Function(e) e.santerior) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of ctasaldos)() _
            .Property(Function(e) e.entradas) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of ctasaldos)() _
            .Property(Function(e) e.salidas) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of ctasaldos)() _
            .Property(Function(e) e.sactual) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of ctasaldos)() _
            .Property(Function(e) e.saldos) _
            .IsUnicode(False)

        modelBuilder.Entity(Of ctasaldos)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.ctabanco) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.ctacontable) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.banco) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.sucbancaria) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.slogan) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.cobrado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.entradas) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.salidas) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.banda) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.codigoseg) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.numbanco) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cuentas)() _
            .Property(Function(e) e.plazacomp) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.ctabanco) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.concepto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.detalle) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.capital) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.entrada) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.banco) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of depositos)() _
            .Property(Function(e) e.folioevento) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.iddetalle) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.pagare) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.referencia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.tinter) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.ivainteres) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.descto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.hono) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(5, 0)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.ctetinter) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.ctehono) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of detalle)() _
            .Property(Function(e) e.cteiva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.numrec) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.anticipo) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.interes) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.movto) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.imp_inter) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(8, 4)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(4, 0)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.sisfol) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of dev_iv)() _
            .Property(Function(e) e.folio) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.numrec) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.anticipo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.movto) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(4, 0)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.sisfol) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of dev_moratorio)() _
            .Property(Function(e) e.folio) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.numrec) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.anticipo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.movto) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(4, 0)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.sisfol) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of dev_mvencido)() _
            .Property(Function(e) e.folio) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.numrec) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.anticipo) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.interes) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.movto) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.imp_inter) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of devengue)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(4, 0)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.iddocto) _
            .HasPrecision(8, 0)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.pagare) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.referencia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.plaza) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.interes) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.ivainteres) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.descto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.hono) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.plazo) _
            .HasPrecision(5, 0)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of doctos)() _
            .Property(Function(e) e.idtransact) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of edoseguro)() _
            .Property(Function(e) e.idrec) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of edoseguro)() _
            .Property(Function(e) e.numrec) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of edoseguro)() _
            .Property(Function(e) e.financiado) _
            .HasPrecision(15, 2)

        modelBuilder.Entity(Of edoseguro)() _
            .Property(Function(e) e.cobrado) _
            .HasPrecision(15, 2)

        modelBuilder.Entity(Of estadosdemexico)() _
            .Property(Function(e) e.abrev) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estadosdemexico)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estadosdemexico)() _
            .Property(Function(e) e.estadocnbv) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.tcotro) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pnombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pcalle) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pnoext) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pnoint) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pcolonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pmunicipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pestado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.ppais) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.ptelefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.prfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estudios)() _
            .Property(Function(e) e.pemail) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of evento)() _
            .Property(Function(e) e.descrip) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of evento)() _
            .Property(Function(e) e.tasa) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of evento)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of evento)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(4, 2)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.remark) _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.distrib) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.sat) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.ati) _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpf)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of foliosat)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of foliosat)() _
            .Property(Function(e) e.autoriza) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of foliosat)() _
            .Property(Function(e) e.certifica) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of garantia)() _
            .Property(Function(e) e.valor) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of garantia)() _
            .Property(Function(e) e.porcentaje) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of garantia)() _
            .Property(Function(e) e.costo) _
            .HasPrecision(6, 2)

        modelBuilder.Entity(Of garantia)() _
            .Property(Function(e) e.cobrado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of garantia)() _
            .Property(Function(e) e.ivacobrado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of garantia)() _
            .Property(Function(e) e.valor_ant) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of garantia)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of grupos)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of lavado)() _
            .Property(Function(e) e.idrec) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of lavado)() _
            .Property(Function(e) e.id) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of lavado)() _
            .Property(Function(e) e.detalle) _
            .IsUnicode(False)

        modelBuilder.Entity(Of lavado)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.ctabancobk) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.tipo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.beneficiario) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.concepto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.concconta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.entrada) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.salida) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of movcuentas)() _
            .Property(Function(e) e.tasa) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.idoperacion) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.totalpagar) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.descto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.interes) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.honorario) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.tasahono) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.ivainteres) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.cfdi) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.transfer) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.errtransfer) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.ctafondeo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.gnafin) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.servnafin) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.ivaserv) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.adeudos) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.wbresponse) _
            .IsUnicode(False)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.datasent) _
            .IsUnicode(False)

        modelBuilder.Entity(Of operaciones)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of pagosgarantia)() _
            .Property(Function(e) e.pago) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of pagosgarantia)() _
            .Property(Function(e) e.saldo_ant) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of pmensual)() _
            .Property(Function(e) e.tasamn) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of pmensual)() _
            .Property(Function(e) e.tasadlls) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of pmensual)() _
            .Property(Function(e) e.fira) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of pmensual)() _
            .Property(Function(e) e.void) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.codigo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.domicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.tipopromo) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.cc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.empleado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.idt24) _
            .HasPrecision(16, 0)

        modelBuilder.Entity(Of promotor)() _
            .Property(Function(e) e.nombret24) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.domicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.responsable) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.plaza) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.giro) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.curp) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.notas) _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.email) _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.password) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.sirac) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.calle) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.noext) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.noint) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.enviafact) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.repeco) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.updaterec) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.fira_idcon) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.idtransact) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of proveedor)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of siniestros)() _
            .Property(Function(e) e.contratos) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of siniestros)() _
            .Property(Function(e) e.solicitado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of siniestros)() _
            .Property(Function(e) e.deducible) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.cvesuc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.abrev_suc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.domicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.apoderado1) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.apoderado2) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.testigo1) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.testigo2) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.h_in) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.h_out) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.h_loaded) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.h_sent) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of sucursal)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.username) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.ca) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.listpass) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.email) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.notas) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.updaterec) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usersregs)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of webbancos)() _
            .Property(Function(e) e.shortname) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webmonitor)() _
            .Property(Function(e) e.action) _
            .IsUnicode(False)

        modelBuilder.Entity(Of webmonitor)() _
            .Property(Function(e) e.userfeb) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webmonitor)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of wsbitacora)() _
            .Property(Function(e) e.metodo) _
            .IsUnicode(False)

        modelBuilder.Entity(Of wsbitacora)() _
            .Property(Function(e) e.ipcliente) _
            .IsUnicode(False)

        modelBuilder.Entity(Of anexo)() _
            .Property(Function(e) e.catcte) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of anexo)() _
            .Property(Function(e) e.sobretasa) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of anexo)() _
            .Property(Function(e) e.limite) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of anexo)() _
            .Property(Function(e) e.updaterec) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of avisos)() _
            .Property(Function(e) e.aviso) _
            .IsUnicode(False)

        modelBuilder.Entity(Of avisos)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.total) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.descto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.hono) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.tinter) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.neto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.ivainteres) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.tasaoper) _
            .HasPrecision(7, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.servnafin) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.ivaserv) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.int_diario) _
            .HasPrecision(14, 4)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.ctetinter) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.ctehono) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of basketitems)() _
            .Property(Function(e) e.cteiva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cfiscales)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cfiscales)() _
            .Property(Function(e) e.tipo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cfiscales)() _
            .Property(Function(e) e.descrip) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cfiscales)() _
            .Property(Function(e) e.totales) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of cifrascontrol)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cifrascontrol)() _
            .Property(Function(e) e.descto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cifrascontrol)() _
            .Property(Function(e) e.neto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cifrascontrol)() _
            .Property(Function(e) e.bonifica) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.iddocto) _
            .HasPrecision(8, 0)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.pagare) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.descto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.neto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.bonifica) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of cobranza)() _
            .Property(Function(e) e.saldoanterior) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of codigogarantia)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of comisiones)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of comisiones)() _
            .Property(Function(e) e.comision) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of comisiones)() _
            .Property(Function(e) e.paridad) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of comisiones)() _
            .Property(Function(e) e.comcontrato) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of comisiones)() _
            .Property(Function(e) e.comcesion) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of contmovi)() _
            .Property(Function(e) e.anterior) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of contmovi)() _
            .Property(Function(e) e.actual) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.compania) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.razon) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.domicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.oclave) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.odomicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.ocolonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.omunicipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.oestado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.otelefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.awcmdline) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.inbox) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.outbox) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.sent) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.signatures) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.h_inbox) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.h_outbox) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.h_sent) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.a_inbox) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.a_send) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.mailserver) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.parametros) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.decimals) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.currsimb) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.currtext) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.iva) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.curversion) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.trustees) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.clientbox) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.clientzip) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.clientloaded) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.exp_pass) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.hist_pass) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.len_pass) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.login_attempts) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.aviso_expira) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.path_expedientes) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.path_fileimage) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.maildomain) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.u_disper) _
            .HasPrecision(8, 0)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.path_requer) _
            .IsUnicode(False)

        modelBuilder.Entity(Of control)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.compania) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.razon) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.rfc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.domicilio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.colonia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.municipio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.telefono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.tasas) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.u_esquema) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.serie_fm) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.folio_fm) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.serie_rta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.folio_rta) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.serie_oc) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.folio_oc) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.serie_la) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.folio_la) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.folio_poli) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.parametros) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.filltasas) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.trustees) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.requer) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.cargo) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.solicitud) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.abogado) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.demanda) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.etapa) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.folio_ls) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.serie_ls) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.folio_ap) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.serie_ap) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.trusteesfora) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.cfd_source) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.cfd_password) _
            .IsFixedLength()

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.fax) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.homepage) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.dominio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.mailserver) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.ftpserver) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.dias_cont) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.rangoaviso) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.venceauto) _
            .HasPrecision(1, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.vencseguro) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.pzomaxseg) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.mincruzado) _
            .HasPrecision(9, 2)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.opcongela) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.exp_pass) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.hist_pass) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.len_pass) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.login_attempts) _
            .HasPrecision(3, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.op_relevnte) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.fira_dias) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.dom_border) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.col_border) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.mpo_border) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.edo_border) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.anoaproba) _
            .HasPrecision(4, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.nocertif) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.cpgeneral) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.cpcedula) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.antesquien) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.serie_xm) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.cfdi_source) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.aviso_privacidad) _
            .IsUnicode(False)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.tasamorat) _
            .HasPrecision(18, 0)

        modelBuilder.Entity(Of controlArrend)() _
            .Property(Function(e) e.u_domici) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of descuento)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of descuento)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of descuento)() _
            .Property(Function(e) e.descto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of descuento)() _
            .Property(Function(e) e.referencia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of edocuenta)() _
            .Property(Function(e) e.concepto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of edocuenta)() _
            .Property(Function(e) e.movto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of edocuenta)() _
            .Property(Function(e) e.ant_debe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of edocuenta)() _
            .Property(Function(e) e.ant_haber) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of edocuenta)() _
            .Property(Function(e) e.car_debe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of edocuenta)() _
            .Property(Function(e) e.car_haber) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of envios)() _
            .Property(Function(e) e.userfile) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of envios)() _
            .Property(Function(e) e.fcafile) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of estadosmexicocnbv)() _
            .Property(Function(e) e.estado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpv)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpv)() _
            .Property(Function(e) e.tipo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpv)() _
            .Property(Function(e) e.concepto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of fiscalpv)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of fiscalpv)() _
            .Property(Function(e) e.seguro) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.pago) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.cobrado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.aforo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.descto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.bonifica) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.cartera) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.adeudos) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.movto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.userid) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of histremanentes)() _
            .Property(Function(e) e.disperfile) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.cetes28) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.cetes91) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.cpp) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.tiip) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.tiie) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.tiie91) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.fondeo) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.libor) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.libor3m) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.fondeousd) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.libor6m) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of indicadores)() _
            .Property(Function(e) e.libor12m) _
            .HasPrecision(7, 4)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.poliza) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.contratos) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.cobertura) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.piva) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.primatasa) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.primasubtotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.primaiva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.primatotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.csubtotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.civa) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.ctotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.comentarios) _
            .IsUnicode(False)

        modelBuilder.Entity(Of ipolizas)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.id_rec) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.lcredito) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.ldescrip) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.lmonto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.lutilizado) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.ldisponibl) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.porcentaje) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.adeudo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.vencida) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.garantsdo) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.garantutl) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.idmultiple) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of linea)() _
            .Property(Function(e) e.lmultiple) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.descrip) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.source) _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.texto1) _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.texto2) _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.texto3) _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.ctamxn) _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.ctausd) _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.apoderado) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.testigo1) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.testigo2) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of memos)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of monitor)() _
            .Property(Function(e) e.userid) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of monitor)() _
            .Property(Function(e) e.action) _
            .IsUnicode(False)

        modelBuilder.Entity(Of monitor)() _
            .Property(Function(e) e.void) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of monitor)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.idpagare) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.pagare) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.referencia) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.monto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.refe2) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.refe3) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagares)() _
            .Property(Function(e) e.disperfile) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagosadeudos)() _
            .Property(Function(e) e.tipo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagosadeudos)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagosadeudos)() _
            .Property(Function(e) e.movto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagosadeudos)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of pagosadeudos)() _
            .Property(Function(e) e.concepto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of pagosadeudos)() _
            .Property(Function(e) e.cuenta) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of paridad)() _
            .Property(Function(e) e.paridad1) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of paridad)() _
            .Property(Function(e) e.udis) _
            .HasPrecision(11, 8)

        modelBuilder.Entity(Of perfiles)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of perfiles)() _
            .Property(Function(e) e.source) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of perfiles)() _
            .Property(Function(e) e.ptrustees) _
            .IsUnicode(False)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.poliza) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.piva) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.indemnizacion) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.facturacion) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primasubtotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primaiva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primatotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primapdescuento) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primapagar) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primaminima) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primaasubtotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primaaiva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.primaatotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.gecosto) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.gesubtotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.geiva) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.getotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.geatotal) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.deducible) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of polizas)() _
            .Property(Function(e) e.archivopdf) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of producto)() _
            .Property(Function(e) e.producto1) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of remanentes)() _
            .Property(Function(e) e.remanente) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of remanentes)() _
            .Property(Function(e) e.anterior) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of remanentes)() _
            .Property(Function(e) e.movto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of tipogarantia)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of tipogarantia)() _
            .Property(Function(e) e.concepto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of tipogarantia)() _
            .Property(Function(e) e.conta_cargo) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of tipogarantia)() _
            .Property(Function(e) e.conta_abono) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuarios)() _
            .Property(Function(e) e.userid) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuarios)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuarios)() _
            .Property(Function(e) e.puesto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuarios)() _
            .Property(Function(e) e.trustees) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuarios)() _
            .Property(Function(e) e.email) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuarios)() _
            .Property(Function(e) e.lista_pass) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuarios)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.folio) _
            .HasPrecision(6, 0)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.userid) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.nombre) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.trustees) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.email) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.lista_pass) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.jefe) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.user_job) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.historia) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.oficina) _
            .HasPrecision(2, 0)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.perfil) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.sign) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.id_regi) _
            .IsFixedLength()

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.session) _
            .IsUnicode(False)

        modelBuilder.Entity(Of usuariosArrend)() _
            .Property(Function(e) e.token) _
            .IsUnicode(False)

        modelBuilder.Entity(Of vencida)() _
            .Property(Function(e) e.docto) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of vencida)() _
            .Property(Function(e) e.saldo) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of wbregistry)() _
            .Property(Function(e) e.idrec) _
            .HasPrecision(10, 0)

        modelBuilder.Entity(Of wbregistry)() _
            .Property(Function(e) e.result) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of wbregistry)() _
            .Property(Function(e) e.datasent) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of wbregistry)() _
            .Property(Function(e) e.importe) _
            .HasPrecision(14, 2)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.tasa) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.tasadlls) _
            .HasPrecision(5, 2)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.mailserver) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.dominio) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.sv) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.factura) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.serie) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.ctausd) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.ctamxn) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webcontrol)() _
            .Property(Function(e) e.factother) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webservice)() _
            .Property(Function(e) e.webservice1) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webservice)() _
            .Property(Function(e) e.soapfield) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webservice)() _
            .Property(Function(e) e.soapurl) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webservice)() _
            .Property(Function(e) e.soapaction) _
            .IsFixedLength() _
            .IsUnicode(False)

        modelBuilder.Entity(Of webservice)() _
            .Property(Function(e) e.soaprequest) _
            .IsUnicode(False)

        modelBuilder.Entity(Of webservice)() _
            .Property(Function(e) e.timestamp_column) _
            .IsFixedLength()
    End Sub
End Class
