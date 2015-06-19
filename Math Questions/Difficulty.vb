Public Class Difficulty

    Dim divideChance, minimumNumber, maximumNumber As Single
    Dim minimumDivide As Integer
    Dim decimalPlaces As Boolean

    Sub New(ByVal divideChance As Single, ByVal minimumDivide As Integer, ByVal minimumNumber As Single, ByVal maximumNumber As Single, ByVal decimalPlaces As Boolean)
        Me.divideChance = divideChance
        Me.minimumDivide = minimumDivide
        Me.minimumNumber = If(decimalPlaces, minimumNumber * 100, minimumNumber)
        Me.maximumNumber = If(decimalPlaces, maximumNumber * 100, maximumNumber)
        Me.decimalPlaces = decimalPlaces
    End Sub

    Public Function getNewQuestion() As Tuple(Of String, Single)
        Dim numberOne As Single = getRandomNumber(minimumNumber, maximumNumber)
        Dim numberTwo As Single = getRandomNumber(minimumNumber, maximumNumber)
        Dim randomOperator As String = getRandomOperator()

        If Not randomOperator = "/" And decimalPlaces Then
            numberOne = numberOne / 100
            numberTwo = numberTwo / 100
        End If

        Dim answer As Single

        If randomOperator = "/" Then 'Todo divide always returns half of numberOne :/
            If numberTwo > numberOne Then
                Dim numberOneCopy As Single = numberOne
                numberOne = numberTwo
                numberTwo = numberOneCopy
            End If

            If Not numberOne Mod numberTwo = 0 Then
                Dim list As List(Of Integer) = Enumerable.Range(minimumDivide, maximumNumber).Where(Function(i) numberOne Mod i = 0 And Not numberOne = i).ToList

                If list.Count > 0 Then
                    numberTwo = list.Item(getRandomNumber(0, list.Count - 1))
                Else 'Give in
                    randomOperator = "+"
                End If
            End If

            answer = numberOne / numberTwo
        ElseIf randomOperator = "+" Then
            answer = numberOne + numberTwo
        ElseIf randomOperator = "-" Then
            answer = numberOne - numberTwo
        ElseIf randomOperator = "*" Then
            If numberOne = 1 Then 'Lets not make this too easy
                numberOne += 1
            End If

            If numberTwo = 1 Then
                numberTwo += 1
            End If

            answer = numberOne * numberTwo
        End If

        Dim question As String = numberOne & " " & randomOperator & " " & numberTwo
        Return New Tuple(Of String, Single)(question, answer)
    End Function

    Public Function getRandomOperator() As String
        Dim randomNumber As Integer = getRandomNumber(0, 100)
        Dim otherChance As Single = (100 - divideChance) / 3

        If randomNumber <= divideChance Then
            Return "/"
        ElseIf randomNumber <= otherChance Then
            Return "+"
        ElseIf randomNumber <= otherChance * 2
            Return "-"
        Else
            Return "*"
        End If
    End Function

    Public Shared Function getRandomNumber(ByVal lowerBound As Integer, ByVal upperBound As Integer) As Integer
        Randomize()
        Return CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound
    End Function

End Class
