using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ConfigureIocSample;

[ObservableObject]
public partial class MainViewModel
{
    private int count = 0;

    [ObservableProperty]
    private string counterText = "Click me";

    [RelayCommand]
    private void OnCounterClicked()
    {
        count++;

        if (count == 1)
            CounterText = $"Clicked {count} time";
        else
            CounterText = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterText);
    }
}

