using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;

namespace DDDSampleApp.UseCase;

public class MemberAddTodoUseCase
{
  public MemberAddTodoUseCase()
  {
  }

  public void Execute(MemberEntity member, TodoEntity todo)
  {
    member.AddTodo(todo);
  }
}
