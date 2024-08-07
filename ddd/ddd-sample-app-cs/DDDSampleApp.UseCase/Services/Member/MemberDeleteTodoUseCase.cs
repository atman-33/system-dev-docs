using DDDSampleApp.Domain.Models.Member;

namespace DDDSampleApp.UseCase.Services.Member;

public class MemberDeleteTodoUseCase
{
  private IMemberRepository _memberRepository;

  public MemberDeleteTodoUseCase(IMemberRepository memberRepository)
  {
    this._memberRepository = memberRepository;
  }

  public async Task ExecuteAsync(MemberDomain member, TodoDomain todo)
  {
    member.RemoveTodo(todo);
    await _memberRepository.UpdateAsync(member);
  }
}
