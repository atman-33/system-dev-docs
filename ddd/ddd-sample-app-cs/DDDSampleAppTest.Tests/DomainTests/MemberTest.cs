using DDDSampleApp.Domain;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
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
      var boss = MemberEntity.Reconstruct(
              new MemberId(Guid.NewGuid().ToString()),
              "山田太郎",
              new Position("課長"),
              new List<TodoEntity>()
          );
    });
  }

  [TestMethod]
  public void Todoを追加する()
  {
    var todo = new TodoEntity("タスク", null, new TodoTypeId());
    var member = MemberEntity.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoEntity>());

    member.AddTodo(todo);
    Assert.AreEqual(1, member.Todos.Count);
  }

  [TestMethod]
  public void Todo内容が空白はエラー()
  {
    var todo = new TodoEntity(string.Empty, null, new TodoTypeId());
    var member = MemberEntity.Reconstruct(
      new MemberId(),
      "山田太郎",
      Position.Leader,
      new List<TodoEntity>());

    Assert.ThrowsException<InvalidTodoContentExecption>(() =>
    {
      member.AddTodo(todo);
    });
    Assert.AreEqual(0, member.Todos.Count);
  }
}