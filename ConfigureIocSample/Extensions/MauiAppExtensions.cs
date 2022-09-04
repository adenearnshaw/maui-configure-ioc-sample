using CommunityToolkit.Mvvm.DependencyInjection;

namespace ConfigureIocSample.Extensions;
internal static class MauiAppExtensions
{
    public static MauiApp ConfigureIoc(this MauiApp mauiApp)
    {
        Ioc.Default.ConfigureServices(mauiApp.Services);
        return mauiApp;
    }
}
