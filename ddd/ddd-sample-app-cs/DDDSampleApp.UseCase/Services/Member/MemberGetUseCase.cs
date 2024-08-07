using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.UseCase.Services.Member;

public class MemberGetUseCase
{
  private readonly IMemberRepository _memberRepository;

  public MemberGetUseCase(IMemberRepository memberRepository)
  {
    _memberRepository = memberRepository;
  }

  public async Task<MemberDomain> ExecuteAsync(Position position)
  {
    return await _memberRepository.FetchByPositionAsync(position);
  }
}
