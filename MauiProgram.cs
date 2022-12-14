using Microsoft.AspNetCore.Components.WebView.Maui;
using Warehouse.Data;
using Warehouse.Services;

namespace Warehouse;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "warehouse.db3");

		builder.Services.AddSingleton(x => ActivatorUtilities.CreateInstance<StockRepository>(x, dbPath));
        builder.Services.AddSingleton(x => ActivatorUtilities.CreateInstance<SaleRepository>(x, dbPath));
        builder.Services.AddSingleton(x => ActivatorUtilities.CreateInstance<RefreshService>(x));

        return builder.Build();
	}
}
