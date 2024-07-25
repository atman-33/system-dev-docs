using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;

namespace DDDSampleApp.UseCase;

public class MemberAddTodoUseCase
{
  private MemberEntity _member;

  public MemberAddTodoUseCase(MemberEntity member)
  {
    _member = member;
  }

  public void Execute(TodoEntity todo)
  {
    _member.AddTodo(todo);
  }
}
