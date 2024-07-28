using DDDSampleApp.Domain.Shared.Exceptions;

namespace DDDSampleApp.Domain;

public class InvalidTodoContentExecption : ExceptionBase
{
  public InvalidTodoContentExecption(string message)
  : base(message)
  {
  }

  public override ExceptionKind Kind => ExceptionKind.Error;
}
