﻿Public Class Difficulty

    Dim divideChance, minimumNumber, maximumNumber As Single
    Dim decimalPlaces As Boolean

    Sub New(ByVal divideChance As Single, ByVal minimumNumber As Single, ByVal maximumNumber As Single, ByVal decimalPlaces As Boolean)
        Me.divideChance = divideChance
        Me.minimumNumber = If(decimalPlaces, minimumNumber * 10, minimumNumber)
        Me.maximumNumber = If(decimalPlaces, maximumNumber * 10, maximumNumber)
        Me.decimalPlaces = decimalPlaces
    End Sub

    Public Function getNewQuestion() As Tuple(Of String, Single)
        Dim numberOne As Single = getRandomNumber(minimumNumber, maximumNumber)
        Dim numberTwo As Single = getRandomNumber(minimumNumber, maximumNumber)

        If decimalPlaces Then
            numberOne = numberOne / 10
            numberTwo = numberTwo / 10
        End If

        Dim randomOperator As String = getRandomOperator()
        Dim answer As Single

        If randomOperator = "/" Then
            If numberTwo > numberOne Then
                Dim numberOneCopy As Single = numberOne
                numberOne = numberTwo
                numberTwo = numberOneCopy
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

        Dim question As String = SuperSimpleRubbishFormat(numberOne) & " " & randomOperator & " " & SuperSimpleRubbishFormat(numberTwo)
        Return New Tuple(Of String, Single)(question, answer)
    End Function

    Public Function getRandomOperator() As String
        Dim randomNumber As Integer = getRandomNumber(0, 100)
        Dim otherChance As Single = (100 - divideChance) / 3

        MsgBox("RanNum: " & randomNumber & vbCrLf & "DivCh: " & divideChance & vbCrLf & "Other Chance: " & otherChance)

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

    Public Shared Function SuperSimpleRubbishFormat(ByVal number As Single) As String
        Return FormatNumber(number, If(number = CInt(number), 0, 2)) 'Check if number has precision
    End Function

    Public Shared Function getRandomNumber(ByVal lowerBound As Integer, ByVal upperBound As Integer) As Integer
        Randomize()
        Return CInt(Math.Floor((upperBound - lowerBound + 1) * Rnd())) + lowerBound
    End Function

End Class
