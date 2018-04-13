Imports System.ComponentModel.DataAnnotations

Public Class ProveedorEntidad

	Public Property sucursal As Integer?

	Public Property fec_alta As Date?

	Public Property deudor As Integer

	Public Property nombre As String

	Public Property domicilio As String

	Public Property colonia As String

	Public Property municipio As String

	Public Property estado As String

	Public Property telefono As String

	Public Property cp As Integer?

	Public Property responsable As String

	Public Property plaza As String

	Public Property plazacob As Integer?

	Public Property giro As String

	Public Property rfc As String

	Public Property curp As String

	Public Property elaborado As Boolean?

	Public Property firmado As Boolean?

	Public Property rectificado As Boolean?

	Public Property historia As Boolean?

	Public Property notas As String

	Public Property email As String

	Public Property password As String

	Public Property internet As Boolean?

	Public Property regiva As Integer?

	Public Property sirac As Decimal?

	Public Property promotor As Integer?

	Public Property void As Boolean?

	Public Property calle As String

	Public Property noext As String

	Public Property noint As String

	Public Property enviafact As Decimal?

	Public Property repeco As Decimal?

	Public Property fec_update As Date?

	Public Property folio_envio As Integer?

	Public Property updaterec As String

	Public Property modifica As Boolean?

	Public Property fira_idcon As Decimal?

	Public Property idtransact As String

	Public Property timestamp_column As Byte()
End Class
