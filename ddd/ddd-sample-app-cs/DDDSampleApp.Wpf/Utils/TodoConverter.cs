using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.Models.TodoType;
using DDDSampleApp.UseCase;

namespace DDDSampleApp.Wpf.Utils;

public static class TodoConverter
{
  public static TodoDto ToTodoDto(this TodoDomain todo, IList<TodoTypeDomain> todoTypes)
  {
    var todoType = todoTypes.FirstOrDefault(tt => tt.Id == todo.TodoTypeId);

    if (todoType == null)
    {
      throw new Exception($"Todo {todo.Id.Value} に、未登録のTodoTypeが登録されています。");
    }

    return new TodoDto(
      TodoDomain: todo,
      Content: todo.Content,
      DeadLine: todo.Deadline,
      TodoTypeName: todoType.Name);
  }
}
