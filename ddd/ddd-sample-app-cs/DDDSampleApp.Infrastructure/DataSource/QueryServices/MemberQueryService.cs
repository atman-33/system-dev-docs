using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.UseCase.QueryServices;
using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.QueryServices;

public class MemberQueryService : IMemberQueryService
{
  private readonly ApplicationContext _dbContext;

  public MemberQueryService()
  : this(ApplicationContextFactory.CreateDbContext())
  {
  }

  public MemberQueryService(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public Task<IList<MemberEntity>> FetchAllAsync()
  {
    throw new NotImplementedException();
  }
}
