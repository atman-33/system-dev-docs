using System.ComponentModel.DataAnnotations.Schema;

namespace DDDSampleApp.Infrastructure.Models;

[Table("members")]
public class Member : IHasTimestamps
{
  [Column("id")]
  public required string Id { get; set; }

  [Column("name")]
  public required string Name { get; set; }

  [Column("position")]
  public required string Position { get; set; }

  [Column("created_at")]
  public DateTime? CreatedAt { get; set; }
  [Column("updated_at")]
  public DateTime? UpdatedAt { get; set; }

  // ---- Navigation properties ---- //
  /* NOTE: 
  エンティティフレームワーク（Entity Framework）では、
  遅延読み込み（Lazy Loading）や変更追跡プロキシ（Change Tracking Proxy）を使用する際に、
  ナビゲーションプロパティに virtual 修飾子を付ける必要がある。*/
  public virtual ICollection<Todo>? Todos { get; set; }
}
