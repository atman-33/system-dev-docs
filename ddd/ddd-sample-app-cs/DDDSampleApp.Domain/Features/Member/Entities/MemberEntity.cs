using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Features.Member.Entities;

public class MemberEntity
{
  public MemberEntity(MemberId id, string name, Position position)
  {
    Id = id;
    Name = name;
    Position = position;
  }

  public MemberId Id { get; private set; }
  public string Name { get; set; }
  public Position Position { get; set; }

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
    Position position
  )
  {
    if (!Position.CanCreate(position))
    {
      // 予め準備しているpositionの値と違う値を設定した場合は例外を投げる
      throw new Exception($"Invalid position: {position}");
    }

    return new MemberEntity(id, name, position);
  }
}