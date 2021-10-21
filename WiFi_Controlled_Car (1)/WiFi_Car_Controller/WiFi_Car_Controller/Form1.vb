Imports System.Net.Sockets
Imports System.Text

Public Class Form1
    Dim tcpClient As New System.Net.Sockets.TcpClient()
    Dim networkStream As NetworkStream
    Dim KeyPressed As Integer

    Private Function Arduino_Connect(ByVal IP As String, ByVal Port As Integer) As Boolean
        tcpClient.Connect(IP, Port)
        networkStream = tcpClient.GetStream()
        If Not networkStream.CanWrite Or Not networkStream.CanRead Then
            tcpClient.Close()
            networkStream = Nothing
            Return False
        End If
        Return True
    End Function

    Private Sub Arduino_Write(ByVal Output As String)
        If Not IsNothing(networkStream) Then
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(Output)
            Dim endByte As [Byte]() = {&HFE}
            networkStream.Write(sendBytes, 0, sendBytes.Length)
            networkStream.Write(endByte, 0, 1)
        Else
            MsgBox("ERROR")
        End If
    End Sub

    Private Sub Arduino_Disconnect()
        If Not IsNothing(networkStream) Then
            tcpClient.Close()
            networkStream = Nothing
        End If
    End Sub

    Private Sub Car_ForwardDrive(ByVal Speed As String)
        Arduino_Write("F" & Speed)
    End Sub

    Private Sub Car_BackwardDrive(ByVal Speed As String)
        Arduino_Write("B" & Speed)
    End Sub

    Private Sub Car_Stop()
        Arduino_Write("S")
    End Sub

    Private Sub Car_TurnRight(ByVal Speed As String)
        Arduino_Write("R" & Speed)
    End Sub

    Private Sub Car_TurnLeft(ByVal Speed As String)
        Arduino_Write("L" & Speed)
    End Sub

    Private Sub Car_TurnNone()
        Arduino_Write("TN")
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Arduino_Connect("192.168.11.11", 1000)  'office
        Arduino_Connect("192.168.2.22", 1000)  'home
    End Sub

    Private Sub DriveForward_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveForward.MouseDown
        Car_ForwardDrive(Speed.Text)
    End Sub

    Private Sub DriveForward_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveForward.MouseUp
        'Car_Stop()
    End Sub

    Private Sub DriveBackward_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveBackward.MouseDown
        Car_BackwardDrive(Speed.Text)
    End Sub

    Private Sub DriveBackward_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveBackward.MouseUp
        'Car_Stop()
    End Sub

    Private Sub TurnLeft_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnLeft.MouseDown
        Car_TurnLeft(Speed.Text)
    End Sub

    Private Sub TurnLeft_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnLeft.MouseUp
        'Car_TurnNone()
    End Sub

    Private Sub TurnRight_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnRight.MouseDown
        Car_TurnRight(Speed.Text)
    End Sub

    Private Sub TurnRight_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnRight.MouseUp
        'Car_TurnNone()
    End Sub

    Private Sub Control_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        KeyPressed = e.KeyCode
        Select Case KeyPressed
            Case 38 ' Up
                Car_ForwardDrive(Speed.Text)
            Case 40 ' Down
                Car_BackwardDrive(Speed.Text)
            Case 39 ' Right
                Car_TurnRight(Speed.Text)
            Case 37 ' Left
                Car_TurnLeft(Speed.Text)
        End Select
    End Sub

    Private Sub Control_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case KeyPressed
            Case 38 ' Up
                Car_Stop()
            Case 40 ' Down
                Car_Stop()
            Case 39 ' Right
                Car_TurnNone()
            Case 37 ' Left
                Car_TurnNone()
        End Select
        KeyPressed = 0
    End Sub
    Private Sub Stop_Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Stop_Btn.Click
        Arduino_Write("S")
    End Sub


    Private Sub Motor_Speed_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Motor_Speed_Bar.Scroll
        Speed.Text = Motor_Speed_Bar.Value
    End Sub
    Private Sub Servo3_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servo3_Bar.Scroll
        Servo3_Text.Text = Servo3_Bar.Value
    End Sub

    Private Sub Servo4_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servo4_Bar.Scroll
        Servo4_Text.Text = Servo4_Bar.Value
    End Sub

    Private Sub Servo5_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servo5_Bar.Scroll
        Servo5_Text.Text = Servo5_Bar.Value
    End Sub

    Private Sub Servo6_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servo6_Bar.Scroll
        Servo6_Text.Text = Servo6_Bar.Value
    End Sub

    Private Sub Servo7_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servo7_Bar.Scroll
        Servo7_Text.Text = Servo7_Bar.Value
    End Sub

    Private Sub Servo1_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servo1_Bar.Scroll
        Servo1_Text.Text = Servo1_Bar.Value
        Arduino_Write("O1" & Servo1_Text.Text)
    End Sub

    Private Sub Servo2_Bar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Servo2_Bar.Scroll
        Servo2_Text.Text = Servo2_Bar.Value
    End Sub
End Class



