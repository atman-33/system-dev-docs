# エンティティフレームワークコアを実装

## ステップ

### NuGetパッケージを追加

インフラ層（Infrastructure）に、下記のパッケージを追加する。

- Microsoft.EntityFrameworkCore.SQLite （SQLite 本体）
- Microsoft.EntityFrameworkCore.Proxies （データの遅延読み込みサポート用）
- Microsoft.EntityFrameworkCore.Tools （マイグレーション用）
- dotnet-ef （マイグレーション用）
- Microsoft.EntityFrameworkCore.Design （マイグレーション用）

```sh
cd {インフラ層のプロジェクト}
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.7
dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 8.0.7
dotnet tool install --global dotnet-ef --version 8.0.7
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.7
```

> パッケージは最新版ではなく、.NETのVer.と合わせる事に注意する。

### モデルクラスを作成

DBテーブル定義に従って、モデルクラスを定義する。

e.g.  

`DDDSampleApp.Infrastructure\Models\Todo.cs`

```cs
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDSampleApp.Infrastructure.Models;

[Table("todos")]
public class Todo : IHasTimestamps
{
  [Column("id")]
  public required string Id { get; set; }

  [Column("content")]
  public required string Content { get; set; }

  [Column("deadline")]
  public DateTime? Deadline { get; set; }

  [Column("status")]
  public int Status { get; set; }

  [Column("member_id")]
  public required string MemberId { get; set; }

  [Column("todo_type_id")]
  public required string TodoTypeId { get; set; }

  [Column("created_at")]
  public DateTime? CreatedAt { get; set; }
  [Column("updated_at")]
  public DateTime? UpdatedAt { get; set; }

  // ---- Navigation properties ---- //
  /* NOTE: 
  エンティティフレームワーク（Entity Framework）では、
  遅延読み込み（Lazy Loading）や変更追跡プロキシ（Change Tracking Proxy）を使用する際に、
  ナビゲーションプロパティに virtual 修飾子を付ける必要がある。*/
  [ForeignKey(nameof(MemberId))]
  public virtual required Member Member { get; set; }

  [ForeignKey(nameof(TodoTypeId))]
  public virtual required TodoType TodoType { get; set; }
}
```

### コンテキストクラスを作成

`DDDSampleApp.Infrastructure\Data\ApplicationContext.cs`

```cs
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

  public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
  {
    // NOTE: 状態が変更された際にタイムスタンプを更新するイベントを設定
    ChangeTracker.Tracked += UpdateTimestamps;
    ChangeTracker.StateChanged += UpdateTimestamps;
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
```

### コンテキストファクトリークラスを作成

`dotnet ef migrations`コマンドを実行するために必要となる。

`DDDSampleApp.Infrastructure\Data\ApplicationContextFactory.cs`

```cs
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
    optionsBuilder.UseSqlite("Data Source=fake.db");
    optionsBuilder.UseLazyLoadingProxies();
    return new ApplicationContext(optionsBuilder.Options);
  }
}
```

### マイグレーションファイルを作成

```sh
cd {インフラ層のプロジェクト}
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
```

### マイグレーション実行クラスを作成

`DDDSampleApp.Infrastructure\Data\DataExtensions.cs`

```cs
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
```

### App.xaml.cs にマイグレーション実行処理を追加

`DDDSampleApp.Wpf\App.xaml.cs`

```cs
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
```

以上で、アプリ実行後にDBマイグレーションが実行される。
