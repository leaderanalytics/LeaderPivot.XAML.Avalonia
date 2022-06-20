using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LeaderAnalytics.LeaderPivot.XAML.Avalonia.Host.ViewModels;
using LeaderAnalytics.LeaderPivot.XAML.Avalonia.Host.Views;

namespace LeaderAnalytics.LeaderPivot.XAML.Avalonia.Host;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
