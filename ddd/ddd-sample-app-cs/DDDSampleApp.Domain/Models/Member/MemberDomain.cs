using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Models.Member;

public class MemberDomain
{
  private MemberDomain(
    MemberId id,
    string name,
    Position position,
    IList<TodoDomain>? todos = null
  )
  {
    Id = id;
    Name = name;
    Position = position;
    Todos = todos ?? new List<TodoDomain>();
  }

  public MemberId Id { get; private set; }
  public string Name { get; set; }
  public Position Position { get; set; }
  public IList<TodoDomain> Todos { get; private set; }

  /// <summary>
  /// メンバーを再構成する（DBから取得したデータなどから）。
  /// </summary>
  /// <param name="id"></param>
  /// <param name="name"></param>
  /// <param name="position"></param>
  /// <returns></returns>
  public static MemberDomain Reconstruct(
    MemberId id,
    string name,
    Position position,
    IList<TodoDomain> todos
  )
  {
    if (!Position.CanCreate(position))
    {
      // 予め準備しているpositionの値と違う値を設定した場合は例外を投げる
      throw new InvalidPositionExecption($"Invalid position: {position}");
    }

    return new MemberDomain(id, name, position, todos);
  }

  /// <summary>
  /// Todoを追加する。
  /// </summary>
  /// <param name="todo"></param>
  public void AddTodo(TodoDomain todo)
  {
    if (todo.Content == string.Empty)
    {
      throw new InvalidTodoContentExecption("Todo.Contentに空白は設定できません!");
    }

    Todos.Add(todo);
  }

  public void RemoveTodo(TodoDomain todo)
  {
    Todos.Remove(todo);
  }
}