Imports System.IO.Ports
Imports System.Timers
Imports System.Threading


Public Class Form1

    Dim ai0 As Integer
    Dim ai1 As Integer
    Dim ai2 As Integer
    Dim ai3 As Integer
    Dim ai4 As Integer
    Dim ai5 As Integer
    Dim i As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SerialPort1.PortName = "COM5"
        SerialPort1.BaudRate = 115200

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label1.Text = ai0
        Label2.Text = ai1
        Label3.Text = ai2

        Label27.Text = ai3
        Label28.Text = ai4
        Label29.Text = ai5




        Label10.Text = i

        If Chart3.Series(0).Points.Count > 50 Then
            Chart3.ChartAreas(0).AxisX.ScaleView.Position = Chart3.Series(0).Points.Count - 50
            Chart3.ChartAreas(0).AxisX.ScaleView.Size = 50
            Chart3.ChartAreas(0).AxisX.ScrollBar.Enabled = False
        End If

        Me.Chart3.Series("ai0").Points.Add(ai0)
        Me.Chart3.Series("ai1").Points.Add(ai1)
        Me.Chart3.Series("ai2").Points.Add(ai2)
        Me.Chart3.Series("ai3").Points.Add(ai3)
        Me.Chart3.Series("ai4").Points.Add(ai4)
        Me.Chart3.Series("ai5").Points.Add(ai5)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.BackgroundWorker1.RunWorkerAsync()
        Timer1.Interval = 150
        Timer1.Start()
        Button1.Enabled = 0

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Timer1.Stop()

        If BackgroundWorker1.IsBusy Then

            If BackgroundWorker1.WorkerSupportsCancellation Then
                BackgroundWorker1.CancelAsync()
            End If
        End If

        Button1.Enabled = 1

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        SerialPort1.Open()

        Do

            SerialPort1.Write(0)
            ai0 = SerialPort1.ReadLine
            'Thread.Sleep(10)

            SerialPort1.Write(1)
            ai1 = SerialPort1.ReadLine
            'Thread.Sleep(10)

            SerialPort1.Write(2)
            ai2 = SerialPort1.ReadLine
            'Thread.Sleep(10)

            SerialPort1.Write(3)
            ai3 = SerialPort1.ReadLine
            'Thread.Sleep(10)

            SerialPort1.Write(4)
            ai4 = SerialPort1.ReadLine
            'Thread.Sleep(10)

            SerialPort1.Write(5)
            ai5 = SerialPort1.ReadLine
            'Thread.Sleep(10)

            i = i + 1

            BackgroundWorker1.WorkerSupportsCancellation = True
            If BackgroundWorker1.CancellationPending Then
                e.Cancel = True
                SerialPort1.Close()
                Exit Do
            End If

        Loop

    End Sub

End Class
