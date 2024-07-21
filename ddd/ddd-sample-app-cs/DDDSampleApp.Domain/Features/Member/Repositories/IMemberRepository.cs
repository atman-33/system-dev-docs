using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Member.Repositories;

public interface IMemberRepository
{
  Task<MemberEntity> FindByPositionAsync(Position position);
  Task UpdateAsync(MemberEntity member);
}
