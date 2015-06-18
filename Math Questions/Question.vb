Public Class Question

    Dim main As Main
    Dim questionNumber As Integer
    Dim question As Tuple(Of String, Single)

    Sub New(ByVal main As Main, ByVal questionNumber As Integer, ByVal question As Tuple(Of String, Single))
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.main = main
        Me.questionNumber = questionNumber
        Me.question = question

        questionLabel.Text = question.Item1
        Name = "#" & questionNumber & ": " & question.Item1
    End Sub

    Private Sub EnterButton_Click(sender As Object, e As EventArgs) Handles EnterButton.Click
        Dim userAttempt As Single = Val(AnswerInput.Text)

        If userAttempt = question.Item2 Then
            If questionNumber < main.maxQuestions Then
                If Not TextBoxGreen.IsBusy Then
                    TextBoxGreen.RunWorkerAsync()
                Else
                    newQuestion()
                End If
            Else
                    MsgBox("All done. (maybe show some statistics here in future).")
            End If
        Else
            If Not TextBoxRed.IsBusy Then
                TextBoxRed.RunWorkerAsync()
            End If

            lastAttemptLabel.Text = "Last Attempt: " & vbCrLf & FormatNumber(userAttempt)
        End If
    End Sub

    Private Sub SkipButton_Click(sender As Object, e As EventArgs) Handles SkipButton.Click
        newQuestion()
    End Sub

    Private Sub newQuestion()
        Visible = False
        main.newQuestion(questionNumber + 1)
    End Sub

    Private Sub AnswerInput_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles AnswerInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            newQuestion()
        End If
    End Sub

    Private Sub AnswerInput_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles AnswerInput.KeyPress
        If Not e.KeyChar = "." And Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            Media.SystemSounds.Exclamation.Play()
        End If
    End Sub

    Private Sub TextBoxGreen_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles TextBoxGreen.DoWork
        AnswerInput.Invoke(New delegateThing(AddressOf setInputGreen))
        Threading.Thread.Sleep(500)
        Me.Invoke(New delegateThing(AddressOf newQuestion))
    End Sub

    Private Sub TextBoxRed_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles TextBoxRed.DoWork
        AnswerInput.Invoke(New delegateThing(AddressOf setInputRed))
        Threading.Thread.Sleep(500)
        AnswerInput.Invoke(New delegateThing(AddressOf setInputNormal))
    End Sub

    Delegate Sub delegateThing()

    Private Sub setInputGreen()
        AnswerInput.BackColor = Color.Green
    End Sub

    Private Sub setInputRed()
        AnswerInput.BackColor = Color.Red
    End Sub

    Private Sub setInputNormal()
        AnswerInput.BackColor = Color.FromKnownColor(KnownColor.Window)
    End Sub
End Class