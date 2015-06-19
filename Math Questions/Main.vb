Public Class Main

    Dim difficulties As New Dictionary(Of String, Difficulty)

    Public maxQuestions As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        difficulties.Add("Beginner", New Difficulty(0, 0, 1, 5, False))
        difficulties.Add("Easy", New Difficulty(10, 2, 5, 10, False))
        difficulties.Add("Intermediate", New Difficulty(15, 3, 10, 20, False))
        difficulties.Add("Hard", New Difficulty(20, 6, 20, 50, False))
        difficulties.Add("Impossible", New Difficulty(25, 3, 50, 200, True))

        For Each difficulty As String In difficulties.Keys
            difficultySelector.Items.Add(difficulty)
        Next

        difficultySelector.SelectedIndex = 0
    End Sub

    Private Sub NumberOfQuestionsInput_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles numberOfQuestionsInput.KeyPress
        If Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                e.Handled = True
                start()
            ElseIf Not IsNumeric(e.KeyChar) Then
                e.Handled = True
                Media.SystemSounds.Exclamation.Play()
            End If
        End If
    End Sub

    Public Sub start() Handles startButton.Click
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
