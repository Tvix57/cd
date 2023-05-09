namespace DesckCalcSH.Pages;

public partial class HistoryPage : ContentPage
{
    private List<string> _history;
    public HistoryPage() {
		InitializeComponent();
        _history = new List<string>();
        var flyoutPage = Parent as FlyoutPage;
        if (flyoutPage != null && !(flyoutPage.Flyout is NavigationPage))
        {
            var navigationPage = new NavigationPage(this);
            flyoutPage.Flyout = navigationPage;
        }
    }
	public void AddResult(string res) {
		Label lab = new Label();
		lab.Text = res;
		history_layout.Add(lab);
        _history.Add(res);
    }
	private void ClearAll(object sender, EventArgs e) {
        _history.Clear();
        var app = (App)Application.Current;
        var test = app.MainPage.ClassId;
        history_layout.Clear();
    }
}

