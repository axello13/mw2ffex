Imports System.ComponentModel


<DefaultPropertyAttribute("File info")> Public Class FileData
    Public Shared _Size As Integer = 0
    Public Shared _Assets As New List(Of AssetData)
    Public Shared _AssetCount As Integer = 0
    Public Shared _DataOffset As Integer = 0
    Public Shared _IsMultiplayer As Boolean = False
    Public Shared _PreAssetStrings As New List(Of PreAssetStringData)
    Public Shared _PreAssetStringCount As Integer
    Public Shared _Version As Integer = 0
    Public Shared _FileName As String = ""
    Public Shared _BigEndian As Boolean = False
    Public Shared _OrigFileName As String = ""
    Public Shared _OrigSecondSize As Integer = 0 ' this is the (bytes 20-23 mw2 and 24-27 cod4/5)
    Public Shared _RawFiles As New List(Of RawFileData)
    Public Shared _StringTables As New List(Of StringTableData)
    Public Shared _LocalizedStrings As New List(Of LocalizedStringsData)

    <CategoryAttribute("File information"), DescriptionAttribute("The opened fast file size")> Public Property Size() As Integer
        Get
            Return _Size
        End Get
        Set(ByVal Value As Integer)
            _Size = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("This is the (bytes 20-23 mw2 and 24-27 cod4/5) size. It is used to work out positions of the inner files. Unknown so far how it does that.")> Public Property SecondSize() As Integer
        Get
            Return _OrigSecondSize
        End Get
        Set(ByVal Value As Integer)
            _OrigSecondSize = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("The offset the data is located at (the size of the header)")> Public Property DataOffset() As Integer
        Get
            Return _DataOffset
        End Get
        Set(ByVal Value As Integer)
            _DataOffset = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("A collection of assets in the current fast file")> Public Property Assets() As List(Of AssetData)
        Get
            Return _Assets
        End Get
        Set(ByVal Value As List(Of AssetData))
            _Assets = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("The amount of assets there are in the fast file")> Public Property AssetCount() As Integer
        Get
            Return _AssetCount
        End Get
        Set(ByVal Value As Integer)
            _AssetCount = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("A collection of pre-asset strings to load at runtime")> Public Property PreAssetStrings() As List(Of PreAssetStringData)
        Get
            Return _PreAssetStrings
        End Get
        Set(ByVal Value As List(Of PreAssetStringData))
            _PreAssetStrings = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("The amount of pre-asset strings there are in the fast file")> Public Property PreAssetStringCount() As Integer
        Get
            Return _PreAssetStringCount
        End Get
        Set(ByVal Value As Integer)
            _PreAssetStringCount = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("Is the current fast file multiplayer?")> Public Property IsMultiplayer() As Boolean
        Get
            Return _IsMultiplayer
        End Get
        Set(ByVal Value As Boolean)
            _IsMultiplayer = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("The opened fast file version. 256 = COD4, 387 = WaW, 269 = MW2")> Public Property Version() As Integer
        Get
            Return _Version
        End Get
        Set(ByVal Value As Integer)
            _Version = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("Is the opened file big endian? (little endian = PC; big endian = XBOX)")> Public Property BigEndian() As Boolean
        Get
            Return _BigEndian
        End Get
        Set(ByVal Value As Boolean)
            _BigEndian = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("The path to the fast file")> Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal Value As String)
            _FileName = Value
        End Set
    End Property

    <CategoryAttribute("File information"), DescriptionAttribute("The original fast file name (only appears for multiplayer fast files)")> Public Property OrigFileName() As String
        Get
            Return _OrigFileName
        End Get
        Set(ByVal Value As String)
            _OrigFileName = Value
        End Set
    End Property

    <CategoryAttribute("Extractable file information"), DescriptionAttribute("The raw files inside the fast file")> Public Property RawFiles() As List(Of RawFileData)
        Get
            Return _RawFiles
        End Get
        Set(ByVal Value As List(Of RawFileData))
            _RawFiles = Value
        End Set
    End Property

    <CategoryAttribute("Extractable file information"), DescriptionAttribute("The string tables inside the fast file")> Public Property StringTables() As List(Of StringTableData)
        Get
            Return _StringTables
        End Get
        Set(ByVal Value As List(Of StringTableData))
            _StringTables = Value
        End Set
    End Property
End Class
