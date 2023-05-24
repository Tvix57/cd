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
        if (res != "")
        {
            history_layout.Add(AddLabel(res));
            history_layout.Add(AddSeparator());
            _history.Add(res);
        }
    }
    private Label AddLabel(string text) {
        Label lab = new Label { Text = text };
        TapGestureRecognizer labelTapRecognizer = new TapGestureRecognizer();
        labelTapRecognizer.Tapped += OnLabelTapped;
        lab.GestureRecognizers.Add(labelTapRecognizer);
        return lab;
    }
    private BoxView AddSeparator() { 
        BoxView separator = new BoxView();
        separator.Color = Color.FromRgb(255, 255, 255);
        separator.HeightRequest = 1;
        return separator;
    }
	private void ClearAll(object sender, EventArgs e) 
    {
        _history.Clear();
        history_layout.Clear();
    }
    public void SaveData() 
    {
        var all_strings = string.Join(",", _history);
        Preferences.Set("history", all_strings);
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
}

