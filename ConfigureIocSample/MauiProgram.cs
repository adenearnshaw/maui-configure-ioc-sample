using ConfigureIocSample.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigureIocSample;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IMauiInitializeService>(new IocConfigurationService());


		builder.Services.AddTransient<MainViewModel>();

		return builder.Build();
	}	
}
