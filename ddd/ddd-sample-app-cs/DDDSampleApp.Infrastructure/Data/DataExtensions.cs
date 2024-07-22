using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.Data;

public static class DataExtensions
{
  /// <summary>
  /// データベースをマイグレーション
  /// </summary>
  /// <param name="app"></param>
  public static async void MigrateDbAsync()
  {
    using (var dbContext = ApplicationContextFactory.CreateDbContext())
    {
      await dbContext.Database.MigrateAsync();
    }
  }
}
