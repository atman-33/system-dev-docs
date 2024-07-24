using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.UseCase;

public class MemberGetUseCase
{
  private IMemberRepository _memberRepository;

  public MemberGetUseCase(IMemberRepository memberRepository)
  {
    _memberRepository = memberRepository;
  }

  public async Task<MemberEntity> Execute(Position position)
  {
    return await _memberRepository.FindByPositionAsync(position);
  }
}
