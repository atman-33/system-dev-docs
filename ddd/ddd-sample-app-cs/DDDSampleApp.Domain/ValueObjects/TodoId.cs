namespace DDDSampleApp.Domain.ValueObjects;

public record class TodoId
{
  public string Value { get; }

  /// <summary>
  /// コンストラクタ。
  /// 引数を指定しない場合は、ランダムな値を生成する。
  /// </summary>
  public TodoId() : this(Guid.NewGuid().ToString())
  {
  }

  /// <summary>
  /// コンストラクタ。
  /// 引数に指定された文字列を ID として設定する。
  /// </summary>
  public TodoId(string value)
  {
    if (string.IsNullOrWhiteSpace(value) || !Guid.TryParse(value, out _))
    {
      throw new ArgumentException("Invalid GUID format", nameof(value));
    }
    Value = value;
  }
}