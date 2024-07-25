using DDDSampleApp.Domain.DomainModels.TodoType.Entities;

namespace DDDSampleApp.Domain.DomainModels.TodoType.Repositories;

public interface ITodoTypeRepository
{
  Task<IList<TodoTypeEntity>> FindAllAsync();
}
