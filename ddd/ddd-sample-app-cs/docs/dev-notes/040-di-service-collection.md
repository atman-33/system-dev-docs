# DIコンテナ（サービスコレクション）利用方法

## ステップ

### コンテナ生成

`DDDSampleApp.Wpf\App.xaml.cs`

```cs
using System.Windows;
using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Repositories;
using DDDSampleApp.UseCase.Services.Member;
using Microsoft.Extensions.DependencyInjection;

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
    services.AddDbContext<ApplicationContext>(options => ApplicationContext.GetDefaultOptions());

    // 2. リポジトリを追加
    services.AddTransient<IMemberRepository, MemberRepository>();

    // 3. ユースケースを追加
    services.AddTransient<MemberGetUseCase>();
  }
}
```

### インスタンス利用方法

e.g.  

```cs
var memberGetUseCase = App.ServiceProvider.GetRequiredService<MemberGetUseCase>();
member = await memberGetUseCase.Execute(position!);
```
