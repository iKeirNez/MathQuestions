<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Question
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.questionLabel = New System.Windows.Forms.Label()
        Me.lastAttemptLabel = New System.Windows.Forms.Label()
        Me.AnswerInput = New System.Windows.Forms.TextBox()
        Me.SkipButton = New System.Windows.Forms.Button()
        Me.EnterButton = New System.Windows.Forms.Button()
        Me.TextBoxGreen = New System.ComponentModel.BackgroundWorker()
        Me.TextBoxRed = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'questionLabel
        '
        Me.questionLabel.AutoSize = True
        Me.questionLabel.Location = New System.Drawing.Point(13, 13)
        Me.questionLabel.Name = "questionLabel"
        Me.questionLabel.Size = New System.Drawing.Size(49, 13)
        Me.questionLabel.TabIndex = 0
        Me.questionLabel.Text = "Question"
        '
        'lastAttemptLabel
        '
        Me.lastAttemptLabel.AutoSize = True
        Me.lastAttemptLabel.Location = New System.Drawing.Point(148, 9)
        Me.lastAttemptLabel.Name = "lastAttemptLabel"
        Me.lastAttemptLabel.Size = New System.Drawing.Size(66, 26)
        Me.lastAttemptLabel.TabIndex = 1
        Me.lastAttemptLabel.Text = "Last Attempt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "N/A"
        '
        'AnswerInput
        '
        Me.AnswerInput.Location = New System.Drawing.Point(16, 43)
        Me.AnswerInput.Name = "AnswerInput"
        Me.AnswerInput.Size = New System.Drawing.Size(198, 20)
        Me.AnswerInput.TabIndex = 2
        '
        'SkipButton
        '
        Me.SkipButton.Location = New System.Drawing.Point(16, 86)
        Me.SkipButton.Name = "SkipButton"
        Me.SkipButton.Size = New System.Drawing.Size(75, 23)
        Me.SkipButton.TabIndex = 3
        Me.SkipButton.Text = "Skip"
        Me.SkipButton.UseVisualStyleBackColor = True
        '
        'EnterButton
        '
        Me.EnterButton.Location = New System.Drawing.Point(139, 86)
        Me.EnterButton.Name = "EnterButton"
        Me.EnterButton.Size = New System.Drawing.Size(75, 23)
        Me.EnterButton.TabIndex = 4
        Me.EnterButton.Text = "Enter"
        Me.EnterButton.UseVisualStyleBackColor = True
        '
        'TextBoxGreen
        '
        '
        'TextBoxRed
        '
        '
        'Question
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 125)
        Me.Controls.Add(Me.EnterButton)
        Me.Controls.Add(Me.SkipButton)
        Me.Controls.Add(Me.AnswerInput)
        Me.Controls.Add(Me.lastAttemptLabel)
        Me.Controls.Add(Me.questionLabel)
        Me.Name = "Question"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Question"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents questionLabel As Label
    Friend WithEvents lastAttemptLabel As Label
    Friend WithEvents AnswerInput As TextBox
    Friend WithEvents SkipButton As Button
    Friend WithEvents EnterButton As Button
    Friend WithEvents TextBoxGreen As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextBoxRed As System.ComponentModel.BackgroundWorker
End Class
