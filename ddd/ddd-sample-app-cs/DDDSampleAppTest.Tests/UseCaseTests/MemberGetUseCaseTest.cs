using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.UseCase.Services.Member;
using Moq;

namespace DDDSampleAppTest.Tests.UseCaseTests;

[TestClass]
public class MemberGetUseCaseTest
{
  [TestMethod]
  public async Task メンバーを取得する()
  {
    var member = MemberEntity.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoEntity>());

    // mock
    var memberRepositoryMock = new Mock<IMemberRepository>();

    memberRepositoryMock
      .Setup(x => x.FetchByPositionAsync(Position.Leader))
      .ReturnsAsync(member);

    var useCase = new MemberGetUseCase(memberRepositoryMock.Object);
    var result = await useCase.Execute(Position.Leader);

    Assert.AreEqual(member, result);
  }
}
