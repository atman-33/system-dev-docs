using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.UseCase.Services.Member;

public class MemberGetUseCase
{
  private readonly IMemberRepository _memberRepository;

  public MemberGetUseCase(IMemberRepository memberRepository)
  {
    _memberRepository = memberRepository;
  }

  public async Task<MemberEntity> Execute(Position position)
  {
    return await _memberRepository.FetchByPositionAsync(position);
  }
}
