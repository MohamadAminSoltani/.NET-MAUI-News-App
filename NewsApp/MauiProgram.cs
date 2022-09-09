namespace NewsApp;

using NewsApp.Helpers;
using NewsApp.Services;
using NewsApp.ViewModels;
using NewsApp.Views;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.ListView.Hosting;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("solid.ttf", "solid");
            });

		string dbPath = FileAccessHelper.GetLocalPath("news.db3");
		builder.Services.AddSingleton<NewsRepository>(s => ActivatorUtilities.CreateInstance<NewsRepository>(s, dbPath));


		builder.Services.AddSingleton<INewsApiService, NewsApiService>();

		builder.Services.AddSingleton<NewsViewModel>();
		builder.Services.AddSingleton<NewsPage>();

        builder.Services.AddTransient<NewsDetailsViewModel>();
        builder.Services.AddTransient<NewsDetailsPage>();

        builder.ConfigureSyncfusionListView();

        return builder.Build();
	}
}
