using DDDSampleApp.Domain.Features.Member.Repositories;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.QueryServices;
using DDDSampleApp.Infrastructure.Repositories;
using DDDSampleApp.UseCase.QueryServices;

namespace DDDSampleApp.Infrastructure;

public abstract class Factory
{
  public static Factory Create()
  {
    // NOTE: データストアを動的に変更する場合は、ここを変更する。
    return new SqliteFactory();
  }

  public abstract IMemberRepository CreateMemberRepository();

  public abstract IMemberQueryService CreateMemberQueryService();
}

public class SqliteFactory : Factory
{
  private readonly ApplicationContext _dbContext;

  public SqliteFactory()
  {
    _dbContext = ApplicationContextFactory.CreateDbContext();
  }

  public override IMemberQueryService CreateMemberQueryService()
  {
    return new MemberQueryService(_dbContext);
  }

  public override IMemberRepository CreateMemberRepository()
  {
    return new MemberRepository(_dbContext);
  }
}