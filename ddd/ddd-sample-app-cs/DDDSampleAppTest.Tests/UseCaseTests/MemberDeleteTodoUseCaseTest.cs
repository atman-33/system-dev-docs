using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.UseCase.Services.Member;
using Moq;

namespace DDDSampleAppTest.Tests.UseCaseTests;

[TestClass]
public class MemberDeleteTodoUseCaseTest
{
  [TestMethod]
  public async Task Todoを削除するAsync()
  {
    // ダミー作成
    var todo = TodoDomain.Create("タスク", null, new TodoTypeId());
    var todoList = new List<TodoDomain>()
    {
      todo,
      TodoDomain.Create("タスク2", null, new TodoTypeId()),
      TodoDomain.Create("タスク3", null, new TodoTypeId()),
    };

    var member = MemberDomain.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      todoList);

    Assert.AreEqual(3, member.Todos.Count);

    // mock作成
    var memberRepositoryMock = new Mock<IMemberRepository>();

    // UseCase作成
    var useCase = new MemberDeleteTodoUseCase(memberRepositoryMock.Object);

    // Todoを削除
    await useCase.ExecuteAsync(member, todo);

    // 数が減ったか確認
    Assert.AreEqual(2, member.Todos.Count);
  }
}
