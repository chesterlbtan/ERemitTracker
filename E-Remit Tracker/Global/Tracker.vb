Imports AutoUpdateExe

Public Class Tracker
    Private Const eremitURL As String = "https://api.eremit.com.my/EremitService.svc/GetExchangeRates"
    Private Const lineReference As String = """CurrencyName"":""PHP"""

    Public Shared Function IsSiteAvailable(ByRef MyrToPhpRate As Double, ByRef MyrToIndRate As Double) As Boolean
        Dim wrGetURL As System.Net.WebRequest
        Dim objStream As System.IO.Stream
        Dim sLine As String = ""
        wrGetURL = System.Net.WebRequest.Create(eremitURL)

        Try
            System.Net.ServicePointManager.Expect100Continue = True
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
            wrGetURL.Proxy = System.Net.WebRequest.GetSystemWebProxy
            objStream = wrGetURL.GetResponse.GetResponseStream

            Using objreader As System.IO.StreamReader = New System.IO.StreamReader(objStream)
                Do While Not sLine Is Nothing
                    sLine = objreader.ReadLine
                    If sLine.Contains(lineReference) Then
                        Exit Do
                    End If
                Loop
            End Using
        Catch ex As Exception
            Logger.Log(ex.Message)
            Logger.Log(ex.StackTrace)
            Return False
        End Try

        'Dim refIndStart As Integer = sLine.IndexOf("<font size=""1"">PKR</font>")
        Dim refIndEnd As Integer = sLine.IndexOf(",""FlagCode"":""ph")
        'sLine = sLine.Substring(refIndStart, refIndEnd - refIndStart)
        MyrToPhpRate = sLine.Substring(refIndEnd - 7, 7)

        refIndEnd = sLine.IndexOf(",""FlagCode"":""id")
        MyrToIndRate = sLine.Substring(refIndEnd - 9, 9)
        Return True
    End Function

    Public Shared Function LogChanges(ByVal MyrToPhpRate As Double, ByVal MyrToIndRate As Double) As Boolean
        If FSG.GetLastDate <> Today Or FSG.GetLastPhp <> MyrToPhpRate Then
            If FSG.LogNewData(MyrToPhpRate, MyrToIndRate) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Sub UpdateNow()
        Try

            Dim mypath As String = Application.ExecutablePath
            Dim processName As String = "E-Remit Tracker.exe"
            Dim link As String = System.IO.File.ReadAllText("Settings.txt")
            AutoUpdateExe.Update.UpdateAction(link, mypath, processName)
            IsInformed = False
        Catch ex As Exception
            MessageBox.Show("Update FAILED!")
        End Try
    End Sub

    Private Shared IsInformed As Boolean = False

    Public Shared Function UpdateAvailable() As Boolean
        Try
            If IsInformed Then Return False
            Dim mypath As String = Application.ExecutablePath
            Dim link As String = System.IO.File.ReadAllText("Settings.txt")

            Return AutoUpdateExe.Update.NewUpdateAvailable(link, mypath)
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
