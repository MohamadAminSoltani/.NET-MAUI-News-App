using NewsApp.ViewModels;

namespace NewsApp.Views;

public partial class NewsDetailsPage : ContentPage
{
	public NewsDetailsPage(NewsDetailsViewModel vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}