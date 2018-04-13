Public Class Result

    Private _bResultOk As Boolean

    Private _strMensaje As String

    Private _strDetalle As String

    Private _iId_Out As Integer


    Public Property Ok As Boolean
        Get
            Return _bResultOk
        End Get

        Set(ByVal value As Boolean)
            _bResultOk = value
        End Set
    End Property


    Public Property Mensaje As String
        Get
            Return _strMensaje
        End Get

        Set(ByVal value As String)
            _strMensaje = value
        End Set
    End Property


    Public Property Detalle As String
        Get
            Return _strDetalle
        End Get

        Set(ByVal value As String)
            _strDetalle = value
        End Set
    End Property


    Public Property Id_Out As Integer
        Get
            Return _iId_Out
        End Get

        Set(ByVal value As Integer)
            _iId_Out = value
        End Set
    End Property

    Public Sub New()
        _bResultOk = True
    End Sub

    Public Sub New(ByVal _bResultOk As Boolean)
        Me._bResultOk = _bResultOk
    End Sub

    Public Sub New(ByVal _bResultOk As Boolean, ByVal _strMensaje As String)
        Me._bResultOk = _bResultOk
        Me._strMensaje = _strMensaje
    End Sub

    Public Sub New(ByVal _bResultOk As Boolean, ByVal _strMensaje As String, ByVal _strDetalle As String)
        Me._bResultOk = _bResultOk
        Me._strMensaje = _strMensaje
        Me._strDetalle = _strDetalle
    End Sub

End Class
