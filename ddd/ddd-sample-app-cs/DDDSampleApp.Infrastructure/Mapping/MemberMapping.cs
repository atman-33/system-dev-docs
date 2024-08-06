using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Models;

namespace DDDSampleApp.Infrastructure;

public static class MemberMapping
{

  public static MemberEntity ToEntity(this MemberModel member)
  {
    return MemberEntity.Reconstruct(
      new MemberId(member.Id),
      member.Name,
      new Position(member.Position),
      member.Todos
        .Select(t => TodoEntity.Reconstruct(
          new TodoId(t.Id),
          t.Content,
          t.Deadline,
          new Status(t.Status),
          new TodoTypeId(t.TodoTypeId)
        )).ToList()
    );
  }

  public static MemberModel ToModel(this MemberEntity member)
  {
    return new MemberModel()
    {
      Id = member.Id.Value,
      Name = member.Name,
      Position = member.Position.Value
    };
  }
}
