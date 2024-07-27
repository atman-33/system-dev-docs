using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.Data;

public static class DataExtensions
{
  /// <summary>
  /// データベースをマイグレーション
  /// </summary>
  /// <param name="app"></param>
  public static async void MigrateDbAsync(DbContextOptions<ApplicationContext> options)
  {
    using (var dbContext = new ApplicationContext(options))
    {
      await dbContext.Database.MigrateAsync();
    }
  }
}
