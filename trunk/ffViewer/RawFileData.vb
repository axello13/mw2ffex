Imports System.ComponentModel

Public Class RawFileData
    Public _Size As Integer = 0
    Public _Filename As String = ""
    Public _Offset As Integer = 0
    Public _Compressed As Boolean = True
    Public _noOfFF As Integer = 0 ' the number of FF bytes in the compressed file :D Used to work out the new value for the second file size!

    Public Sub New(ByVal Name As String, ByVal FileSize As Integer, ByVal FileOffset As Integer, ByVal FileCompressed As Boolean, Optional ByVal FFcount As Integer = 0)
        _Filename = Name
        _Size = FileSize
        _Offset = FileOffset
        _Compressed = FileCompressed
        _noOfFF = FFcount
    End Sub

    <CategoryAttribute("Raw file data"), DescriptionAttribute("The name of the raw file")> Public Property Filename() As String
        Get
            Return _Filename
        End Get
        Set(ByVal Value As String)
            _Filename = Value
        End Set
    End Property


    <CategoryAttribute("Raw file data"), DescriptionAttribute("The offset of the raw file")> Public Property Offset() As Integer
        Get
            Return _Offset
        End Get
        Set(ByVal Value As Integer)
            _Offset = Value
        End Set
    End Property

    <CategoryAttribute("Raw file data"), DescriptionAttribute("The size of the raw file")> Public Property Size() As Integer
        Get
            Return _Size
        End Get
        Set(ByVal Value As Integer)
            _Size = Value
        End Set
    End Property

    <CategoryAttribute("Raw file data"), DescriptionAttribute("Is the raw file compressed?")> Public Property Compressed() As Boolean
        Get
            Return _Compressed
        End Get
        Set(ByVal Value As Boolean)
            _Compressed = Value
        End Set
    End Property

    <CategoryAttribute("Raw file data"), DescriptionAttribute("The number of FF bytes in the raw file (compressed). Read-only."), [ReadOnly](True)> Public Property NoOfFF() As Integer
        Get
            Return _noOfFF
        End Get
        Set(ByVal Value As Integer)
            _noOfFF = Value
        End Set
    End Property
End Class
