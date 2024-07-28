using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Models;

namespace DDDSampleApp.Infrastructure.Mapping;

public static class TodoMapping
{
  public static Todo ToModel(this TodoEntity todo, MemberId memberId)
  {
    return new Todo()
    {
      Id = todo.Id.Value,
      Content = todo.Content,
      Deadline = todo.Deadline,
      Status = todo.Status.Value,
      MemberId = memberId.Value,
      TodoTypeId = todo.TodoTypeId.Value
    };
  }

}
