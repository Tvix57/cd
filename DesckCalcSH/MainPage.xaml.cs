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
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([+\-*/^(.]|mod|\d)$"))
        {
            Button btn = sender as Button;
            result.Text += btn.Text;
        }
    }
    private void OnOperatorClick(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        if (Regex.IsMatch(btn.Text, @"([*\\/^]|mod)$"))
        {
            if (Regex.IsMatch(result.Text, @"([\\)x]|\d)$")) {
                result.Text += btn.Text;
            }
        }
        else {
            if (!Regex.IsMatch(result.Text, @"(([+\-*\\/^\\(\\)]|mod)[+\-])$") && result.Text.Length != 1) {
                result.Text += btn.Text;
            }
            else if (Regex.IsMatch(result.Text, @"([\\)x]|\d)$"))
            {
                result.Text += btn.Text;
            }
        }
    }
    private void OnFunctionClick(object sender, EventArgs e)
    {
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([+\-*\\/^(]|mod)$"))
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
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([+\-*\\/^(]|mod)$")) // check regular
        {
            result.Text += "x";
            read_x = true;
        }
    }
    private void OnEqualClick(object sender, EventArgs e) {
       // if (branches == 0 && Regex.IsMatch(result.Text, @"(\d|[\\)x])$")) {
            ModelSource.Model model = new ModelSource.Model(result.Text);
            string calculate_txt = model.Calculate().ToString();
            result.Text = calculate_txt;
            //string to_history = result.Text + "\n=\n" + calculate_txt;
        //}


       // var pat = this.Parent as AppShell;
        
      //  var app = (App)Application.Current;
/*        var navigationStack = Shell.Current.Navigation.NavigationStack;
        foreach (var page in navigationStack)
        {
            if (page is Pages.HistoryPage page2)
            {
                
                break;
            }
        }*/
/*        var history_page = app.MainPage.Navigation.NavigationStack.FirstOrDefault(p => p?.ClassId == "HistoryPage") as Pages.HistoryPage;
        history_page?.AddResult(tmp);*/
    }
    private void OnBranchesClick(object sender, EventArgs e) {
        Button btn = sender as Button;
        if (btn.Text == "(") {
            if (result.Text.Length == 0 || Regex.IsMatch(result.Text, @"([+\-*\\/^(]|mod)$"))
            {
                result.Text += btn.Text;
                branches++;
            }
        } else if (branches != 0) {
            if (Regex.IsMatch(result.Text, @"(\d|[)]|x)$")) {
                result.Text += btn.Text;
                branches--;
            }
        }
    }
    private void OnShowFunctionClick(object sender, EventArgs e) {
        dropdown.IsVisible = !dropdown.IsVisible;
    }
    private string RemoveLast() {
        string text = result.Text;
        return text;
    }
}

