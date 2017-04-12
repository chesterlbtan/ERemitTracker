Imports System.Windows.Forms
'Imports System.Data.

Public Class frmChart

    Private ListOfDates As List(Of Date)
    Private ListOfPHP As List(Of Single)
    Private ListOfMYR As List(Of Single)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal lstDate As IEnumerable(Of Date), ByVal lstPhp As IEnumerable(Of Single), ByVal lstMyr As IEnumerable(Of Single))
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListOfDates = lstDate
        ListOfPHP = lstPhp
        ListOfMYR = lstMyr
    End Sub

    Public Property Chart As DataVisualization.Charting.Chart
        Get
            Return chartView
        End Get
        Set(value As DataVisualization.Charting.Chart)
            chartView = value
        End Set
    End Property

    Private Sub frmChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chartView.Series.Clear()
        Dim phpSeries As New DataVisualization.Charting.Series("Php")
        Dim myrSeries As New DataVisualization.Charting.Series("Myr")
        For i As Integer = 0 To ListOfDates.Count - 1
            phpSeries.Points.AddXY(ListOfDates(i), ListOfPHP(i))
            myrSeries.Points.AddXY(ListOfDates(i), ListOfMYR(i))
        Next
        phpSeries.XValueType = DataVisualization.Charting.ChartValueType.Date
        myrSeries.XValueType = DataVisualization.Charting.ChartValueType.Date
        phpSeries.YAxisType = DataVisualization.Charting.AxisType.Primary
        myrSeries.YAxisType = DataVisualization.Charting.AxisType.Secondary

        chartView.Series.Add(myrSeries)
        chartView.Series.Add(phpSeries)
        chartView.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        chartView.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
        With chartView.ChartAreas(0)
            .AxisY.Title = "PHP"
            .AxisY.Minimum = Math.Round(0.99 * ListOfPHP.Min / 10) * 10
            .AxisY.Maximum = Math.Round(1.01 * ListOfPHP.Max / 10) * 10

            .AxisY2.Title = "MYR"
            .AxisY2.Minimum = Math.Round(0.99 * ListOfMYR.Min / 10) * 10
            .AxisY2.Maximum = Math.Round(1.01 * ListOfMYR.Max / 10) * 10
        End With
        chartView.Titles.Add(New DataVisualization.Charting.Title("MYR and PHP value"))
        UpdateChart()
    End Sub

    Private Sub UpdateChart()
        With chartView.ChartAreas(0)
            .AxisX.Maximum = ListOfDates(ListOfDates.Count - 1).ToOADate
            .AxisX.Minimum = (ListOfDates(ListOfDates.Count - 1) - (New TimeSpan(trbRange.Value, 0, 0, 0))).ToOADate

            If trbRange.Value <= 31 Then
                .AxisX.Interval = 1
            ElseIf trbRange.Value <= 61 Then
                .AxisX.Interval = 2
            ElseIf trbRange.Value <= 123 Then
                .AxisX.Interval = 5
            ElseIf trbRange.Value <= 185 Then
                .AxisX.Interval = 7
            ElseIf trbRange.Value <= 275 Then
                .AxisX.Interval = 14
            Else
                .AxisX.Interval = 15
            End If
        End With
    End Sub

    Private Sub trbRange_Scroll(sender As Object, e As EventArgs) Handles trbRange.Scroll
        UpdateChart()
    End Sub
End Class