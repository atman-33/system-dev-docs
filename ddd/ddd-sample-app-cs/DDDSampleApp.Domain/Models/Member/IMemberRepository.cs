using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Models.Member;

public interface IMemberRepository
{
  Task<MemberDomain> FetchByPositionAsync(Position position);
  Task UpdateAsync(MemberDomain member);
}
