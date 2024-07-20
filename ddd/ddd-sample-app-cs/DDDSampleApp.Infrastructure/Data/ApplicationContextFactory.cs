using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DDDSampleApp.Infrastructure.Data;

/// <summary>
/// dotnet ef database update コマンドで利用する。
/// </summary>
public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
  public ApplicationContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
    return new ApplicationContext(optionsBuilder.Options);
  }
}
