using DDDSampleApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDDSampleApp.Infrastructure.Data;

public class ApplicationContext : DbContext
{
  // NOTE: DBテーブルの定義
  public DbSet<MemberModel> Members { get; set; }
  public DbSet<TodoModel> Todos { get; set; }
  public DbSet<TodoTypeModel> TodoTypes { get; set; }

  public ApplicationContext() : this(ApplicationContext.GetDefaultOptions())
  {
  }

  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
    // NOTE: 状態が変更された際にタイムスタンプを更新するイベントを設定
    ChangeTracker.Tracked += UpdateTimestamps;
    ChangeTracker.StateChanged += UpdateTimestamps;
  }

  /// <summary>
  /// DbContextOptionsを取得する。
  /// </summary>
  /// <returns></returns>
  public static DbContextOptions<ApplicationContext> GetDefaultOptions()
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
    // TODO: 後で、データソースは環境変数やConfigファイルから設定するように変更する。
    optionsBuilder.UseSqlite("Data Source=todos.db");
    optionsBuilder.UseLazyLoadingProxies();
    return optionsBuilder.Options;
  }

  /// <summary>
  /// データベースの構造を定義する。
  /// </summary>
  /// <param name="modelBuilder"></param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // ---- Member ---- //
    // NOTE: PKの設定
    modelBuilder.Entity<MemberModel>()
      .HasKey(m => m.Id);

    // NOTE: ユニーク制約の設定
    modelBuilder.Entity<MemberModel>()
      .HasIndex(m => m.Position)
      .IsUnique();

    // ---- Todo ---- //
    modelBuilder.Entity<TodoModel>()
      .HasKey(t => t.Id);

    // NOTE: FKの設定
    modelBuilder.Entity<TodoModel>()
      .HasOne(t => t.Member)
      .WithMany(m => m.Todos)
      .HasForeignKey(t => t.MemberId);

    modelBuilder.Entity<TodoModel>()
      .HasOne(t => t.TodoType)
      .WithMany() // NOTE: ナビゲーションプロパティを持たない場合は引数を空にする
      .HasForeignKey(t => t.TodoTypeId);

    // ---- TodoType ---- //
    modelBuilder.Entity<TodoTypeModel>()
      .HasKey(t => t.Id);

    modelBuilder.Entity<TodoTypeModel>()
      .HasIndex(t => t.Name)
      .IsUnique();

    // NOTE: Seed data（初期データ生成）
    modelBuilder.Entity<MemberModel>().HasData(
      new { Id = Guid.NewGuid().ToString(), Name = "Aさん", Position = "リーダー", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
      new { Id = Guid.NewGuid().ToString(), Name = "Bさん", Position = "メンバー", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
    );

    modelBuilder.Entity<TodoTypeModel>().HasData(
      new { Id = Guid.NewGuid().ToString(), Name = "プライベート", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
      new { Id = Guid.NewGuid().ToString(), Name = "仕事", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
    );
  }

  /// <summary>
  /// 状態が変更された際にタイムスタンプを更新する。
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  private void UpdateTimestamps(object? sender, EntityEntryEventArgs e)
  {
    if (e.Entry.Entity is IHasTimestamps entityWithTimestamps)
    {

      switch (e.Entry.State)
      {
        case EntityState.Added:
          entityWithTimestamps.CreatedAt = DateTime.Now;
          entityWithTimestamps.UpdatedAt = DateTime.Now;
          break;

        case EntityState.Modified:
          entityWithTimestamps.UpdatedAt = DateTime.Now;
          break;
      }
    }
  }
}
