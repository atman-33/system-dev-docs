namespace DDDSampleApp.Domain.Models.TodoType;

public interface ITodoTypeRepository
{
  Task<IList<TodoTypeDomain>> FetchAllAsync();
}
