namespace DDDSampleApp.Infrastructure.Entities;

internal interface IHasTimestamps
{
  DateTime? CreatedAt { get; set; }
  DateTime? UpdatedAt { get; set; }
}
