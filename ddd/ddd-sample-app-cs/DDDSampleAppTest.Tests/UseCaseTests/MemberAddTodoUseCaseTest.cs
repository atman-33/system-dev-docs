using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.UseCase.Services.Member;
using Moq;

namespace DDDSampleAppTest.Tests.UseCaseTests;

[TestClass]
public class MemberAddTodoUseCaseTest
{
  [TestMethod]
  public async Task Todoを追加するAsync()
  {
    var todo = TodoDomain.Create("タスク", null, new TodoTypeId());
    var member = MemberDomain.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoDomain>());

    var memberRepositoryMock = new Mock<IMemberRepository>();

    var useCase = new MemberAddTodoUseCase(memberRepositoryMock.Object);
    await useCase.ExecuteAsync(member, todo);

    Assert.AreEqual(1, member.Todos.Count);
  }
}
