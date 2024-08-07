using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.UseCase.QueryServices;

namespace DDDSampleApp.UseCase.Services.Todo
{
  public class TodoDeleteUseCase
  {
    private ITodoQueryService _todoQueryService;

    public TodoDeleteUseCase(ITodoQueryService todoQueryService)
    {
      _todoQueryService = todoQueryService;
    }

    public void Execute(TodoDomain todo)
    {
      throw new NotImplementedException();
    }
  }
}
