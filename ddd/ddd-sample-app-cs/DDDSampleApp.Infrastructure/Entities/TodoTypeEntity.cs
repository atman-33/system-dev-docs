
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDSampleApp.Infrastructure.Entities;

[Table("todo_types")]
public class TodoTypeEntity : IHasTimestamps
{
  [Column("id")]
  public required string Id { get; set; }

  [Column("name")]
  public required string Name { get; set; }

  [Column("created_at")]
  public DateTime? CreatedAt { get; set; }
  [Column("updated_at")]
  public DateTime? UpdatedAt { get; set; }
}
