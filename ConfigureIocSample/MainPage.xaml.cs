using CommunityToolkit.Mvvm.DependencyInjection;

namespace ConfigureIocSample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = Ioc.Default.GetService<MainViewModel>();
	}
}