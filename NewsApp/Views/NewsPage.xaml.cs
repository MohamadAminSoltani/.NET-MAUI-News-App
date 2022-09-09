using NewsApp.ViewModels;

namespace NewsApp.Views;

public partial class NewsPage : ContentPage
{
	public NewsPage(NewsViewModel vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}

	private void NewsTabViewSelectionChanged(object sender, Syncfusion.Maui.TabView.TabSelectionChangedEventArgs e)
	{
		if(e.NewIndex == 0)
		{
			suggestedNewsTabItem.TextColor = Color.FromArgb("#FFFFFF");
			savedNewsTabItem.TextColor = Color.FromArgb("#686B70");
		}
		else
		{
            suggestedNewsTabItem.TextColor = Color.FromArgb("#686B70");
            savedNewsTabItem.TextColor = Color.FromArgb("#FFFFFF");
        }
	}
}