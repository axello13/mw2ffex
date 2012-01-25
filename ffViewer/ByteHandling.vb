Public Class ByteHandling
    Public Shared Function CountBytes(ByVal bytes As Byte(), ByVal needle As Byte(), Optional ByVal offset As Integer = 0, Optional ByVal endOffset As Integer = -1) As Integer
        Dim returnInt As Integer
        Dim currentByte As Integer
        Dim count As Integer
        returnInt = 0
        If (endOffset = -1) Then
            For i As Integer = offset To bytes.Length - 1
                If (bytes(i) = needle(currentByte)) Then
                    currentByte += 1
                Else
                    currentByte = 0
                End If
                If (currentByte >= needle.Length) Then
                    count += 1
                    currentByte = 0
                End If
            Next
            Return count
        Else
            For i As Integer = offset To endOffset
                If (bytes(i) = needle(currentByte)) Then
                    currentByte += 1
                Else
                    currentByte = 0
                End If
                If (currentByte >= needle.Length) Then
                    count += 1
                    currentByte = 0
                End If
            Next
            Return count
        End If
    End Function
    Public Shared Function FindBytes(ByVal bytes() As Byte, ByVal needle() As Byte, ByVal offset As Integer, Optional ByVal returnMinusOnNotFind As Boolean = False) As Integer
        Dim returnInt As Integer
        Dim currentByte As Integer
        returnInt = -1
        For i As Integer = offset To bytes.Length - 1
            If (bytes(i) = needle(currentByte)) Then
                currentByte += 1
            Else
                currentByte = 0
            End If
            If (currentByte >= needle.Length) Then
                returnInt = i - (needle.Length - 1)
                Return returnInt
                Exit For
            End If
        Next
        If (returnMinusOnNotFind) Then
            Return -1
        Else
            Return returnInt
        End If

    End Function

    Public Shared Function GetDWORD(ByVal allBytes As Byte(), ByVal startOffset As Integer, Optional ByVal reverseBytes As Boolean = False, Optional ByVal numBytes As Integer = 4) As Int32
        Dim tableIndexBytes As Byte()
        ReDim tableIndexBytes(numBytes - 1)

        For i As Integer = 0 To numBytes - 1
            tableIndexBytes(i) = allBytes(startOffset + i)
        Next

        If (reverseBytes <> True) Then
            Array.Reverse(tableIndexBytes)
        End If

        If (numBytes = 4) Then
            Return BitConverter.ToInt32(tableIndexBytes, 0)
        Else
            Return BitConverter.ToInt16(tableIndexBytes, 0)
        End If

    End Function

    Public Shared Function GetDWORD3(ByVal allBytes As Byte(), ByVal startOffset As Integer, Optional ByVal reverseBytes As Boolean = False) As Int32
        Dim tableIndexBytes As Byte()
        ReDim tableIndexBytes(4)

        For i As Integer = 1 To 4
            tableIndexBytes(i) = allBytes(startOffset + i)
        Next

        If (reverseBytes <> True) Then
            Array.Reverse(tableIndexBytes)
        End If


        Return BitConverter.ToInt32(tableIndexBytes, 0)
    End Function

    Public Shared Function SetDWORD(ByVal allBytes As Byte(), ByVal startOffset As Integer, ByVal DWORD As Int32, Optional ByVal reverse As Boolean = False) As Byte()
        Dim wordBytes As Byte() = BitConverter.GetBytes(DWORD)
        If (reverse <> True) Then
            Array.Reverse(wordBytes)
        End If
        allBytes(startOffset) = wordBytes(0)
        allBytes(startOffset + 1) = wordBytes(1)
        allBytes(startOffset + 2) = wordBytes(2)
        allBytes(startOffset + 3) = wordBytes(3)

        Return allBytes
    End Function

    Public Shared Function FindByteBackward(ByVal bytes As Byte(), ByVal find As Byte, ByVal offset As Integer) As Integer
        Dim returnInt As Integer
        returnInt = -1
        For i As Integer = 0 To offset
            If (bytes(offset - i) = find And returnInt = -1) Then
                returnInt = offset - i
                Exit For
            End If
        Next
        Return returnInt
    End Function

    Public Shared Function GetString(ByVal bytes As Byte(), ByVal offset As Integer, ByVal endoffset As Integer) As String
        Dim byteselection As Byte()
        Dim tempString As String
        tempString = ""
        ReDim Preserve byteselection(endoffset - offset)
        For i As Integer = 0 To endoffset - offset - 1
            byteselection(i) = bytes(i + offset)
        Next

        bytes = Nothing

        Return System.Text.ASCIIEncoding.ASCII.GetString(byteselection)
    End Function

    Public Shared Function RemoveBytes(ByVal bytes As Byte(), ByVal startOffset As Integer, ByVal endOffset As Integer) As Byte()
        Dim beforeRaw As Byte()
        Dim afterRaw As Byte()

        ReDim beforeRaw(startOffset)
        ReDim afterRaw(bytes.Length - (endOffset + 1))

        Array.ConstrainedCopy(bytes, 0, beforeRaw, 0, beforeRaw.Length)
        Array.ConstrainedCopy(bytes, endOffset, afterRaw, 0, afterRaw.Length)

        ReDim bytes(beforeRaw.Length + afterRaw.Length - 1)

        Array.ConstrainedCopy(beforeRaw, 0, bytes, 0, beforeRaw.Length)
        Array.ConstrainedCopy(afterRaw, 0, bytes, beforeRaw.Length, afterRaw.Length)

        Return bytes
    End Function

    Public Shared Function AddBytes(ByVal bytes As Byte(), ByVal add As Byte(), ByVal startOffset As Integer) As Byte()
        Dim beforeRaw As Byte()
        Dim afterRaw As Byte()

        ReDim beforeRaw(startOffset - 1)
        ReDim afterRaw(bytes.Length - startOffset - 1)
        Array.ConstrainedCopy(bytes, 0, beforeRaw, 0, beforeRaw.Length)
        Array.ConstrainedCopy(bytes, startOffset, afterRaw, 0, afterRaw.Length)

        ReDim bytes(beforeRaw.Length + afterRaw.Length - 1 + add.Length)
        Array.ConstrainedCopy(beforeRaw, 0, bytes, 0, beforeRaw.Length)
        Array.ConstrainedCopy(add, 0, bytes, beforeRaw.Length, add.Length)
        Array.ConstrainedCopy(afterRaw, 0, bytes, beforeRaw.Length + add.Length, afterRaw.Length)

        Return bytes
    End Function
End Class
