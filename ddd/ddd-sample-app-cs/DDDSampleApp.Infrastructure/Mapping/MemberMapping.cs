using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Entities;

namespace DDDSampleApp.Infrastructure;

public static class MemberMapping
{

  public static MemberDomain ToDomain(this MemberEntity member)
  {
    return MemberDomain.Reconstruct(
      new MemberId(member.Id),
      member.Name,
      new Position(member.Position),
      member.Todos
        .Select(t => TodoDomain.Reconstruct(
          new TodoId(t.Id),
          t.Content,
          t.Deadline,
          new Status(t.Status),
          new TodoTypeId(t.TodoTypeId)
        )).ToList()
    );
  }

  public static MemberEntity ToEntity(this MemberDomain member)
  {
    return new MemberEntity()
    {
      Id = member.Id.Value,
      Name = member.Name,
      Position = member.Position.Value
    };
  }
}
