using DDDSampleApp.Domain.ValueObjects.Abstractions;

namespace DDDSampleApp.Domain.ValueObjects;

public record class TodoId : GuidValueObject
{
  public TodoId() : base()
  {
  }

  public TodoId(string value) : base(value)
  {
  }
}