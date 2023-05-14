using Application = Microsoft.Maui.Controls.Application;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
namespace DesckCalcSH;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();

    }
}
