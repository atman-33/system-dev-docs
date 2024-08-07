using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Entities;
using DDDSampleApp.UseCase;

namespace DDDSampleApp.Infrastructure.Mapping;

public static class TodoMapping
{
  public static TodoEntity ToEntity(this TodoDomain todo, MemberId memberId)
  {
    return new TodoEntity()
    {
      Id = todo.Id.Value,
      Content = todo.Content,
      Deadline = todo.Deadline,
      Status = todo.Status.Value,
      MemberId = memberId.Value,
      TodoTypeId = todo.TodoTypeId.Value
    };
  }

  public static TodoDomain ToDomain(this TodoEntity todo)
  {
    return TodoDomain.Reconstruct(
      new TodoId(todo.Id),
      todo.Content,
      todo.Deadline,
      new Status(todo.Status),
      new TodoTypeId(todo.TodoTypeId));
  }

  public static TodoDto ToDto(this TodoEntity todo)
  {
    if (todo.TodoType is null)
    {
      throw new Exception("Todo.TodoType に null が格納されています!");
    }

    return new TodoDto(
      TodoDomain: todo.ToDomain(),
      Content: todo.Content,
      DeadLine: todo.Deadline,
      TodoTypeName: todo.TodoType.Name
    );

  }
}
