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
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        window.Width = 600;
        window.Height = 800;
        window.MinimumHeight = 800;
        window.MinimumWidth = 300;
        window.MaximumWidth = 700;
        return window;
    }
}
