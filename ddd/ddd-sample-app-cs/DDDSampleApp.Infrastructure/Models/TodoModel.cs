using System.ComponentModel.DataAnnotations.Schema;

namespace DDDSampleApp.Infrastructure.Models;

[Table("todos")]
public class TodoModel : IHasTimestamps
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
  public virtual MemberModel? Member { get; set; }

  [ForeignKey(nameof(TodoTypeId))]
  public virtual TodoTypeModel? TodoType { get; set; }
}
