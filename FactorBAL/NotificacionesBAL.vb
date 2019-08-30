Imports FactorDAL
Imports FactorEntidades

Public Class NotificacionesBAL

    Public Function ConsultaNotificacionesBAL(fecha As String, ByRef model As List(Of NotificacionesEntidad)) As Result
        Dim consulta = New NotificacionesDAL
        Return consulta.ConsultaNotificacionesDAL(fecha, model)
    End Function

    Function NotificarBAL(fecha As Date, ByRef model As List(Of NotificacionesEntidad), ByRef modelDet As List(Of NotificacionesEntidad), ByRef existe As Boolean, ByRef ruta As String) As Result
        Dim consulta = New NotificacionesDAL()
        Return consulta.NotificarDAL(fecha, model, modelDet, existe, ruta)
    End Function

    Function GuardarNotificacionesBAL(mailList As List(Of notifica_e), ruta As String) As Result
        Dim consulta = New NotificacionesDAL()
        Return consulta.GuardarNotificacionesDAL(mailList, ruta)
    End Function

    Sub DescargarArchivoBAL(ByRef model As notifica_e, idrec As Integer)
        Dim consulta = New NotificacionesDAL()
        consulta.DescargarArchivoDAL(model, idrec)
    End Sub

    Function ReenviarCorreoBAL(idrec As Integer, ByRef model As notifica_e) As Result
        Dim consulta As New NotificacionesDAL()
        Return consulta.ReenviarCorreoDAL(idrec, model)
    End Function

    Sub EnviarNotificacionesBAL(mailList As List(Of notifica_e))
        Dim consulta = New NotificacionesDAL()
        consulta.EnviarNotificacionesDAL(mailList)
    End Sub

    Function ConsultaDeunameBAL(deudor As Integer) As String
        Dim consulta = New NotificacionesDAL()
        Return consulta.ConsultaDeunameDAL(deudor)
    End Function

End Class
