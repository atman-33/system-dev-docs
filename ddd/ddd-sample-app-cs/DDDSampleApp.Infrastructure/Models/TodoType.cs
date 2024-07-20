
using System.ComponentModel.DataAnnotations.Schema;

namespace DDDSampleApp.Infrastructure.Models;

[Table("todo_types")]
public class TodoType : IHasTimestamps
{
  [Column("id")]
  public Guid Id { get; set; }

  [Column("name")]
  public required string Name { get; set; }

  [Column("created_at")]
  public DateTime? CreatedAt { get; set; }
  [Column("updated_at")]
  public DateTime? UpdatedAt { get; set; }
}
