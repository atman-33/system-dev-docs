using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Models;
using DDDSampleApp.UseCase;

namespace DDDSampleApp.Infrastructure.Mapping;

public static class TodoMapping
{
  public static TodoModel ToModel(this TodoEntity todo, MemberId memberId)
  {
    return new TodoModel()
    {
      Id = todo.Id.Value,
      Content = todo.Content,
      Deadline = todo.Deadline,
      Status = todo.Status.Value,
      MemberId = memberId.Value,
      TodoTypeId = todo.TodoTypeId.Value
    };
  }

  public static TodoEntity ToEntity(this TodoModel todo)
  {
    return new TodoEntity(todo.Content, todo.Deadline, new TodoTypeId(todo.TodoTypeId));
  }

  public static TodoDto ToDto(this TodoModel todo)
  {
    if (todo.TodoType is null)
    {
      throw new Exception("Todo.TodoType に null が格納されています!");
    }

    return new TodoDto(
      TodoEntity: todo.ToEntity(),
      Content: todo.Content,
      DeadLine: todo.Deadline,
      TodoTypeName: todo.TodoType.Name
    );

  }
}
