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
        checkInput()
    End Sub

    Public Sub checkInput()
        Dim userAttempt As Single = Val(AnswerInput.Text)

        If userAttempt = question.Item2 Then
            If questionNumber < main.maxQuestions Then
                If Not InputGreenBackgroundWorker.IsBusy Then
                    InputGreenBackgroundWorker.RunWorkerAsync()
                Else
                    newQuestion()
                End If
            Else
                MsgBox("All done. (maybe show some statistics here in future).")
            End If
        Else
            If InputRedBackgroundWorker.IsBusy And Not InputRedBackgroundWorker.CancellationPending Then
                InputRedBackgroundWorker.CancelAsync()
            End If

            While InputRedBackgroundWorker.IsBusy Or InputRedBackgroundWorker.CancellationPending
                Application.DoEvents() 'Keep UI responsive
            End While

            InputRedBackgroundWorker.RunWorkerAsync()
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

    Private Sub AnswerInput_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles AnswerInput.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            checkInput()
        ElseIf Not e.KeyChar = "." And Not IsNumeric(e.KeyChar) And Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
            Media.SystemSounds.Exclamation.Play()
        End If
    End Sub

    Private Sub InputGreenBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles InputGreenBackgroundWorker.DoWork
        AnswerInput.Invoke(Sub() AnswerInput.BackColor = Color.Green)
        Threading.Thread.Sleep(500)
        Me.Invoke(Sub() newQuestion())
    End Sub

    Private Sub InputRedBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles InputRedBackgroundWorker.DoWork
        AnswerInput.Invoke(Sub() AnswerInput.BackColor = Color.Red)
        Threading.Thread.Sleep(500)
        AnswerInput.Invoke(Sub() AnswerInput.BackColor = Color.FromKnownColor(KnownColor.Window))
    End Sub

End Class