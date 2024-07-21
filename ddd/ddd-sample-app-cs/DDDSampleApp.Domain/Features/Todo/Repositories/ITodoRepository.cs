using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Todo.Repositories;

public interface ITodoRepository
{
  IList<TodoEntity> FindAll(MemberId id);
  void Insert(TodoEntity todo);
  void Update(TodoEntity todo);
  void Delete(TodoEntity todo);
}
