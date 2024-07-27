using DDDSampleApp.Domain.DomainModels.TodoType.Entities;
using DDDSampleApp.Domain.DomainModels.TodoType.Repositories;

namespace DDDSampleApp.UseCase.Services.TodoType;

public class TodoTypeGetUseCase
{
  private ITodoTypeRepository _todoTypeRepository;

  public TodoTypeGetUseCase(ITodoTypeRepository todoTypeRepository)
  {
    _todoTypeRepository = todoTypeRepository;
  }

  public async Task<IList<TodoTypeEntity>> Execute()
  {
    var todoTypes = await _todoTypeRepository.FindAllAsync();
    return todoTypes;
    // return (IList<TodoTypeEntity>)todoTypes.OrderBy(x => x.Name);
  }
}
