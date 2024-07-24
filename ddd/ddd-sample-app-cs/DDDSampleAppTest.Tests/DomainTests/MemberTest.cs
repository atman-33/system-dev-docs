using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleAppTest.Tests.DomainTests;

[TestClass]
public class DomainTests
{
    [TestMethod]
    public void メンバーとリーダーのメンバーを作成できること()
    {
        var leader = new MemberEntity(
            new MemberId(Guid.NewGuid().ToString()),
            "山田太郎",
            new Position("課長")
        );
    }
}