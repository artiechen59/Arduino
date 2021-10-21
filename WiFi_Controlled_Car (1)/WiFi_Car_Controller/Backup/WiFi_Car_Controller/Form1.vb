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

    Private Sub Car_ForwardDrive(ByVal Speed As Byte)
        Arduino_Write("DF" & Chr(Speed))
    End Sub

    Private Sub Car_BackwardDrive(ByVal Speed As Byte)
        Arduino_Write("DB" & Chr(Speed))
    End Sub

    Private Sub Car_Stop()
        Arduino_Write("DF" & Chr(0))
    End Sub

    Private Sub Car_TurnRight()
        Arduino_Write("TR")
    End Sub

    Private Sub Car_TurnLeft()
        Arduino_Write("TL")
    End Sub

    Private Sub Car_TurnNone()
        Arduino_Write("TN")
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Arduino_Connect("192.168.0.25", 1000)
    End Sub

    Private Sub DriveForward_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveForward.MouseDown
        Car_ForwardDrive(Speed.Text)
    End Sub

    Private Sub DriveForward_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveForward.MouseUp
        Car_Stop()
    End Sub

    Private Sub DriveBackward_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveBackward.MouseDown
        Car_BackwardDrive(Speed.Text)
    End Sub

    Private Sub DriveBackward_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DriveBackward.MouseUp
        Car_Stop()
    End Sub

    Private Sub TurnLeft_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnLeft.MouseDown
        Car_TurnLeft()
    End Sub

    Private Sub TurnLeft_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnLeft.MouseUp
        Car_TurnNone()
    End Sub

    Private Sub TurnRight_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnRight.MouseDown
        Car_TurnRight()
    End Sub

    Private Sub TurnRight_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TurnRight.MouseUp
        Car_TurnNone()
    End Sub

    Private Sub Control_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Control.KeyDown
        KeyPressed = e.KeyCode
        Select Case KeyPressed
            Case 38 ' Up
                Car_ForwardDrive(Speed.Text)
            Case 40 ' Down
                Car_BackwardDrive(Speed.Text)
            Case 39 ' Right
                Car_TurnRight()
            Case 37 ' Left
                Car_TurnLeft()
        End Select
    End Sub

    Private Sub Control_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Control.KeyUp
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
End Class

