Public Class Logger
    Public Shared ReadOnly Property LogPath As String
        Get
            Return My.Application.Info.DirectoryPath & "\Log.txt"
        End Get
    End Property

    Private Shared ReadOnly Property DateTimeNow As String
        Get
            Dim tmpDateTime As Date = Date.Now
            Dim strDateTime As String = tmpDateTime.Month.ToString("D2") & "-" + tmpDateTime.Day.ToString("D2") & "-" & tmpDateTime.Year.ToString("D4") & " "
            strDateTime = strDateTime + tmpDateTime.Hour.ToString("D2") & ":" & tmpDateTime.Minute.ToString("D2") & ":" & tmpDateTime.Second.ToString("D2")
            Return strDateTime
        End Get
    End Property

    Public Shared Sub Log(ByVal strMessage As String)
        If System.IO.File.Exists(LogPath) Then
            System.IO.File.AppendAllText(LogPath, DateTimeNow & " >> " & strMessage & vbCrLf)
        Else
            System.IO.File.WriteAllText(LogPath, DateTimeNow & " >> " & strMessage & vbCrLf)
        End If
    End Sub
End Class
