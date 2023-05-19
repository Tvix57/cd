using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace DesckCalcSH.Pages;

public partial class HistoryPage : ContentPage
{

    private List<string> _history;
    public HistoryPage() {
		InitializeComponent();
        _history = new List<string>();
        LoadData();
    }
    ~HistoryPage()
    {
        SaveData();
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
    private void SaveData() 
    {
        var json = JsonConvert.SerializeObject(_history);
        Preferences.Set("history", json);
    }
    private void LoadData()
    {
        var jsonString = Preferences.Get("history", string.Empty);
/*        var last_history = JsonConvert.DeserializeObject<List<string>>(jsonString);
        foreach (string item in last_history) {
            AddResult(item);
        }*/
    }
    private void OnLabelTapped(object sender, EventArgs e)
    {
        Label lab = sender as Label;
        var app = App.Current as App;
        if (app != null)
        {
            // app.CalcPage.AddResult(lab.Text); // отправить данные в калькулятор
        }
    }
}

