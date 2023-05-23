using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace DesckCalcSH.Pages;

public partial class HistoryPage : ContentPage
{

    private List<string> _history;
    public HistoryPage() {
		InitializeComponent();
        _history = new List<string>();
    }
	public void AddResult(string res) 
    {
		Label lab = new Label { Text = res };
        TapGestureRecognizer labelTapRecognizer = new TapGestureRecognizer();
        labelTapRecognizer.Tapped += OnLabelTapped;
        lab.GestureRecognizers.Add(labelTapRecognizer);
        history_layout.Add(lab);
        _history.Add(res);
    }
	private void ClearAll(object sender, EventArgs e) 
    {
        _history.Clear();
        history_layout.Clear();
    }
    public void SaveData() 
    {
        Preferences.Set("history", string.Join(",", _history));
    }
    public void LoadData()
    {
        string savedSerializedList = Preferences.Get("history", ",");
        List<string> tmp_history = savedSerializedList.Split(',').ToList();
        foreach (var it in tmp_history) {
            AddResult(it);
        }
    }
    private void OnLabelTapped(object sender, EventArgs e)
    {
        Label lab = sender as Label;
        var app = App.Current as App;
        if (app != null)
        {
            app.CalcPage.SetHistory(lab.Text);
        }
    }
/*    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        SaveData();
    }*/
}

