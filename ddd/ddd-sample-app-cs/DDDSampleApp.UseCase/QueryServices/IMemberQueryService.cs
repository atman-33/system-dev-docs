using DDDSampleApp.Domain.Features.Member.Entities;

namespace DDDSampleApp.UseCase.QueryServices;

public interface IMemberQueryService
{
  // メンバー情報取得は、エンティティの集約単位と異なるためクエリサービスで対応（CQRSパターン）

  public Task<IList<MemberEntity>> FetchAllAsync();
}

