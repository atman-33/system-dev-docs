namespace DDDSampleApp.Domain.ValueObjects;

public record class Position(string Value)
{
  public static readonly Position MemberA = new("A");
  public static readonly Position MemberB = new("B");

  public static IList<Position> List => new List<Position> { MemberA, MemberB };

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