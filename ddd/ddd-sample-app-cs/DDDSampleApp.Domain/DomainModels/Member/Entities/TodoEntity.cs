using DDDSampleApp.Domain.DomainModels.TodoType.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Todo.Entities;

public class TodoEntity
{
  public TodoEntity(
    string content,
    DateTime? deadline,
    TodoTypeId todoTypeId
  )
  {
    Id = new TodoId();
    Content = content;
    Deadline = deadline;
    Status = Status.Pending;
    // TODO: TodoTypeは、DB登録済みのTodoTypeのレコードの始めを設定するように後で変更する
    TodoTypeId = todoTypeId;
  }


  private TodoEntity(TodoId id, string content, DateTime? deadline, Status status, TodoTypeId todoTypeId)
  {
    Id = id;
    Content = content;
    Deadline = deadline;
    Status = status;
    TodoTypeId = todoTypeId;
  }

  public TodoId Id { get; private set; }
  public string Content { get; set; }
  public DateTime? Deadline { get; set; }
  public Status Status { get; set; }
  public TodoTypeId TodoTypeId { get; set; }

  public static TodoEntity Reconstruct(
    TodoId id,
    string content,
    DateTime? deadline,
    Status status,
    TodoTypeId todoTypeId
  )
  {
    return new TodoEntity(id, content, deadline, status, todoTypeId);
  }
}
