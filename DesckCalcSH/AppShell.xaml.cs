using DesckCalcSH.Pages;
namespace DesckCalcSH;

public partial class AppShell : Shell
{
    public AppShell()
	{
		InitializeComponent();
    }
    public AppShell(MainPage mainPage, ChartPage chartPage, HistoryPage history)
    {
        InitializeComponent();
        FlyoutItem calculatorItem = new FlyoutItem() { Title = "Calculator", Icon = "calc.png", Route = "MainPage" };
        calculatorItem.Items.Add(new ShellContent() { Title = "Calculator", ContentTemplate = new DataTemplate(() => mainPage), Icon = "calc.png", Route = "MainPageContent" });
        Items.Add(calculatorItem);

        FlyoutItem chartItem = new FlyoutItem() { Title = "Chart", Icon = "chart.png", Route = "ChartPage" };
        chartItem.Items.Add(new ShellContent() { Title = "Chart", Content = chartPage, Icon = "chart.png", Route = "ChartPageContent" });
        Items.Add(chartItem);

        FlyoutItem historyItem = new FlyoutItem() { Title = "History", Icon = "history.png", Route = "HistoryPage" };
        historyItem.Items.Add(new ShellContent() { Title = "History", Content = history, Icon = "chart.png", Route = "HistoryPageContent" });
        Items.Add(historyItem);
    }
}
