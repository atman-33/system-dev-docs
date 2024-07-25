using DDDSampleApp.Domain.ValueObjects.Abstractions;

namespace DDDSampleApp.Domain.ValueObjects
{
  public record class MemberId : GuidValueObject
  {

    public MemberId() : base()
    {
    }

    public MemberId(string value) : base(value)
    {
    }
  }
}
