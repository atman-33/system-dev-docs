using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.DomainModels.TodoType.Repositories;
using DDDSampleApp.Infrastructure;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Repositories;
using DDDSampleApp.UseCase.Services.Member;
using DDDSampleApp.UseCase.Services.TodoType;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DDDSampleApp.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  public static IServiceProvider ServiceProvider { get; private set; } = null!;

  public App()
  {
    // DBマイグレーション実行
    DataExtensions.MigrateDbAsync(ApplicationContext.GetDefaultOptions());

    // DIコンテナを作成
    var serviceCollection = new ServiceCollection();
    ConfigureServices(serviceCollection);
    ServiceProvider = serviceCollection.BuildServiceProvider();
  }

  /// <summary>
  /// DIコンテナの中身を設定
  /// </summary>
  /// <param name="services"></param>
  /// <exception cref="NotImplementedException"></exception>
  private void ConfigureServices(ServiceCollection services)
  {
    // 1. DBコンテキストを追加
    services.AddTransient<ApplicationContext>();

    // 2. リポジトリを追加
    services.AddTransient<IMemberRepository, MemberRepository>();
    services.AddTransient<ITodoTypeRepository, TodoTypeRepository>();

    // 3. ユースケースを追加
    services.AddTransient<MemberGetUseCase>();
    services.AddTransient<MemberAddTodoUseCase>();
    services.AddTransient<MemberDeleteTodoUseCase>();
    services.AddTransient<TodoTypeGetUseCase>();
  }
}

