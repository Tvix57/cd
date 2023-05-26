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
        if (XminField.Text != null &&
            Regex.IsMatch(XminField.Text, @"^[+-]?\d+(\.\d+)?$")) {
            if (XmaxField.Text != null &&
                Regex.IsMatch(XmaxField.Text, @"^[+-]?\d+(\.\d+)?$"))
            {
                if (StepField.Text != null &&
                    Regex.IsMatch(StepField.Text, @"^[+-]?\d+(\.\d+)?$")) 
                {
                    if (_model != null) 
                    {
                        double xMin, xMax, step;
                        Double.TryParse(XminField.Text, out xMin);
                        Double.TryParse(XmaxField.Text, out xMax);
                        Double.TryParse(StepField.Text, out step);

                        var CVM = ChartViewLink.BindingContext as ChartViewModel;
                        CVM.ClearAll();
                        for (; xMin < xMax; xMin += step)
                        {
                            CVM.AddValue(xMin, _model.Calculate(xMin));
                        }
                    }
                } 
                else
                {
                    StepField.Text = null;
                }
            }
            else 
            {
                XmaxField.Text = null;
            }
        }
        else
        {
            XminField.Text = null;
        }
    }
}

