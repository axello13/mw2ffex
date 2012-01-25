Imports System.ComponentModel

Public Class LocalizedStringsData
    Public _StringName As Integer = 0
    Public _StringValue As Integer = 0
    Public _OrigName As String = ""
    Public _Offset As Integer = 0

    Public Sub New(ByVal Name As String, ByVal Value As String, ByVal Offset As Integer)
        _StringName = Name
        _StringValue = Value
        _OrigName = Name
        _Offset = Offset
    End Sub

    <CategoryAttribute("Localized string"), DescriptionAttribute("The offset of the localized string"), [ReadOnly](True)> Public Property Offset() As Integer
        Get
            Return _Offset
        End Get
        Set(ByVal Value As Integer)
            _Offset = Value
        End Set
    End Property

    <CategoryAttribute("Localized string"), DescriptionAttribute("The string that the localized string replaces.")> Public Property Value() As Integer
        Get
            Return _StringName
        End Get
        Set(ByVal Value As Integer)
            _StringName = Value
        End Set
    End Property

    <CategoryAttribute("Localized string"), DescriptionAttribute("The actual localized string")> Public Property Name() As Integer
        Get
            Return _StringName
        End Get
        Set(ByVal Value As Integer)
            _StringName = Value
        End Set
    End Property
End Class
