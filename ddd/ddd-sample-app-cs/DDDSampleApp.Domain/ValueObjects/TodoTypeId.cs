using DDDSampleApp.Domain.ValueObjects.Abstractions;

namespace DDDSampleApp.Domain.ValueObjects;

public record class TodoTypeId : GuidValueObject
{
  public TodoTypeId() : base()
  {
  }

  public TodoTypeId(string value) : base(value)
  {
  }
}