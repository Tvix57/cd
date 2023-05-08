using System.Collections.ObjectModel;
namespace DesckCalcSH;

public partial class MainPage : ContentPage
{
	
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
        }
    }
    private void OnNumberClick(object sender, EventArgs e) {
		Button btn = sender as Button;
		result.Text += btn.Text;
    }
    private void OnEqualClick(object sender, EventArgs e) {
        string calculate_txt = "test";
        result.Text = calculate_txt;
        string tmp = result.Text + "=" + calculate_txt;
 
        var app = (App)Application.Current;
        var navigationStack = Shell.Current.Navigation.NavigationStack;
        foreach (var page in navigationStack)
        {
            if (page is Pages.HistoryPage page2)
            {
                
                break;
            }
        }
        var history_page = app.MainPage.Navigation.NavigationStack.FirstOrDefault(p => p?.ClassId == "HistoryPage") as Pages.HistoryPage;
        history_page?.AddResult(tmp);

    }
    private void OnShowFunctionClick(object sender, EventArgs e) {
        dropdown.IsVisible = !dropdown.IsVisible;
    }
    private string RemoveLast() {
        string text = result.Text;
        return text;
    }
}

