namespace DDDSampleApp.Domain.ValueObjects.Abstractions;

public abstract record class GuidValueObject
{
  public string Value { get; }

  /// <summary>
  /// コンストラクタ。
  /// 引数を指定しない場合は、ランダムな値を生成する。
  /// </summary>
  protected GuidValueObject() : this(Guid.NewGuid().ToString())
  {
  }

  /// <summary>
  /// コンストラクタ。
  /// 引数に指定された文字列を ID として設定する。
  /// </summary>
  protected GuidValueObject(string value)
  {
    if (string.IsNullOrWhiteSpace(value) || !Guid.TryParse(value, out _))
    {
      throw new ArgumentException("Invalid GUID format", nameof(value));
    }
    Value = value;
  }

  public override string ToString() => Value;

  public static implicit operator string(GuidValueObject guidValueObject) => guidValueObject.Value;
}