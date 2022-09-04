# Configuring an IoC Container in a MAUI app

I've always been a fan of MvvmLight's SimpleIoc and was really pleased to see it mature and make its way into the [CommunityToolkit](https://docs.microsoft.com/en-us/windows/communitytoolkit/mvvm/ioc) after MvvmLight's deprecation.

In [Marco Siccardi's](https://twitter.com/msicc) blog post ["Make the IServiceProvider of your MAUI application accessible with the MVVM CommunityToolkit"](https://msicc.net/make-the-iserviceprovider-of-your-maui-application-accessible-with-the-mvvm-communitytoolkit/) he walks through how this Container can be configured by extending the Maui App's Application class and calling `Ioc.Default.ConfigureServices()` from the construct of the resulting sub-class.

As highlighted in Marco's post, there are many ways to achieve this, however Sub-classing Application seemed a little too hard work for me :)

## Alternative Approach

The `IServiceProvider` is exposed from the MauiApp object created in the `MauiProgram.CreateMauiApp()` method. 

Rather than sub-class, we can simply extend the last line of `CreateMauiApp()`:

**MauiProgram.cs**
```csharp
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

        builder.Services.AddTransient<MainViewModel>();

        var mauiApp = builder.Build();
        Ioc.Default.ConfigureServices(mauiApp.Services);
        return mauiApp;
    }    
}
```

A cleaner approach would be to create an extension method, allowing us to keep it to a single line and configure the IoC Container elsewhere.

**MauiAppExtensions.cs**
```csharp
internal static class MauiAppExtensions
{
    public static MauiApp ConfigureIoc(this MauiApp mauiApp)
    {
        Ioc.Default.ConfigureServices(mauiApp.Services);
        return mauiApp;
    }
}
```

**MauiProgram.cs**
```csharp
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        ...

        builder.Services.AddTransient<MainViewModel>();

        return builder.Build().ConfigureIoc();
    }    
}
```

Thanks again to Marco for the inspiration, this is in no way intended to put down his approach, only to highlight that there's always more than one approach and to choose the one you feel most comfortable with.
