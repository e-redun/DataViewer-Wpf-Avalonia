using Common.ViewModels;
using DataViewer.UI.Wpf.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DataViewer.UI.Wpf
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            services.AddTransient<MainWindowModel>();

            Services = services.BuildServiceProvider();

            var mainWindow = new MainWindow();
            var mainWindowModel = Services.GetRequiredService<MainWindowModel>();

            mainWindowModel.RequestClose += () => mainWindow.Close();
            mainWindow.DataContext = mainWindowModel;

            mainWindow.Show();
        }
    }
}