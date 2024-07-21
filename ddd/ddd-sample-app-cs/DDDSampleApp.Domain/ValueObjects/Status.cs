namespace DDDSampleApp.Domain.ValueObjects;

public record class Status(int Value)
{
  /// <summary>未完了</summary>
  public static Status Pending = new(0);
  /// <summary>完了</summary>
  public static Status Completed = new(1);
}
