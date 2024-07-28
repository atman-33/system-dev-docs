using DDDSampleApp.Domain.DomainModels.TodoType.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.UseCase;

namespace DDDSampleApp.Wpf.Utils;

public static class TodoConverter
{
  public static TodoDto ToTodoDto(this TodoEntity todo, IList<TodoTypeEntity> todoTypes)
  {
    var todoType = todoTypes.FirstOrDefault(tt => tt.Id == todo.TodoTypeId);

    if (todoType == null)
    {
      throw new Exception($"Todo {todo.Id.Value} に、未登録のTodoTypeが登録されています。");
    }

    return new TodoDto(
      TodoEntity: todo,
      Content: todo.Content,
      DeadLine: todo.Deadline,
      TodoTypeName: todoType.Name);
  }
}
