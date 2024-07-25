using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.UseCase;

namespace DDDSampleAppTest.Tests;

[TestClass]
public class MemberAddTodoUseCaseTest
{
  [TestMethod]
  public void Todoを追加する()
  {
    var todo = new TodoEntity("タスク", null, new TodoTypeId());
    var member = MemberEntity.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoEntity>());

    var useCase = new MemberAddTodoUseCase(member);
    useCase.Execute(todo);

    Assert.AreEqual(1, member.Todos.Count);
  }
}
