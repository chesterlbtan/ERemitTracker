<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.chartView = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExchangeRateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MYRToPHPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MYRToINDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PHPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MYRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.trbRange = New System.Windows.Forms.TrackBar()
        CType(Me.chartView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.trbRange, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chartView
        '
        Me.chartView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.Name = "ChartArea1"
        Me.chartView.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartView.Legends.Add(Legend1)
        Me.chartView.Location = New System.Drawing.Point(12, 31)
        Me.chartView.Name = "chartView"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartView.Series.Add(Series1)
        Me.chartView.Size = New System.Drawing.Size(704, 316)
        Me.chartView.TabIndex = 0
        Me.chartView.Text = "Chart1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DisplayToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(728, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DisplayToolStripMenuItem
        '
        Me.DisplayToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExchangeRateToolStripMenuItem, Me.ValueToolStripMenuItem})
        Me.DisplayToolStripMenuItem.Name = "DisplayToolStripMenuItem"
        Me.DisplayToolStripMenuItem.Size = New System.Drawing.Size(70, 24)
        Me.DisplayToolStripMenuItem.Text = "Display"
        '
        'ExchangeRateToolStripMenuItem
        '
        Me.ExchangeRateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MYRToPHPToolStripMenuItem, Me.MYRToINDToolStripMenuItem})
        Me.ExchangeRateToolStripMenuItem.Name = "ExchangeRateToolStripMenuItem"
        Me.ExchangeRateToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ExchangeRateToolStripMenuItem.Text = "Exchange Rate"
        '
        'MYRToPHPToolStripMenuItem
        '
        Me.MYRToPHPToolStripMenuItem.Name = "MYRToPHPToolStripMenuItem"
        Me.MYRToPHPToolStripMenuItem.Size = New System.Drawing.Size(163, 26)
        Me.MYRToPHPToolStripMenuItem.Text = "MYR to PHP"
        '
        'MYRToINDToolStripMenuItem
        '
        Me.MYRToINDToolStripMenuItem.Name = "MYRToINDToolStripMenuItem"
        Me.MYRToINDToolStripMenuItem.Size = New System.Drawing.Size(163, 26)
        Me.MYRToINDToolStripMenuItem.Text = "MYR to IDR"
        '
        'ValueToolStripMenuItem
        '
        Me.ValueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PHPToolStripMenuItem, Me.MYRToolStripMenuItem})
        Me.ValueToolStripMenuItem.Name = "ValueToolStripMenuItem"
        Me.ValueToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ValueToolStripMenuItem.Text = "Value"
        '
        'PHPToolStripMenuItem
        '
        Me.PHPToolStripMenuItem.Name = "PHPToolStripMenuItem"
        Me.PHPToolStripMenuItem.Size = New System.Drawing.Size(114, 26)
        Me.PHPToolStripMenuItem.Text = "PHP"
        '
        'MYRToolStripMenuItem
        '
        Me.MYRToolStripMenuItem.Name = "MYRToolStripMenuItem"
        Me.MYRToolStripMenuItem.Size = New System.Drawing.Size(114, 26)
        Me.MYRToolStripMenuItem.Text = "MYR"
        '
        'trbRange
        '
        Me.trbRange.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.trbRange.LargeChange = 30
        Me.trbRange.Location = New System.Drawing.Point(0, 365)
        Me.trbRange.Maximum = 365
        Me.trbRange.Minimum = 7
        Me.trbRange.Name = "trbRange"
        Me.trbRange.Size = New System.Drawing.Size(728, 56)
        Me.trbRange.SmallChange = 7
        Me.trbRange.TabIndex = 3
        Me.trbRange.TickFrequency = 7
        Me.trbRange.Value = 50
        '
        'frmChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 421)
        Me.Controls.Add(Me.trbRange)
        Me.Controls.Add(Me.chartView)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(514, 432)
        Me.Name = "frmChart"
        Me.Text = "frmChart"
        CType(Me.chartView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.trbRange, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chartView As DataVisualization.Charting.Chart
    Friend WithEvents MYRToPHPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MYRToINDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PHPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MYRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ValueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExchangeRateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisplayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents trbRange As TrackBar
End Class
