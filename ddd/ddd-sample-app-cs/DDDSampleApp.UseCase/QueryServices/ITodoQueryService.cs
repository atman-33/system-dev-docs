using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.UseCase.QueryServices;

public interface ITodoQueryService
{
  // メンバー情報取得は、エンティティの集約単位と異なるためクエリサービスで対応（CQRSパターン）

  public Task DeleteAsync(TodoId todoId);
}

