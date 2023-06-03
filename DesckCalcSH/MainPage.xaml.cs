using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace DesckCalcSH;

public partial class MainPage : ContentPage
{
    private int branches = 0;
    public MainPage()
    {
        InitializeComponent();
    }
    private void OnClearClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn.Text == "C")
        {
            result.Text = RemoveLast();
        }
        else
        {
            result.Text = "";
        }
    }
    private void OnNumberClick(object sender, EventArgs e)
    {
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"(\+\\\-|[\+\-\*/^\(\.]|mod|\d)$"))
        {
            Button btn = sender as Button;
            result.Text += btn.Text;
        }
    }
    private void OnOperatorClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (Regex.IsMatch(btn.Text, @"^([\*/^]|mod)$"))
        {
            if (Regex.IsMatch(result.Text, @"([)x]|\d)$"))
            {
                result.Text += btn.Text;
            }
        }
        else
        {
            if (!Regex.IsMatch(result.Text, @"(([\+\\\-\*\/\^\(\)]|mod)[\+\\\-])$") && result.Text.Length != 1)
            {
                result.Text += btn.Text;
            }
            else if (Regex.IsMatch(result.Text, @"([)x]|\d)$"))
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
        }
    }
    async private void OnEqualClick(object sender, EventArgs e)
    {
        if (branches == 0 && Regex.IsMatch(result.Text, @"(\d|[)x])$"))
        {
            string tmp = result.Text;
            ModelSource.Model model = new ModelSource.Model(tmp);
            var app = App.Current as App;
            if (result.Text.Contains('x'))
            {
                app.ChartPage.Model = model;
            }
            else
            {
                string calculate_txt = model.Calculate().ToString();
                if (app != null)
                {
                    app.HistoryPage.AddResult(result.Text);
                    app.HistoryPage.AddResult(calculate_txt);
                }
                result.Text = calculate_txt;
            }
        }
        else 
        {
            await DisplayAlert("Alert", "Input error", "OK");
        }
    }
    private void OnBranchesClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (btn.Text == "(")
        {
            if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([\+\-\*/\^\(]|mod)$"))
            {
                result.Text += btn.Text;
                branches++;
            }
        }
        else if (branches != 0)
        {
            if (Regex.IsMatch(result.Text, @"(\d|[)]|x)$"))
            {
                result.Text += btn.Text;
                branches--;
            }
        }
    }
    private string RemoveLast()
    {
        string text = result.Text;
        if (Regex.IsMatch(text, @"(\d|[\.\+\-\*\/\)X])$"))
        {
            text = text.Remove(text.Length - 1, 1);
        }
        else if (Regex.IsMatch(text, @"[\(]$")) 
        {
            text = text.Remove(text.Length - 1, 1);
            if (Regex.IsMatch(text, @"(ln)$")) 
            {
                text = text.Remove(text.Length - 2, 2);
            } else if (text.Length != 0 && !Regex.IsMatch(text, @"[\(]$")) 
            {
                text = text.Remove(text.Length - 3, 3);
                if (Regex.IsMatch(text, @"[as]$")) 
                {
                    text = text.Remove(text.Length - 1, 1);
                }
            }
        } else if (Regex.IsMatch(text, @"(\w)$")) 
        {
            text = text.Remove(text.Length - 3, 3);
        }
        return text;
    }
    public void SetHistory(string history)
    {
        result.Text = history;
    }

    private void SwitchSign(object sender, EventArgs e) {
        string text = result.Text;
        if (text.Last() == '-')
        {
            text = text.Remove(text.Length - 1, 1);
            text += '+';
        } else if (text.Last() == '+')
        {
            text = text.Remove(text.Length - 1, 1);
            text += "-";
        }
        result.Text = text;
    }
}
