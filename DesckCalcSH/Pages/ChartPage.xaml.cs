using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace DesckCalcSH.Pages;

public partial class ChartPage : ContentPage
{
    public ISeries[] Series { get; set; }
        = new ISeries[]
        {
            new LineSeries<double>
            {
                Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                Fill = null
            }
        };


    public ChartPage()
	{
		InitializeComponent();
	}

    private void DrowGraph(object sender, EventArgs e)
    {
        /*
         * 
         * <PackageReference Include="SkiaSharp.Views.Maui.Controls" Version="2.88.3" />
         * < lvc:CartesianChart
      Grid.Row = "1"
      Grid.Column = "0"
          Series = "{Binding Series}" >
  </ lvc:CartesianChart >*/
    }
}

