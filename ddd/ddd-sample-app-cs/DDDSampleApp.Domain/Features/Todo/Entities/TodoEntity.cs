using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Todo.Entities;

public class TodoEntity
{
  public TodoEntity(
    string content,
    DateTime? deadline,
    MemberId memberId,
    TodoTypeEntity todoType
  )
  {
    Id = new TodoId();
    Content = content;
    Deadline = deadline;
    Status = Status.Pending;
    MemberId = memberId;
    // TODO: TodoTypeは、DB登録済みのTodoTypeのレコードの始めを設定するように後で変更する
    TodoType = todoType;
  }

  public TodoId Id { get; private set; }
  public string Content { get; set; }
  public DateTime? Deadline { get; set; }
  public Status Status { get; set; }
  public MemberId MemberId { get; set; }
  public TodoTypeEntity TodoType { get; set; }
}
