using System.Windows;
using DDDSampleApp.Infrastructure.Data;

namespace DDDSampleApp.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  public App()
  {
    DataExtensions.MigrateDbAsync();
  }
}

