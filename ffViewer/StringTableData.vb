Imports System.ComponentModel

Public Class StringTableData
    Public _Columns As Integer = 0
    Public _Rows As Integer = 0
    Public _Filename As String = ""
    Public _Offset As Integer = 0

    Public Sub New(ByVal Name As String, ByVal cols As Integer, ByVal row As Integer, ByVal FileOffset As Integer)
        Filename = Name
        Columns = cols
        Rows = row
        Offset = FileOffset
    End Sub

    <CategoryAttribute("Pre-asset strings"), DescriptionAttribute("The name of the string table")> Public Property Filename() As String
        Get
            Return _Filename
        End Get
        Set(ByVal Value As String)
            _Filename = Value
        End Set
    End Property

    <CategoryAttribute("Pre-asset strings"), DescriptionAttribute("The offset of the string table")> Public Property Offset() As Integer
        Get
            Return _Offset
        End Get
        Set(ByVal Value As Integer)
            _Offset = Value
        End Set
    End Property

    <CategoryAttribute("Pre-asset strings"), DescriptionAttribute("The number of columns in the string table")> Public Property Columns() As Integer
        Get
            Return _Columns
        End Get
        Set(ByVal Value As Integer)
            _Columns = Value
        End Set
    End Property

    <CategoryAttribute("Pre-asset strings"), DescriptionAttribute("The number of rows in the string table")> Public Property Rows() As Integer
        Get
            Return _Rows
        End Get
        Set(ByVal Value As Integer)
            _Rows = Value
        End Set
    End Property

End Class
