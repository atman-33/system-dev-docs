using DDDSampleApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDDSampleApp.Infrastructure.Data;

public class ApplicationContext : DbContext
{
  // NOTE: DBテーブルの定義
  public DbSet<Member> Members { get; set; }
  public DbSet<Todo> Todos { get; set; }
  public DbSet<TodoType> TodoTypes { get; set; }

  public ApplicationContext()
  {
  }

  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
    // NOTE: 状態が変更された際にタイムスタンプを更新するイベントを設定
    ChangeTracker.Tracked += UpdateTimestamps;
    ChangeTracker.StateChanged += UpdateTimestamps;
  }

  /// <summary>
  /// データベースを設定する。
  /// </summary>
  /// <param name="optionsBuilder"></param>
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // TODO: 後で、データソースは環境変数やConfigファイルから設定するように変更する。
    optionsBuilder.UseSqlite("Data Source=fake.db");
    optionsBuilder.UseLazyLoadingProxies();
  }

  /// <summary>
  /// データベースの構造を定義する。
  /// </summary>
  /// <param name="modelBuilder"></param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // ---- Member ---- //
    // NOTE: PKの設定
    modelBuilder.Entity<Member>()
      .HasKey(m => m.Id);

    // NOTE: ユニーク制約の設定
    modelBuilder.Entity<Member>()
      .HasIndex(m => m.Position)
      .IsUnique();

    // ---- Todo ---- //
    modelBuilder.Entity<Todo>()
      .HasKey(t => t.Id);

    // NOTE: FKの設定
    modelBuilder.Entity<Todo>()
      .HasOne(t => t.Member)
      .WithMany(m => m.Todos)
      .HasForeignKey(t => t.MemberId);

    modelBuilder.Entity<Todo>()
      .HasOne(t => t.TodoType)
      .WithMany() // NOTE: ナビゲーションプロパティを持たない場合は引数を空にする
      .HasForeignKey(t => t.TodoTypeId);

    // ---- TodoType ---- //
    modelBuilder.Entity<TodoType>()
      .HasKey(t => t.Id);

    modelBuilder.Entity<TodoType>()
      .HasIndex(t => t.Name)
      .IsUnique();

    // NOTE: Seed data（初期データ生成）
    modelBuilder.Entity<Member>().HasData(
      new { Id = Guid.NewGuid().ToString(), Name = "Aさん", Position = "A", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
      new { Id = Guid.NewGuid().ToString(), Name = "Bさん", Position = "B", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
    );

    modelBuilder.Entity<TodoType>().HasData(
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
