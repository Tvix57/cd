using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            Regex.IsMatch(XminField.Text, @"^[+-]?\d+(\.\d+)?$")) 
        {
            if (XmaxField.Text != null &&
                Regex.IsMatch(XmaxField.Text, @"^[+-]?\d+(\.\d+)?$"))
            {
                if (StepField.Text != null &&
                    Regex.IsMatch(StepField.Text, @"^\d+(\.\d+)?$")) 
                {
                    if (_model != null) 
                    {
                        double xMin, xMax, step;
                        Double.TryParse(XminField.Text, out xMin);
                        Double.TryParse(XmaxField.Text, out xMax);
                        Double.TryParse(StepField.Text, out step);
                        if (xMin > xMax) 
                        {
                            double tmp = xMax;
                            xMax = xMin;
                            xMin = tmp;
                            XminField.Text = xMin.ToString();
                            XmaxField.Text = xMax.ToString();
                        }
                        if (xMin < -1000000f) 
                        {
                            xMin = -1000000f;
                            XminField.Text = xMin.ToString();
                        }
                        if (xMax > 1000000f)
                        {
                            xMax = 1000000f;
                            XmaxField.Text = xMax.ToString();
                        }
                        if (step > xMin+xMax)/////
                        {
                           // step = xMin + xMax;
                           // XminField.Text = step.ToString();
                        }

                        var CVM = ChartViewLink.BindingContext as ChartViewModel;
                        CVM.ClearAll();
                       // Task.Run(() => {
                            for (; xMin < xMax; xMin += step)
                            {
                                CVM.AddValue(xMin, _model.Calculate(xMin));
                            }
                       // });
      
                    }
                } 
                else
                { 
                    StepField.Text = null;
                    StepField.IsVisible = true;
                }
            }
            else 
            {
                XmaxField.Text = null;
                XmaxField.IsVisible = true;
            }
        }
        else
        {
            XminField.Text = null;
            XminField.IsVisible = true;
        }
    }
}

