Public Class Utilities

    Public Shared Function SuperSimpleRubbishFormat(ByVal number As Single) As String
        Return FormatNumber(number, If(number = CInt(number), 0, 2))
    End Function

End Class
