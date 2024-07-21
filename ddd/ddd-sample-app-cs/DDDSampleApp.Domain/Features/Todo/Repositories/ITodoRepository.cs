using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Todo.Repositories;

public interface ITodoRepository
{
  Task<IList<TodoEntity>> FindAllAsync(MemberId id);
  Task InsertAsync(TodoEntity todo);
  Task UpdateAsync(TodoEntity todo);
  Task DeleteAsync(TodoEntity todo);
}
