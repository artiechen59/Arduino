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
        Me.Speed = New System.Windows.Forms.TextBox()
        Me.Stop_Btn = New System.Windows.Forms.Button()
        Me.Motor_Speed_Bar = New System.Windows.Forms.TrackBar()
        Me.TurnRight = New System.Windows.Forms.Button()
        Me.TurnLeft = New System.Windows.Forms.Button()
        Me.DriveBackward = New System.Windows.Forms.Button()
        Me.DriveForward = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Servo1_Bar = New System.Windows.Forms.TrackBar()
        Me.Servo2_Bar = New System.Windows.Forms.TrackBar()
        Me.Servo3_Bar = New System.Windows.Forms.TrackBar()
        Me.Servo4_Bar = New System.Windows.Forms.TrackBar()
        Me.Servo5_Bar = New System.Windows.Forms.TrackBar()
        Me.Servo6_Bar = New System.Windows.Forms.TrackBar()
        Me.Servo7_Bar = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Servo1_Text = New System.Windows.Forms.TextBox()
        Me.Servo2_Text = New System.Windows.Forms.TextBox()
        Me.Servo3_Text = New System.Windows.Forms.TextBox()
        Me.Servo4_Text = New System.Windows.Forms.TextBox()
        Me.Servo5_Text = New System.Windows.Forms.TextBox()
        Me.Servo6_Text = New System.Windows.Forms.TextBox()
        Me.Servo7_Text = New System.Windows.Forms.TextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.Motor_Speed_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Servo1_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Servo2_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Servo3_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Servo4_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Servo5_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Servo6_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Servo7_Bar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Speed
        '
        Me.Speed.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Speed.Location = New System.Drawing.Point(46, 709)
        Me.Speed.Margin = New System.Windows.Forms.Padding(4)
        Me.Speed.Name = "Speed"
        Me.Speed.Size = New System.Drawing.Size(58, 22)
        Me.Speed.TabIndex = 5
        Me.Speed.Text = "100"
        Me.Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Stop_Btn
        '
        Me.Stop_Btn.Location = New System.Drawing.Point(145, 153)
        Me.Stop_Btn.Name = "Stop_Btn"
        Me.Stop_Btn.Size = New System.Drawing.Size(84, 66)
        Me.Stop_Btn.TabIndex = 6
        Me.Stop_Btn.Text = "Stop"
        Me.Stop_Btn.UseVisualStyleBackColor = True
        '
        'Motor_Speed_Bar
        '
        Me.Motor_Speed_Bar.Location = New System.Drawing.Point(57, 546)
        Me.Motor_Speed_Bar.Maximum = 255
        Me.Motor_Speed_Bar.Name = "Motor_Speed_Bar"
        Me.Motor_Speed_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Motor_Speed_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Motor_Speed_Bar.TabIndex = 7
        Me.Motor_Speed_Bar.Value = 100
        '
        'TurnRight
        '
        Me.TurnRight.AutoSize = True
        Me.TurnRight.BackColor = System.Drawing.Color.White
        Me.TurnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TurnRight.ForeColor = System.Drawing.Color.White
        Me.TurnRight.Image = Global.WiFi_Car_Controller.My.Resources.Resources.right1
        Me.TurnRight.Location = New System.Drawing.Point(232, 123)
        Me.TurnRight.Margin = New System.Windows.Forms.Padding(0)
        Me.TurnRight.Name = "TurnRight"
        Me.TurnRight.Size = New System.Drawing.Size(121, 121)
        Me.TurnRight.TabIndex = 3
        Me.TurnRight.UseVisualStyleBackColor = False
        '
        'TurnLeft
        '
        Me.TurnLeft.AutoSize = True
        Me.TurnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TurnLeft.ForeColor = System.Drawing.Color.White
        Me.TurnLeft.Image = Global.WiFi_Car_Controller.My.Resources.Resources.left
        Me.TurnLeft.Location = New System.Drawing.Point(21, 123)
        Me.TurnLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.TurnLeft.Name = "TurnLeft"
        Me.TurnLeft.Size = New System.Drawing.Size(121, 121)
        Me.TurnLeft.TabIndex = 4
        Me.TurnLeft.UseVisualStyleBackColor = False
        '
        'DriveBackward
        '
        Me.DriveBackward.AutoSize = True
        Me.DriveBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DriveBackward.ForeColor = System.Drawing.Color.White
        Me.DriveBackward.Image = Global.WiFi_Car_Controller.My.Resources.Resources.back1
        Me.DriveBackward.Location = New System.Drawing.Point(132, 226)
        Me.DriveBackward.Margin = New System.Windows.Forms.Padding(4)
        Me.DriveBackward.Name = "DriveBackward"
        Me.DriveBackward.Size = New System.Drawing.Size(108, 113)
        Me.DriveBackward.TabIndex = 2
        Me.DriveBackward.UseVisualStyleBackColor = True
        '
        'DriveForward
        '
        Me.DriveForward.AutoSize = True
        Me.DriveForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DriveForward.ForeColor = System.Drawing.Color.White
        Me.DriveForward.Image = Global.WiFi_Car_Controller.My.Resources.Resources.for3
        Me.DriveForward.Location = New System.Drawing.Point(132, 33)
        Me.DriveForward.Margin = New System.Windows.Forms.Padding(4)
        Me.DriveForward.Name = "DriveForward"
        Me.DriveForward.Size = New System.Drawing.Size(108, 113)
        Me.DriveForward.TabIndex = 1
        Me.DriveForward.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 518)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 25)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Speed"
        '
        'Servo1_Bar
        '
        Me.Servo1_Bar.Location = New System.Drawing.Point(181, 546)
        Me.Servo1_Bar.Maximum = 180
        Me.Servo1_Bar.Name = "Servo1_Bar"
        Me.Servo1_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Servo1_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Servo1_Bar.TabIndex = 9
        '
        'Servo2_Bar
        '
        Me.Servo2_Bar.Location = New System.Drawing.Point(283, 546)
        Me.Servo2_Bar.Maximum = 180
        Me.Servo2_Bar.Name = "Servo2_Bar"
        Me.Servo2_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Servo2_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Servo2_Bar.TabIndex = 10
        '
        'Servo3_Bar
        '
        Me.Servo3_Bar.Location = New System.Drawing.Point(386, 546)
        Me.Servo3_Bar.Maximum = 180
        Me.Servo3_Bar.Name = "Servo3_Bar"
        Me.Servo3_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Servo3_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Servo3_Bar.TabIndex = 11
        '
        'Servo4_Bar
        '
        Me.Servo4_Bar.Location = New System.Drawing.Point(57, 799)
        Me.Servo4_Bar.Maximum = 180
        Me.Servo4_Bar.Name = "Servo4_Bar"
        Me.Servo4_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Servo4_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Servo4_Bar.TabIndex = 12
        '
        'Servo5_Bar
        '
        Me.Servo5_Bar.Location = New System.Drawing.Point(183, 799)
        Me.Servo5_Bar.Maximum = 180
        Me.Servo5_Bar.Name = "Servo5_Bar"
        Me.Servo5_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Servo5_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Servo5_Bar.TabIndex = 13
        '
        'Servo6_Bar
        '
        Me.Servo6_Bar.Location = New System.Drawing.Point(283, 799)
        Me.Servo6_Bar.Maximum = 180
        Me.Servo6_Bar.Name = "Servo6_Bar"
        Me.Servo6_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Servo6_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Servo6_Bar.TabIndex = 14
        '
        'Servo7_Bar
        '
        Me.Servo7_Bar.Location = New System.Drawing.Point(389, 799)
        Me.Servo7_Bar.Maximum = 180
        Me.Servo7_Bar.Name = "Servo7_Bar"
        Me.Servo7_Bar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.Servo7_Bar.Size = New System.Drawing.Size(56, 146)
        Me.Servo7_Bar.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 518)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 25)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Servo 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(259, 518)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 25)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Servo 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(362, 518)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 25)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Servo 3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(33, 771)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 25)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Servo 4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(159, 771)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 25)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Servo 5"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(259, 771)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 25)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Servo 6"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(365, 771)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 25)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Servo 7"
        '
        'Servo1_Text
        '
        Me.Servo1_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Servo1_Text.Location = New System.Drawing.Point(162, 709)
        Me.Servo1_Text.Name = "Servo1_Text"
        Me.Servo1_Text.Size = New System.Drawing.Size(64, 22)
        Me.Servo1_Text.TabIndex = 23
        Me.Servo1_Text.Text = "0"
        Me.Servo1_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Servo2_Text
        '
        Me.Servo2_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Servo2_Text.Location = New System.Drawing.Point(264, 709)
        Me.Servo2_Text.Name = "Servo2_Text"
        Me.Servo2_Text.Size = New System.Drawing.Size(63, 22)
        Me.Servo2_Text.TabIndex = 24
        Me.Servo2_Text.Text = "0"
        Me.Servo2_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Servo3_Text
        '
        Me.Servo3_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Servo3_Text.Location = New System.Drawing.Point(367, 709)
        Me.Servo3_Text.Name = "Servo3_Text"
        Me.Servo3_Text.Size = New System.Drawing.Size(65, 22)
        Me.Servo3_Text.TabIndex = 25
        Me.Servo3_Text.Text = "0"
        Me.Servo3_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Servo4_Text
        '
        Me.Servo4_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Servo4_Text.Location = New System.Drawing.Point(42, 962)
        Me.Servo4_Text.Name = "Servo4_Text"
        Me.Servo4_Text.Size = New System.Drawing.Size(61, 22)
        Me.Servo4_Text.TabIndex = 26
        Me.Servo4_Text.Text = "0"
        Me.Servo4_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Servo5_Text
        '
        Me.Servo5_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Servo5_Text.Location = New System.Drawing.Point(166, 962)
        Me.Servo5_Text.Name = "Servo5_Text"
        Me.Servo5_Text.Size = New System.Drawing.Size(65, 22)
        Me.Servo5_Text.TabIndex = 27
        Me.Servo5_Text.Text = "0"
        Me.Servo5_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Servo6_Text
        '
        Me.Servo6_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Servo6_Text.Location = New System.Drawing.Point(266, 962)
        Me.Servo6_Text.Name = "Servo6_Text"
        Me.Servo6_Text.Size = New System.Drawing.Size(66, 22)
        Me.Servo6_Text.TabIndex = 28
        Me.Servo6_Text.Text = "0"
        Me.Servo6_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Servo7_Text
        '
        Me.Servo7_Text.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Servo7_Text.Location = New System.Drawing.Point(372, 962)
        Me.Servo7_Text.Name = "Servo7_Text"
        Me.Servo7_Text.Size = New System.Drawing.Size(65, 22)
        Me.Servo7_Text.TabIndex = 29
        Me.Servo7_Text.Text = "0"
        Me.Servo7_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(497, 13)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1393, 1010)
        Me.WebBrowser1.TabIndex = 30
        Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1902, 1035)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Servo7_Text)
        Me.Controls.Add(Me.Servo6_Text)
        Me.Controls.Add(Me.Servo5_Text)
        Me.Controls.Add(Me.Servo4_Text)
        Me.Controls.Add(Me.Servo3_Text)
        Me.Controls.Add(Me.Servo2_Text)
        Me.Controls.Add(Me.Servo1_Text)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Servo7_Bar)
        Me.Controls.Add(Me.Servo6_Bar)
        Me.Controls.Add(Me.Servo5_Bar)
        Me.Controls.Add(Me.Servo4_Bar)
        Me.Controls.Add(Me.Servo3_Bar)
        Me.Controls.Add(Me.Servo2_Bar)
        Me.Controls.Add(Me.Servo1_Bar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Motor_Speed_Bar)
        Me.Controls.Add(Me.Stop_Btn)
        Me.Controls.Add(Me.Speed)
        Me.Controls.Add(Me.TurnRight)
        Me.Controls.Add(Me.TurnLeft)
        Me.Controls.Add(Me.DriveBackward)
        Me.Controls.Add(Me.DriveForward)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Artie's Robot Control"
        CType(Me.Motor_Speed_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Servo1_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Servo2_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Servo3_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Servo4_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Servo5_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Servo6_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Servo7_Bar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DriveForward As System.Windows.Forms.Button
    Friend WithEvents DriveBackward As System.Windows.Forms.Button
    Friend WithEvents TurnLeft As System.Windows.Forms.Button
    Friend WithEvents TurnRight As System.Windows.Forms.Button
    Friend WithEvents Speed As System.Windows.Forms.TextBox
    Friend WithEvents Stop_Btn As System.Windows.Forms.Button
    Friend WithEvents Motor_Speed_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Servo1_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Servo2_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Servo3_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Servo4_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Servo5_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Servo6_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Servo7_Bar As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Servo1_Text As System.Windows.Forms.TextBox
    Friend WithEvents Servo2_Text As System.Windows.Forms.TextBox
    Friend WithEvents Servo3_Text As System.Windows.Forms.TextBox
    Friend WithEvents Servo4_Text As System.Windows.Forms.TextBox
    Friend WithEvents Servo5_Text As System.Windows.Forms.TextBox
    Friend WithEvents Servo6_Text As System.Windows.Forms.TextBox
    Friend WithEvents Servo7_Text As System.Windows.Forms.TextBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser

End Class
