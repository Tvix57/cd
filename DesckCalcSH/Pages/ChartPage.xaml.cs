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
   
          

    }
}

