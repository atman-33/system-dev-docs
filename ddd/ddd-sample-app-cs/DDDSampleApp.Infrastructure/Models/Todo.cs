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
