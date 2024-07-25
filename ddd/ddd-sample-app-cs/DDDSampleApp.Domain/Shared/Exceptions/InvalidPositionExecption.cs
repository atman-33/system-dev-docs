using DDDSampleApp.Domain.Shared.Exceptions;

namespace DDDSampleApp.Domain;

public class InvalidPositionExecption : ExceptionBase
{
  public InvalidPositionExecption(string message)
  : base(message)
  {
  }

  public override ExceptionKind Kind => ExceptionKind.Error;
}
