using DDDSampleApp.Domain.Models.TodoType;

namespace DDDSampleApp.UseCase.Services.TodoType;

public class TodoTypeGetUseCase
{
  private ITodoTypeRepository _todoTypeRepository;

  public TodoTypeGetUseCase(ITodoTypeRepository todoTypeRepository)
  {
    _todoTypeRepository = todoTypeRepository;
  }

  public async Task<IList<TodoTypeDomain>> ExecuteAsync()
  {
    var todoTypes = await _todoTypeRepository.FetchAllAsync();
    return todoTypes.OrderBy(x => x.Name).ToList();
  }
}
