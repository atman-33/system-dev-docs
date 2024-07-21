using DDDSampleApp.Domain.Features.Member.Repositories;
using DDDSampleApp.Domain.Features.Todo.Repositories;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Repositories.Sqlite;

namespace DDDSampleApp.Infrastructure;

public abstract class AbstractFactory
{
  public static AbstractFactory Create()
  {
    // NOTE: データストアを動的に変更する場合は、ここを変更する。
    return new SqliteFactory();
  }

  public abstract IMemberRepository CreateMemberRepository();
  public abstract ITodoRepository CreateTodoRepository();
}

public class SqliteFactory : AbstractFactory
{
  private readonly ApplicationContext _dbContext;

  public SqliteFactory()
  {
    _dbContext = new ApplicationContext();
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