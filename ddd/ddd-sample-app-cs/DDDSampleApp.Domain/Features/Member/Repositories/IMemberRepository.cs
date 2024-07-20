using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Member.Repositories;

public interface IMemberRepository
{
  MemberEntity FindById(MemberId id);
  void Update(MemberEntity member);
}
