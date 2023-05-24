using System.Text.RegularExpressions;

namespace DesckCalcSH.Pages;

public partial class ChartPage : ContentPage
{
    public ModelSource.Model Model {
        set { _model = value;
            StringLabel.Text = _model.RawString; } }
    private ModelSource.Model _model = null;
    public ChartPage()
	{
        InitializeComponent();
    }

    private void DrowGraph(object sender, EventArgs e)
    {
        if (XminField.Text.Length > 0 &&
            Regex.IsMatch(XminField.Text, @"^[+-]?\d+(\.\d+)?$") &&
            XmaxField.Text.Length > 0 &&
            Regex.IsMatch(XmaxField.Text, @"^[+-]?\d+(\.\d+)?$") &&
            StepField.Text.Length > 0 &&
            Regex.IsMatch(StepField.Text, @"^[+-]?\d+(\.\d+)?$") && _model != null)
        {
            double xMin, xMax, step;
            List<double> new_graph = new List<double>();
            Double.TryParse(XminField.Text, out xMin);
            Double.TryParse(XmaxField.Text, out xMax);
            Double.TryParse(StepField.Text, out step);
            for (; xMin < xMax; xMin += step)
            {
                new_graph.Add(_model.Calculate(xMin));
            }
        }
    }
}

