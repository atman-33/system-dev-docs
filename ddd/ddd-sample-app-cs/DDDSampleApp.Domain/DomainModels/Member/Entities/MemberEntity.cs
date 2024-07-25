using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Member.Entities;

public class MemberEntity
{
  private MemberEntity(
    MemberId id,
    string name,
    Position position,
    IList<TodoEntity>? todos = null
  )
  {
    Id = id;
    Name = name;
    Position = position;
    Todos = todos ?? new List<TodoEntity>();
  }

  public MemberId Id { get; private set; }
  public string Name { get; set; }
  public Position Position { get; set; }
  public IList<TodoEntity> Todos { get; private set; }

  /// <summary>
  /// メンバーを再構成する（DBから取得したデータなどから）。
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="position"></param>
  /// <returns></returns>
  public static MemberEntity Reconstruct(
    MemberId id,
    string name,
    Position position,
    IList<TodoEntity> todos
  )
  {
    if (!Position.CanCreate(position))
    {
      // 予め準備しているpositionの値と違う値を設定した場合は例外を投げる
      throw new InvalidPositionExecption($"Invalid position: {position}");
    }

    return new MemberEntity(id, name, position, todos);
  }

  /// <summary>
  /// Todoを追加する。
  /// </summary>
  /// <param name="todo"></param>
  public void AddTodo(TodoEntity todo)
  {
    Todos.Add(todo);
  }
}