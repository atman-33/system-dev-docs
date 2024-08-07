using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Models.Member;

public class TodoDomain
{
  private TodoDomain(TodoId id, string content, DateTime? deadline, Status status, TodoTypeId todoTypeId)
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

  public static TodoDomain Create(
    string content,
    DateTime? deadline,
    TodoTypeId todoTypeId
  )
  {
    return new TodoDomain(new TodoId(), content, deadline, Status.Pending, todoTypeId);
  }

  public static TodoDomain Reconstruct(
    TodoId id,
    string content,
    DateTime? deadline,
    Status status,
    TodoTypeId todoTypeId
  )
  {
    return new TodoDomain(id, content, deadline, status, todoTypeId);
  }
}
