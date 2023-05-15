using DesckCalcSH.Pages;
namespace DesckCalcSH;

public partial class AppShell : Shell
{
    public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("ChartPageChartPageDetail", typeof(Pages.ChartPage));
        Routing.RegisterRoute("HistoryPageHistoryPageDetail", typeof(Pages.HistoryPage)); // создается новая, а нужна ссылка на уже созданную

    }
}
