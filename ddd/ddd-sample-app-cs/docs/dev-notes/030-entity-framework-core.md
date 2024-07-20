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
  public Guid Id { get; set; }

  [Column("content")]
  public required string Content { get; set; }

  [Column("deadline")]
  public DateTime? Deadline { get; set; }

  [Column("status")]
  public int Status { get; set; }

  [Column("member_id")]
  public Guid MemberId { get; set; }

  [Column("todo_type_id")]
  public Guid TodoTypeId { get; set; }

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
    modelBuilder.Entity<Todo>()
      .HasOne(t => t.Member)
      .WithMany(m => m.Todos)
      .HasForeignKey(t => t.MemberId);

    modelBuilder.Entity<Todo>()
      .HasOne(t => t.TodoType)
      .WithMany() // NOTE: ナビゲーションプロパティを持たない場合は引数を空にする
      .HasForeignKey(t => t.TodoTypeId);

    // DBでGuidを文字列として扱うための設定
    modelBuilder.Entity<Member>().Property(e => e.Id).HasConversion<string>();
    modelBuilder.Entity<Todo>().Property(e => e.Id).HasConversion<string>();
    modelBuilder.Entity<Todo>().Property(e => e.MemberId).HasConversion<string>();
    modelBuilder.Entity<Todo>().Property(e => e.TodoTypeId).HasConversion<string>();
    modelBuilder.Entity<TodoType>().Property(e => e.Id).HasConversion<string>();
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

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
  public ApplicationContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
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
