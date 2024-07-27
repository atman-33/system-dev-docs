using Microsoft.EntityFrameworkCore.Design;

namespace DDDSampleApp.Infrastructure.Data;

/// <summary>
/// dotnet ef database update コマンドで利用する。
/// </summary>
public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
  /// <summary>
  /// Entity Framework Core Contextを作成する。
  /// （dotnet ef database update コマンドで利用）
  /// </summary>
  /// <param name="args"></param>
  /// <returns></returns>
  public ApplicationContext CreateDbContext(string[] args)
  {
    return new ApplicationContext(ApplicationContext.GetDefaultOptions());
  }
}
