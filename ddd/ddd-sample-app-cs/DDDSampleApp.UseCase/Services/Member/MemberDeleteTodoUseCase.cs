using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;

namespace DDDSampleApp.UseCase.Services.Member;

public class MemberDeleteTodoUseCase
{
  private IMemberRepository _memberRepository;

  public MemberDeleteTodoUseCase(IMemberRepository memberRepository)
  {
    this._memberRepository = memberRepository;
  }

  public async Task ExecuteAsync(MemberEntity member, TodoEntity todo)
  {
    member.RemoveTodo(todo);
    await _memberRepository.UpdateAsync(member);
  }
}
