using DDDSampleApp.Domain.Features.Todo.Entities;
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

    public void Execute(TodoEntity todo)
    {
      throw new NotImplementedException();
    }
  }
}
