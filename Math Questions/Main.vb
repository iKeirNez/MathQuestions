Public Class Main

    Dim difficulties As New Dictionary(Of String, Difficulty)

    Public maxQuestions As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        difficulties.Add("Beginner", New Difficulty(0, 1, 5, False))
        difficulties.Add("Easy", New Difficulty(10, 5, 10, False))
        difficulties.Add("Intermediate", New Difficulty(15, 10, 20, False))
        difficulties.Add("Hard", New Difficulty(20, 20, 50, False))
        difficulties.Add("Impossible", New Difficulty(25, 50, 200, False))

        For Each difficulty As String In difficulties.Keys
            difficultySelector.Items.Add(difficulty)
        Next

        difficultySelector.SelectedIndex = 0
    End Sub

    Private Sub NumberOfQuestionsInput_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles numberOfQuestionsInput.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            start()
        ElseIf Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            Media.SystemSounds.Exclamation.Play()
        End If
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        start()
    End Sub

    Public Sub start()
        maxQuestions = Val(numberOfQuestionsInput.Text)
        numberOfQuestionsInput.Text = ""
        newQuestion(1)
    End Sub

    Public Sub newQuestion(ByVal questionNumber As Integer)
        Dim difficulty As Difficulty = difficulties.Item(difficultySelector.SelectedItem)
        Dim question As New Question(Me, questionNumber, difficulty.getNewQuestion)
        question.Visible = True
    End Sub
End Class
