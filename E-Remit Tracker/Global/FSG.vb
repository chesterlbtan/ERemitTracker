Option Strict On

Imports System.IO

Public Class FSG

    Private Shared ReadOnly Property FilePath As String
        Get
            Return My.Application.Info.DirectoryPath & "\eremit.fsg"
        End Get
    End Property

    Public Shared Function LogNewData(ByVal MyrToPhpRate As Double, ByVal MyrToIndRate As Double) As Boolean
        Dim TodayDate As Date = Date.Now
        Dim dateInString As String = TodayDate.Month.ToString("D2") & TodayDate.Day.ToString("D2") & TodayDate.Year.ToString("D4")
        Dim data As String = dateInString & vbTab & MyrToPhpRate.ToString("F2") & vbTab & MyrToIndRate.ToString("F2")
        Logger.Log("Successfully log data.")
        Logger.Log(data)
        Try
            If GetLastDate() = Today Then
                Dim contents() As String = System.IO.File.ReadAllLines(FilePath)
                contents(contents.Length - 1) = data
                System.IO.File.WriteAllLines(FilePath, contents)
            Else
                System.IO.File.AppendAllLines(FilePath, {data})
            End If
            Return True
        Catch ex As Exception
            Logger.Log(ex.Message)
            Logger.Log(ex.StackTrace)
            Return False
        End Try
    End Function

    Public Shared Function GetLastDate() As Date
        Dim retDate As New Date
        If System.IO.File.Exists(FilePath) Then
            Dim bytAllData() As Byte = File.ReadAllBytes(FilePath)
            Dim bytData(8) As Byte
            For i As Integer = 0 To 7
                bytData(i) = bytAllData(bytAllData.Length - 24 + i)
            Next

            Dim lastdate As String = ""
            For i As Integer = 0 To 7
                lastdate += Convert.ToChar(bytData(i))
            Next
            retDate = New Date(Integer.Parse(lastdate.Substring(4, 4)), Integer.Parse(lastdate.Substring(0, 2)), Integer.Parse(lastdate.Substring(2, 2)))
            Return retDate
        Else
            MessageBox.Show("No data is available. Please check internet connection")
            Return Nothing
        End If
    End Function

    Public Shared Function GetLastPhp() As Double
        If System.IO.File.Exists(FilePath) Then
            Dim bytAllData() As Byte = File.ReadAllBytes(FilePath)
            Dim bytData(13) As Byte
            For i As Integer = 0 To 13
                bytData(i) = bytAllData(bytAllData.Length - 15 + i)
            Next

            Dim phprate As String = ""
            For i As Integer = 0 To 4
                phprate += Convert.ToChar(bytData(i))
            Next
            Return Convert.ToDouble(phprate)
        Else
            MessageBox.Show("No data is available. Please check internet connection")
            Return 0
        End If
    End Function

    Public Shared Function GetLastInd() As Double
        If System.IO.File.Exists(FilePath) Then
            Dim bytAllData() As Byte = File.ReadAllBytes(FilePath)
            Dim bytData(13) As Byte
            For i As Integer = 0 To 13
                bytData(i) = bytAllData(bytAllData.Length - 15 + i)
            Next

            Dim indrate As String = ""
            For i As Integer = 6 To 12
                indrate += Convert.ToChar(bytData(i))
            Next
            Return Convert.ToDouble(indrate)
        Else
            MessageBox.Show("No data is available. Please check internet connection")
            Return 0
        End If
    End Function
End Class
