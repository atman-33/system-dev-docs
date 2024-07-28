using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;

namespace DDDSampleApp.UseCase.Services.Member;

public class MemberAddTodoUseCase
{
  private readonly IMemberRepository _memberRepository;

  public MemberAddTodoUseCase(IMemberRepository memberRepository)
  {
    _memberRepository = memberRepository;
  }

  public async Task ExecuteAsync(MemberEntity member, TodoEntity todo)
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
