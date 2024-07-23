using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DDDSampleApp.Infrastructure.Data;

/// <summary>
/// dotnet ef database update コマンドで利用する。
/// </summary>
public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
  /// <summary>
  /// Entity Framework Core Contextを作成する。
  /// </summary>
  /// <returns></returns>
  public static ApplicationContext CreateDbContext()
  {
    return new ApplicationContextFactory().CreateDbContext([]);
  }

  /// <summary>
  /// Entity Framework Core Contextを作成する。
  /// （dotnet ef database update コマンドで利用）
  /// </summary>
  /// <param name="args"></param>
  /// <returns></returns>
  public ApplicationContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
    // TODO: 後で、データソースは環境変数やConfigファイルから設定するように変更する。
    optionsBuilder.UseSqlite("Data Source=todos.db");
    optionsBuilder.UseLazyLoadingProxies();
    return new ApplicationContext(optionsBuilder.Options);
  }
}
