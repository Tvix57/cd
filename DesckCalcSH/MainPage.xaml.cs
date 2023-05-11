using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
namespace DesckCalcSH;

public partial class MainPage : ContentPage
{
    private bool read_x = false;
    private int parenthesis = 0;
    double step;

    public MainPage() {
		InitializeComponent();
        this.ClassId = "MainPage";
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
        string regex = @"([+\-*/^(.]|mod|\d)$";
        if (result.Text.Length == 0 || Regex.IsMatch(result.Text, regex)) // check regular
        {
            Button btn = sender as Button;
            result.Text += btn.Text;
        }
    }
    private void OnOperatorClick(object sender, EventArgs e)
    {
        string reg1 = @"([*\\/^]|mod)$";
        string reg2 = @"([\\)x]|\d)$";
        Button btn = sender as Button;
        if (Regex.IsMatch(btn.Text, reg1))
        {
            if (Regex.IsMatch(result.Text, reg2)) {
                result.Text += btn.Text;
            }
        }
        else {
            if (result.Text.Contains("(([+\\-*\\/^\\(\\)]|mod)[+\\-])$") && result.Text.Length != 1) {
                result.Text += btn.Text;
            }
            else if (result.Text.Contains("([\\)x]|\\d)$"))
            {
                result.Text += btn.Text;
            }
        }
    }
    private void OnFunctionClick(object sender, EventArgs e)
    {
        if (result.Text.Length == 0 || result.Text.Contains("([+\\-*\\/^(]|mod)$")) // check regular
        {
            Button btn = sender as Button;
            result.Text += btn.Text + "(";
            parenthesis++;
        }
    }
    private void OnDotClick(object sender, EventArgs e)
    {
        if (result.Text.Contains("\\d+[.]\\d+$") && result.Text.Contains("\\d+$")) // check regular
        {
            result.Text += ".";
        }
    }
    private void OnXClick(object sender, EventArgs e)
    {
        if (result.Text.Length == 0 || result.Text.Contains("([+\\-*\\/^(]|mod)$") && result.Text.Contains("\\d+$")) // check regular
        {
            result.Text += "x";
            read_x = true;
        }
    }
    private void OnEqualClick(object sender, EventArgs e) {
        string calculate_txt = "test";
        result.Text = calculate_txt;
        string tmp = result.Text + "=" + calculate_txt;

        var pat = this.Parent as AppShell;
        
        var app = (App)Application.Current;
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
    private void OnShowFunctionClick(object sender, EventArgs e) {
        dropdown.IsVisible = !dropdown.IsVisible;
    }
    private string RemoveLast() {
        string text = result.Text;
        return text;
    }
}

