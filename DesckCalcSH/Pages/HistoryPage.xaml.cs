namespace DesckCalcSH.Pages;

public partial class HistoryPage : ContentPage
{
    public HistoryPage() {
		InitializeComponent();

    }
	public void AddResult(string res) {
		Label lab = new Label();
		lab.Text = res;
		history_layout.Add(lab);
    }
	private void ClearAll(object sender, EventArgs e) {
        var app = (App)Application.Current;
        var test = app.MainPage.ClassId;
        history_layout.Clear();
    }
}

