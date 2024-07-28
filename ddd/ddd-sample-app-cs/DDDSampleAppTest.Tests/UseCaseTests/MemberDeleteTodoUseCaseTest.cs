using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
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
    var todo = new TodoEntity("タスク", null, new TodoTypeId());
    var todoList = new List<TodoEntity>()
    {
      todo,
      new TodoEntity("タスク2", null, new TodoTypeId()),
      new TodoEntity("タスク3", null, new TodoTypeId()),
    };

    var member = MemberEntity.Reconstruct(
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
