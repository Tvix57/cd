﻿using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace DesckCalcSH.Pages;

public partial class ChartPage : ContentPage
{
    public ModelSource.Model Model
    {
        set
        {
            _model = value;
            if (_model != null)
            {
                StringLabel.Text = _model?.RawString;
            }
            else
            {
                StringLabel.Text = "";
            }
        }
    }
    private ModelSource.Model _model = null;
    public ChartPage()
	{
        InitializeComponent();
    }
    async private void DrowGraph(object sender, EventArgs e)
    {
        double xMin, xMax, step;
        if (XminField.Text != null &&
            Regex.IsMatch(XminField.Text, @"^[-]?\d+(([\.]|[\,])\d+)?$") &&
            Double.TryParse(XminField.Text, out xMin)) 
        {
            if (XmaxField.Text != null &&
                Regex.IsMatch(XmaxField.Text, @"^[-]?\d+(([\.]|[\,])\d+)?$") &&
                Double.TryParse(XmaxField.Text, out xMax))
            {
                if (StepField.Text != null &&
                    Regex.IsMatch(StepField.Text, @"^\d+(([\.]|[\,])\d+)?$") &&
                    Double.TryParse(StepField.Text, out step)) 
                {
                    if (_model != null)
                    {
                        if (xMin > xMax)
                        {
                            double tmp = xMax;
                            xMax = xMin;
                            xMin = tmp;
                            XminField.Text = xMin.ToString();
                            XmaxField.Text = xMax.ToString();
                        }
                        if (xMin < -1000000d)
                        {
                            xMin = -1000000d;
                            XminField.Text = xMin.ToString();
                        }
                        if (xMax > 1000000d)
                        {
                            xMax = 1000000d;
                            XmaxField.Text = xMax.ToString();
                        }
                        if (step > Math.Abs(xMin) + Math.Abs(xMax))
                        {
                            step = Math.Abs(xMin) + Math.Abs(xMax);
                            StepField.Text = step.ToString();
                        }
                        var CVM = ChartViewLink.BindingContext as ChartViewModel;
                        CVM.ClearAll();
                        for (; xMin < xMax; xMin += step)
                        {
                            CVM.AddValue(xMin, _model.Calculate(xMin));
                        }
                        CVM.AddValue(xMax, _model.Calculate(xMax));
                    }
                    else 
                    {
                        await DisplayAlert("Alert", "Model dont load. Please input correct model on calculator page", "OK");
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

