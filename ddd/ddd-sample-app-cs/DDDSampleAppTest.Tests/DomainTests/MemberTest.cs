using DDDSampleApp.Domain;
using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleAppTest.Tests.DomainTests;

[TestClass]
public class MemberTest
{
  [TestMethod]
  public void メンバーとリーダーのメンバーを作成できること()
  {
    Assert.ThrowsException<InvalidPositionExecption>(() =>
    {
      var boss = MemberDomain.Reconstruct(
              new MemberId(Guid.NewGuid().ToString()),
              "山田太郎",
              new Position("課長"),
              new List<TodoDomain>()
          );
    });
  }

  [TestMethod]
  public void Todoを追加する()
  {
    var todo = TodoDomain.Create("タスク", null, new TodoTypeId());
    var member = MemberDomain.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoDomain>());

    member.AddTodo(todo);
    Assert.AreEqual(1, member.Todos.Count);
  }

  [TestMethod]
  public void Todo内容が空白はエラー()
  {
    var todo = TodoDomain.Create(string.Empty, null, new TodoTypeId());
    var member = MemberDomain.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoDomain>());

    Assert.ThrowsException<InvalidTodoContentExecption>(() =>
    {
      member.AddTodo(todo);
    });
    Assert.AreEqual(0, member.Todos.Count);
  }
}