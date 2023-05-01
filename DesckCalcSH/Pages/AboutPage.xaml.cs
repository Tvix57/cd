namespace DesckCalcSH.Pages;

public partial class AboutPage : ContentPage
{
	int count = 0;

	public AboutPage()
	{
		InitializeComponent();
	}

/*	private void OnClearClick(object sender, EventArgs e) {
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

    }

    private void OnShowFunctionClick(object sender, EventArgs e) {
        dropdown.IsVisible = !dropdown.IsVisible;
    }
    private string RemoveLast() {
        string text = result.Text;
        return text;
    }*/
}

