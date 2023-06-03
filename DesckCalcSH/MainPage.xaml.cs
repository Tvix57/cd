using DesckCalcSH.ModelSource;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace DesckCalcSH;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ModelView();
    }
    private void OnClearClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        ModelView MV = this.BindingContext as ModelView;
        if (btn.Text == "C")
        {
            MV?.RemoveLast();
        }
        else
        {
            MV?.AllClear();
        }
    }
    private void OnNumberClick(object sender, EventArgs e)
    {
        ModelView MV = this.BindingContext as ModelView;
        Button btn = sender as Button;
        MV?.AddNum(btn?.Text);
    }
    private void OnOperatorClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        ModelView MV = this.BindingContext as ModelView;
        MV?.AddOperator(btn?.Text);
    }
    private void OnFunctionClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        ModelView MV = this.BindingContext as ModelView;
        MV?.AddFunction(btn?.Text);
    }
    private void OnDotClick(object sender, EventArgs e)
    {
        ModelView MV = this.BindingContext as ModelView;
        MV.AddDot();
    }
    private void OnXClick(object sender, EventArgs e)
    {
        ModelView MV = this.BindingContext as ModelView;
        MV.AddX();
    }
    private void OnEqualClick(object sender, EventArgs e)
    {
        if (result.Text != "") {
            ModelView MV = this.BindingContext as ModelView;
            temp_layout.Add(AddLabel(MV?.Input));
            var app = App.Current as App;
            app?.HistoryPage?.AddResult(MV?.Input);
            string tmp = MV?.Input;
            if (tmp.Contains('x'))
            {
                app.ChartPage.Model = MV.GetModel();
            }
            else
            {
                app?.HistoryPage?.AddResult(MV?.Result);
                temp_layout.Add(AddLabel(MV?.Result));
            }
            temp_layout.Add(AddSeparator());
            MV?.AllClear();
        }
    }
    private void OnBranchesClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        ModelView MV = this.BindingContext as ModelView;
        if (btn.Text == "(")
        {
            if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([\+\-\*/\^\(]|mod)$"))
            {
                MV.AddOBranch();
            }
        }
        else
        {
            MV.AddCBranch();
        }
    }
    public void SetHistory(string history)
    {
        ModelView MV = this.BindingContext as ModelView;
        MV.AllClear();
        MV.Input = history;
    }
    private void SwitchSign(object sender, EventArgs e) {
        ModelView MV = this.BindingContext as ModelView;
        MV.SwitchSign();
    }
    private Label AddLabel(string text)
    {
        Label lab = new Label { Text = text , FontSize = 20, HorizontalTextAlignment = TextAlignment.End};
        TapGestureRecognizer labelTapRecognizer = new TapGestureRecognizer();
        labelTapRecognizer.Tapped += OnLabelTapped;
        lab.GestureRecognizers.Add(labelTapRecognizer);
        return lab;
    }
    private BoxView AddSeparator()
    {
        BoxView separator = new BoxView();
        separator.Color = Color.FromRgb(255, 255, 255);
        separator.HeightRequest = 1;
        return separator;
    }
    private void OnLabelTapped(object sender, EventArgs e)
    {
        Label lab = sender as Label;
        SetHistory(lab?.Text);
    }
}
