using Microsoft.Maui.Controls;
namespace DesckCalcSH.Pages;

[QueryProperty(nameof(NewResult), "newResultProperty")]
public partial class HistoryPage : ContentPage
{
    string newResult;
    public string NewResult
    {
        get => newResult;
        set
        {
            newResult = value;
            AddResult(value);
        }
    }

    public List<string> _history;
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
    private void SaveData() { 
    
    }
    private void LoadData()
    {

    }
}

