<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Me.difficultySelector = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numberOfQuestionsInput = New System.Windows.Forms.TextBox()
        Me.startButton = New System.Windows.Forms.Button()
        Me.Form1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Form1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'difficultySelector
        '
        Me.difficultySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.difficultySelector.FormattingEnabled = True
        Me.difficultySelector.Location = New System.Drawing.Point(109, 10)
        Me.difficultySelector.Name = "difficultySelector"
        Me.difficultySelector.Size = New System.Drawing.Size(121, 21)
        Me.difficultySelector.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Difficulty"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "No. of Questions"
        '
        'numberOfQuestionsInput
        '
        Me.numberOfQuestionsInput.Location = New System.Drawing.Point(109, 47)
        Me.numberOfQuestionsInput.Name = "numberOfQuestionsInput"
        Me.numberOfQuestionsInput.Size = New System.Drawing.Size(121, 20)
        Me.numberOfQuestionsInput.TabIndex = 4
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(109, 81)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(121, 23)
        Me.startButton.TabIndex = 5
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'Form1BindingSource
        '
        Me.Form1BindingSource.DataSource = GetType(WindowsApplication1.Main)
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(252, 124)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.numberOfQuestionsInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.difficultySelector)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Math Questions - By Keir Nellyer"
        CType(Me.Form1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents difficultySelector As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Form1BindingSource As BindingSource
    Friend WithEvents numberOfQuestionsInput As TextBox
    Friend WithEvents startButton As Button
End Class
