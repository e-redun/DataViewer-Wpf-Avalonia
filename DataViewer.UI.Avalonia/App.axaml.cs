using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Common.Infrastructure;
using Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using DataViewer.UI.Avalonia.Views;


namespace DataViewer.UI.Avalonia;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        services.AddApplicationServices();
        services.AddViewModels();

        Services = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindowModel = Services.GetRequiredService<MainWindowModel>();

            var mainWindow = new MainWindow();

            mainWindowModel.CloseRequest += () => mainWindow.Close();

            mainWindow.DataContext = mainWindowModel;
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}