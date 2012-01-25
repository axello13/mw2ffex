Imports System.ComponentModel

<DefaultPropertyAttribute("Pre-asset strings")> Public Class PreAssetStringData
    Public _Size As Integer = 0
    Public _String As String = ""

    Public Sub New(ByVal StringName As String, ByVal StringSize As Integer)
        _Size = StringSize
        _String = StringName
    End Sub

    <CategoryAttribute("Pre-asset strings"), DescriptionAttribute("The asset string length")> Public Property Size() As Integer
        Get
            Return _Size
        End Get
        Set(ByVal Value As Integer)
            _Size = Value
        End Set
    End Property

    <CategoryAttribute("Pre-asset strings"), DescriptionAttribute("The actual pre-asset string")> Public Property PreString() As String
        Get
            Return _String
        End Get
        Set(ByVal Value As String)
            _String = Value
        End Set
    End Property

End Class
