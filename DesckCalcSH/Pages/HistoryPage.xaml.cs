namespace DesckCalcSH.Pages;

public partial class HistoryPage : ContentPage
{
    private List<string> _history;
    public HistoryPage() {
		InitializeComponent();
        _history = new List<string>();
    }
	public void AddResult(string res) {
		Label lab = new Label();
		lab.Text = res;
		history_layout.Add(lab);
        _history.Add(res);
    }
	private void ClearAll(object sender, EventArgs e) {
        _history.Clear();
        history_layout.Clear();
    }
}

