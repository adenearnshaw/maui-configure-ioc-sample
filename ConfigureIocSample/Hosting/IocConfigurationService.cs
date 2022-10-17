using CommunityToolkit.Mvvm.DependencyInjection;

namespace ConfigureIocSample.Hosting;
public class IocConfigurationService : IMauiInitializeService
{
    public void Initialize(IServiceProvider services)
    {
        Ioc.Default.ConfigureServices(services);
    }
}
