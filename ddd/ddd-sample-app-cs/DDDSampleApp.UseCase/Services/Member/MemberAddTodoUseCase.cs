using DDDSampleApp.Domain.Models.Member;

namespace DDDSampleApp.UseCase.Services.Member;

public class MemberAddTodoUseCase
{
  private readonly IMemberRepository _memberRepository;

  public MemberAddTodoUseCase(IMemberRepository memberRepository)
  {
    _memberRepository = memberRepository;
  }

  public async Task ExecuteAsync(MemberDomain member, TodoDomain todo)
  {
    member.AddTodo(todo);
    try
    {
      await _memberRepository.UpdateAsync(member);
    }
    catch (Exception e)
    {
      {
        member.RemoveTodo(todo);
        throw new Exception(e.Message, e);
      }
    }
  }
}
