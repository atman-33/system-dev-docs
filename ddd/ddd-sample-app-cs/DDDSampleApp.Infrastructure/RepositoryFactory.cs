using DDDSampleApp.Domain.Features.Member.Repositories;
using DDDSampleApp.Domain.Features.Todo.Repositories;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Repositories.Sqlite;

namespace DDDSampleApp.Infrastructure;

public abstract class RepositoryFactory
{
  public static RepositoryFactory Create()
  {
    // NOTE: データストアを動的に変更する場合は、ここを変更する。
    return new SqliteFactory();
  }

  public abstract IMemberRepository CreateMemberRepository();
  public abstract ITodoRepository CreateTodoRepository();
}

public class SqliteFactory : RepositoryFactory
{
  private readonly ApplicationContext _dbContext;

  public SqliteFactory()
  {
    _dbContext = ApplicationContextFactory.CreateDbContext();
  }

  public override IMemberRepository CreateMemberRepository()
  {
    return new MemberRepository(_dbContext);
  }

  public override ITodoRepository CreateTodoRepository()
  {
    throw new NotImplementedException();
  }
}