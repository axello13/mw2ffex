Imports System.ComponentModel

Public Class AssetData
    Public _AssetByte As Byte = 0

    Public Sub New(ByVal ByteOfAsset As Byte)
        _AssetByte = ByteOfAsset
    End Sub

    <CategoryAttribute("Asset"), DescriptionAttribute("The type the asset is")> Public Property AssetByte() As Byte
        Get
            Return _AssetByte
        End Get
        Set(ByVal Value As Byte)
            _AssetByte = Value
        End Set
    End Property

End Class
