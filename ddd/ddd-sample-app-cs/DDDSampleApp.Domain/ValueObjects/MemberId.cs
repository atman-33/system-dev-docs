namespace DDDSampleApp.Domain.ValueObjects;

public record class MemberId(Guid Value)
{
  public MemberId() : this(Guid.NewGuid())
  {
  }
}