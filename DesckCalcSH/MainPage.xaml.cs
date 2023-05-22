using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace DesckCalcSH;

public partial class MainPage : ContentPage
{
    private bool read_x = false;
    private int branches = 0;
    double step;
    
    public MainPage() {
		InitializeComponent();
    }
    private void OnClearClick(object sender, EventArgs e) {
        Button btn = sender as Button;
        if (btn.Text == "C") {
            result.Text = RemoveLast();
        } else {
            result.Text = "";
            read_x = false;
        }
    }
    private void OnNumberClick(object sender, EventArgs e) {
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"(\+\\\-|[\+\-\*/^\(\.]|mod|\d)$"))
        {
            Button btn = sender as Button;
            result.Text += btn.Text;
        }
    }
    private void OnOperatorClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (Regex.IsMatch(btn.Text, @"^([\+\-\*/^]|mod)$"))
        {
            if (Regex.IsMatch(result.Text, @"([)x]|\d)$"))
            {
                result.Text += btn.Text;
            }
        }
        else 
        {
            if (!Regex.IsMatch(result.Text, @"([\.\)]|\d)$"))  //@"(([\+\-\*/^\(\)]|mod)[+\-])$" для +/-
            { //test reg
                result.Text += btn.Text;
            }
            else if (btn.Text != "+/-" && Regex.IsMatch(result.Text, @"([)x]|\d)$"))
            {
                result.Text += btn.Text;
            }
        }
    }
    private void OnFunctionClick(object sender, EventArgs e)
    {
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([\+\-\*/^(]|mod)$"))
        {
            Button btn = sender as Button;
            result.Text += btn.Text + "(";
            branches++;
        }
    }
    private void OnDotClick(object sender, EventArgs e)
    {
        if (!Regex.IsMatch(result.Text, @"\d+[.]\d+$") && Regex.IsMatch(result.Text, @"\d+$"))
        {
            result.Text += ".";
        }
    }
    private void OnXClick(object sender, EventArgs e)
    {
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([\+\-\*/^(]|mod)$"))
        {
            result.Text += "x";
            read_x = true;
        }
    }
    private void OnEqualClick(object sender, EventArgs e) {
        if (branches == 0 && Regex.IsMatch(result.Text, @"(\d|[)x])$")) {
            string tmp = result.Text;
            ModelSource.Model model = new ModelSource.Model(tmp);
            string calculate_txt = model.Calculate().ToString();
            var app = App.Current as App;
            if (app != null)
            {
                app.HistoryPage.AddResult(result.Text);
                app.HistoryPage.AddResult(calculate_txt);            
            }
            result.Text = calculate_txt;
        } // show message incorect input
    }
    private void OnBranchesClick(object sender, EventArgs e) {
        Button btn = sender as Button;
        if (btn.Text == "(") {
            if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([+\-*\\/^(]|mod)$"))  //test reg
            {
                result.Text += btn.Text;
                branches++;
            }
        } else if (branches != 0) {
            if (Regex.IsMatch(result.Text, @"(\d|[)]|x)$"))
            { //test reg
                result.Text += btn.Text;
                branches--;
            }
        }
    }
    private string RemoveLast() {
        string text = result.Text;
        return text;
    }
}
