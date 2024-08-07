using DDDSampleApp.Domain.Models.Member;
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
    var member = MemberDomain.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoDomain>());

    // mock
    var memberRepositoryMock = new Mock<IMemberRepository>();

    memberRepositoryMock
      .Setup(x => x.FetchByPositionAsync(Position.Leader))
      .ReturnsAsync(member);

    var useCase = new MemberGetUseCase(memberRepositoryMock.Object);
    var result = await useCase.ExecuteAsync(Position.Leader);

    Assert.AreEqual(member, result);
  }
}
