using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.UseCase.Services.Member;
using Moq;

namespace DDDSampleAppTest.Tests.UseCaseTests;

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

    var memberRepositoryMock = new Mock<IMemberRepository>();

    var useCase = new MemberAddTodoUseCase(memberRepositoryMock.Object);
    useCase.ExecuteAsync(member, todo);

    Assert.AreEqual(1, member.Todos.Count);
  }
}
