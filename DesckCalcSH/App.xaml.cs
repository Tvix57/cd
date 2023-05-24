using Application = Microsoft.Maui.Controls.Application;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using DesckCalcSH.Pages;

namespace DesckCalcSH;

public partial class App : Application
{
    public MainPage _calcPage = new MainPage();
    public ChartPage _chartPage = new ChartPage();
    public HistoryPage _historyPage = new HistoryPage();

    public MainPage CalcPage
    {
        get { return _calcPage; }
        private set { _calcPage = value; }
    }
    public ChartPage ChartPage
    {
        get { return _chartPage; }
        private set { _chartPage = value; }
    }
    public HistoryPage HistoryPage
    {
        get { return _historyPage; }
        private set { _historyPage = value; }
    }

    public App()
	{
		InitializeComponent();
        MainPage = new AppShell(_calcPage, _chartPage, _historyPage);
    }
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        window.Destroying += Window_Destroying;
        window.Width = 600;
        window.Height = 600;
        window.MinimumHeight = 600;
        window.MinimumWidth = 450;
        window.MaximumWidth = 1200;
        return window;
    }
    private void Window_Destroying(object sender, EventArgs e)
    {
        HistoryPage.SaveData();
    }
}
