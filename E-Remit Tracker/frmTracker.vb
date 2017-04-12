
Imports System.IO

Public Class frmTracker

    Private WithEvents trayicon As New NotifyIcon
    Private traymenu As New ContextMenu

    Private eremitURL As String = "http://www.e-remit.com.my/"
    Private lineReference As String = "images/countryImages/Philippines.png"
    Private reflineReference As String = "images/countryImages/Indonesia.png"

    Private m_FSG_FilePath As String = My.Application.Info.DirectoryPath & "\eremit.fsg"

    Private WithEvents tmrRefresh As New Timer

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        trayicon.Icon = New Icon(CType(My.Resources.E_Remit, System.Drawing.Icon), 48, 48)
        trayicon.Text = "E-Remit"
        trayicon.Visible = True

        traymenu.MenuItems.Add("Charts", New System.EventHandler(AddressOf menuCharts_Click))
        traymenu.MenuItems.Add("Update Software", New System.EventHandler(AddressOf menuUpdateSoftware_Click))
        traymenu.MenuItems.Add("Run at Startup", New System.EventHandler(AddressOf menuRunAtStartup_Click))
        traymenu.MenuItems.Add("Update", New System.EventHandler(AddressOf tmrRefresh_Elapsed))
        traymenu.MenuItems.Add("Color", New System.EventHandler(AddressOf menuColor_Click))
        traymenu.MenuItems.Add("About", New System.EventHandler(AddressOf menuAbout_Click))
        traymenu.MenuItems.Add("Close", New System.EventHandler(AddressOf menuClose_Click))

        trayicon.ContextMenu = traymenu

        Dim phpRate As Double = FSG.GetLastPhp
        Dim indRate As Double = FSG.GetLastInd

        If Tracker.IsSiteAvailable(phpRate, indRate) Then
            Tracker.LogChanges(phpRate, indRate)
            lblUpdateDate.Text = "Last Update on:" & vbCrLf & DateTime.Now.ToLongDateString() & vbCrLf & DateTime.Now.ToLongTimeString()
        Else
            MessageBox.Show("Failed to get data from e-remit site", "Network Error")
        End If
        lblPhpRate.Text = phpRate.ToString("F2")
        trayicon.Text = phpRate

        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        Dim boolVal As String = regKey.GetValue(Application.ProductName, "none")
        regKey.Close()
        traymenu.MenuItems.Item(1).Checked = Not (boolVal = "none")

        tmrRefresh.Interval = 300000
        tmrRefresh.Start()
    End Sub

    Private Sub frmTracker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub trayicon_DoubleClick(sender As Object, e As EventArgs) Handles trayicon.DoubleClick
        Me.Show()
        Me.TopMost = True
    End Sub

    Private Sub menuRunAtStartup_Click(sender As Object, e As EventArgs)
        Dim newVal As Boolean = Not traymenu.MenuItems.Item(1).Checked
        traymenu.MenuItems.Item(1).Checked = newVal
        If newVal Then
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.SetValue(Application.ProductName, """" & Application.ExecutablePath & """")
            regKey.Close()
        Else
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.DeleteValue(Application.ProductName, False)
            regKey.Close()
        End If
    End Sub

    Private Sub menuColor_Click(sender As Object, e As EventArgs)
        Dim temp As Color = Me.BackColor
        Dim test As New ColorDialog
        If test.ShowDialog() = DialogResult.OK Then
            Me.BackColor = test.Color
        Else

        End If
    End Sub

    Private Sub menuAbout_Click(sender As Object, e As EventArgs)
        Dim aboutBox As New frmAboutBox
        aboutBox.ShowDialog()
    End Sub

    Private Sub menuClose_Click(sender As Object, e As EventArgs)
        trayicon.Dispose()
        Me.Dispose()
    End Sub

    Private Sub menuUpdateSoftware_Click(sender As Object, e As EventArgs)
        Tracker.UpdateNow()
    End Sub

    Private Sub menuCharts_Click(sender As Object, e As EventArgs)
        Dim filepath As String = My.Application.Info.DirectoryPath
        Dim filename As String = "eremit.fsg"
        Dim fullpath As String = filepath & "\" & filename

        Dim strAllData() As String = IO.File.ReadAllLines(fullpath)
        Dim dates As New List(Of Date)
        Dim php As New List(Of Single)
        Dim myr As New List(Of Single)
        For Each line As String In strAllData
            Dim splitted() As String = line.Split(vbTab)
            dates.Add(New Date(splitted(0).Substring(4, 4), splitted(0).Substring(0, 2), splitted(0).Substring(2, 2)))
            php.Add(Convert.ToSingle(splitted(2)) / Convert.ToSingle(splitted(1)))
            myr.Add(Convert.ToSingle(splitted(2)))
        Next

        Dim frmofchart As New frmChart(dates, php, myr)
        frmofchart.Show()
    End Sub

    Private Sub tmrRefresh_Elapsed(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        tmrRefresh.Enabled = False

        Dim phprate As Double
        Dim indrate As Double
        Dim oldRate As Double = FSG.GetLastPhp()
        If Tracker.IsSiteAvailable(phprate, indrate) Then
            If phprate <> oldRate Then
                If phprate > oldRate Then
                    trayicon.ShowBalloonTip(1000, "E-Remit Update", "MYR-PHP increased from " & oldRate.ToString("F2") & " to " & phprate.ToString("F2"), ToolTipIcon.Info)
                Else
                    trayicon.ShowBalloonTip(1000, "E-Remit Update", "MYR-PHP decreased from " & oldRate.ToString("F2") & " to " & phprate.ToString("F2"), ToolTipIcon.Warning)
                End If
            End If
            Tracker.LogChanges(phprate, indrate)
            lblPhpRate.Text = phprate.ToString("F2")
            lblUpdateDate.Text = "Last Update on:" & vbCrLf & DateTime.Now.ToLongDateString() & vbCrLf & DateTime.Now.ToLongTimeString()
            trayicon.Text = phprate
        End If

        'If Tracker.UpdateAvailable() Then
        '    trayicon.ShowBalloonTip(10000, "E-Remit Software Update", "Congratulation! There is a new software upgrade, right click tray icon then click Update Software to download.", ToolTipIcon.Info)
        'End If

        tmrRefresh.Enabled = True
    End Sub



End Class
