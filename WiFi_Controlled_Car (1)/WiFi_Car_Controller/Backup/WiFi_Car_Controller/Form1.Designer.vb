<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.DriveForward = New System.Windows.Forms.Button
        Me.DriveBackward = New System.Windows.Forms.Button
        Me.TurnLeft = New System.Windows.Forms.Button
        Me.TurnRight = New System.Windows.Forms.Button
        Me.Speed = New System.Windows.Forms.TextBox
        Me.Control = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'DriveForward
        '
        Me.DriveForward.Location = New System.Drawing.Point(85, 17)
        Me.DriveForward.Name = "DriveForward"
        Me.DriveForward.Size = New System.Drawing.Size(67, 35)
        Me.DriveForward.TabIndex = 1
        Me.DriveForward.Text = "Forward"
        Me.DriveForward.UseVisualStyleBackColor = True
        '
        'DriveBackward
        '
        Me.DriveBackward.Location = New System.Drawing.Point(85, 84)
        Me.DriveBackward.Name = "DriveBackward"
        Me.DriveBackward.Size = New System.Drawing.Size(67, 35)
        Me.DriveBackward.TabIndex = 2
        Me.DriveBackward.Text = "Backward"
        Me.DriveBackward.UseVisualStyleBackColor = True
        '
        'TurnLeft
        '
        Me.TurnLeft.Location = New System.Drawing.Point(33, 50)
        Me.TurnLeft.Name = "TurnLeft"
        Me.TurnLeft.Size = New System.Drawing.Size(46, 35)
        Me.TurnLeft.TabIndex = 4
        Me.TurnLeft.Text = "Left"
        Me.TurnLeft.UseVisualStyleBackColor = True
        '
        'TurnRight
        '
        Me.TurnRight.Location = New System.Drawing.Point(158, 50)
        Me.TurnRight.Name = "TurnRight"
        Me.TurnRight.Size = New System.Drawing.Size(46, 35)
        Me.TurnRight.TabIndex = 3
        Me.TurnRight.Text = "Right"
        Me.TurnRight.UseVisualStyleBackColor = True
        '
        'Speed
        '
        Me.Speed.Location = New System.Drawing.Point(85, 58)
        Me.Speed.Name = "Speed"
        Me.Speed.Size = New System.Drawing.Size(67, 20)
        Me.Speed.TabIndex = 5
        Me.Speed.Text = "80"
        Me.Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Control
        '
        Me.Control.Location = New System.Drawing.Point(12, 107)
        Me.Control.Name = "Control"
        Me.Control.Size = New System.Drawing.Size(21, 20)
        Me.Control.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 139)
        Me.Controls.Add(Me.Control)
        Me.Controls.Add(Me.Speed)
        Me.Controls.Add(Me.TurnRight)
        Me.Controls.Add(Me.TurnLeft)
        Me.Controls.Add(Me.DriveBackward)
        Me.Controls.Add(Me.DriveForward)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DriveForward As System.Windows.Forms.Button
    Friend WithEvents DriveBackward As System.Windows.Forms.Button
    Friend WithEvents TurnLeft As System.Windows.Forms.Button
    Friend WithEvents TurnRight As System.Windows.Forms.Button
    Friend WithEvents Speed As System.Windows.Forms.TextBox
    Friend WithEvents Control As System.Windows.Forms.TextBox

End Class
