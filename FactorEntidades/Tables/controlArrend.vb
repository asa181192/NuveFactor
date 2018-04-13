Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("controlArrend")>
Partial Public Class controlArrend
    <Key>
    <Column(Order:=0)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property registro As Integer

    <Key>
    <Column(Order:=1)>
    <StringLength(60)>
    Public Property compania As String

    <StringLength(200)>
    Public Property razon As String

    <Key>
    <Column(Order:=2)>
    <StringLength(13)>
    Public Property rfc As String

    <Key>
    <Column(Order:=3)>
    <StringLength(50)>
    Public Property domicilio As String

    <Key>
    <Column(Order:=4)>
    <StringLength(50)>
    Public Property colonia As String

    <Key>
    <Column(Order:=5)>
    <StringLength(50)>
    Public Property municipio As String

    <Key>
    <Column(Order:=6)>
    <StringLength(50)>
    Public Property estado As String

    <Key>
    <Column(Order:=7)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property cp As Integer

    <Key>
    <Column(Order:=8)>
    <StringLength(40)>
    Public Property telefono As String

    <Key>
    <Column(Order:=9)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property u_cliente As Integer

    <Key>
    <Column(Order:=10, TypeName:="text")>
    Public Property tasas As String

    <Key>
    <Column(Order:=11)>
    Public Property u_esquema As Decimal

    <Key>
    <Column(Order:=12)>
    <StringLength(3)>
    Public Property serie_fm As String

    <Key>
    <Column(Order:=13)>
    Public Property folio_fm As Decimal

    <Key>
    <Column(Order:=14)>
    <StringLength(3)>
    Public Property serie_rta As String

    <Key>
    <Column(Order:=15)>
    Public Property folio_rta As Decimal

    <Key>
    <Column(Order:=16)>
    <StringLength(3)>
    Public Property serie_oc As String

    <Key>
    <Column(Order:=17)>
    Public Property folio_oc As Decimal

    <Key>
    <Column(Order:=18)>
    <StringLength(3)>
    Public Property serie_la As String

    <Key>
    <Column(Order:=19)>
    Public Property folio_la As Decimal

    <Key>
    <Column(Order:=20)>
    Public Property folio_poli As Decimal

    <Key>
    <Column(Order:=21, TypeName:="text")>
    Public Property parametros As String

    <Key>
    <Column(Order:=22, TypeName:="text")>
    Public Property filltasas As String

    <Key>
    <Column(Order:=23)>
    Public Property fec_cont As Date

    <Key>
    <Column(Order:=24)>
    Public Property fec_cobra As Date

    <Key>
    <Column(Order:=25, TypeName:="text")>
    Public Property trustees As String

    <Key>
    <Column(Order:=26)>
    Public Property requer As Decimal

    <Key>
    <Column(Order:=27)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property marca As Integer

    <Key>
    <Column(Order:=28)>
    Public Property cargo As Decimal

    <Key>
    <Column(Order:=29)>
    Public Property solicitud As Decimal

    <Key>
    <Column(Order:=30)>
    Public Property abogado As Decimal

    <Key>
    <Column(Order:=31)>
    Public Property demanda As Decimal

    <Key>
    <Column(Order:=32)>
    Public Property etapa As Decimal

    <Key>
    <Column(Order:=33)>
    Public Property stop_robot As Boolean

    <Key>
    <Column(Order:=34)>
    Public Property expand As Boolean

    <Key>
    <Column(Order:=35)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property u_cuenta As Integer

    <Key>
    <Column(Order:=36)>
    Public Property void As Boolean

    <Key>
    <Column(Order:=37)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property u_oficina As Integer

    <Key>
    <Column(Order:=38)>
    Public Property folio_ls As Decimal

    <Key>
    <Column(Order:=39)>
    <StringLength(3)>
    Public Property serie_ls As String

    <Key>
    <Column(Order:=40)>
    Public Property folio_ap As Decimal

    <Key>
    <Column(Order:=41)>
    <StringLength(3)>
    Public Property serie_ap As String

    <Key>
    <Column(Order:=42, TypeName:="text")>
    Public Property trusteesfora As String

    <Key>
    <Column(Order:=43)>
    Public Property fec_oper As Date

    <Key>
    <Column(Order:=44, TypeName:="text")>
    Public Property cfd_source As String

    Public Property cfd_certificate As String

    Public Property cfd_privatekey As String

    <StringLength(20)>
    Public Property cfd_password As String

    Public Property u_layclabe As Integer?

    <StringLength(40)>
    Public Property fax As String

    <StringLength(60)>
    Public Property homepage As String

    <StringLength(60)>
    Public Property dominio As String

    <Column(TypeName:="text")>
    Public Property mailserver As String

    <Column(TypeName:="text")>
    Public Property ftpserver As String

    <StringLength(30)>
    Public Property dias_cont As String

    <StringLength(30)>
    Public Property rangoaviso As String

    Public Property venceauto As Decimal?

    Public Property vencseguro As Decimal?

    Public Property pzomaxseg As Decimal?

    Public Property mincruzado As Decimal?

    Public Property opcongela As Decimal?

    Public Property intevfp As Boolean?

    Public Property interfasnew As Boolean?

    Public Property exp_pass As Decimal?

    Public Property hist_pass As Decimal?

    Public Property len_pass As Decimal?

    Public Property sens_pass As Boolean?

    Public Property login_attempts As Decimal?

    Public Property op_relevnte As Decimal?

    Public Property fira_dias As Decimal?

    <Column(TypeName:="text")>
    Public Property dom_border As String

    <Column(TypeName:="text")>
    Public Property col_border As String

    Public Property cp_border As Integer?

    <Column(TypeName:="text")>
    Public Property mpo_border As String

    <Column(TypeName:="text")>
    Public Property edo_border As String

    Public Property noaproba As Integer?

    Public Property anoaproba As Decimal?

    <StringLength(20)>
    Public Property nocertif As String

    <Column(TypeName:="date")>
    Public Property fec_efactu As Date?

    <Column(TypeName:="date")>
    Public Property iva_cambio As Date?

    <StringLength(50)>
    Public Property cpgeneral As String

    <StringLength(10)>
    Public Property cpcedula As String

    <StringLength(50)>
    Public Property antesquien As String

    <StringLength(3)>
    Public Property serie_xm As String

    Public Property folio_xm As Integer?

    <Column(TypeName:="text")>
    Public Property cfdi_source As String

    <Column(TypeName:="text")>
    Public Property aviso_privacidad As String

    Public Property adlogon As Boolean?

    Public Property run_robot As Boolean?

    Public Property tasamorat As Decimal?

    Public Property u_interfas As Integer?

    Public Property u_domici As Decimal?

    Public Property enviar_domici As Boolean?
End Class
