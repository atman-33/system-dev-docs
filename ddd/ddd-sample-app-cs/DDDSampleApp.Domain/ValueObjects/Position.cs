namespace DDDSampleApp.Domain.ValueObjects;

public record class Position(string Value)
{
  public static readonly Position Leader = new("リーダー");
  public static readonly Position Member = new("メンバー");

  public static IList<Position> List => new List<Position> { Leader, Member };

  /// <summary>
  /// 指定された値が有効な値であれば true を返す。
  /// </summary>
  /// <param name="position"></param>
  /// <returns></returns>
  public static bool CanCreate(Position position)
  {
    return List.Any(x => x == position);
  }
}