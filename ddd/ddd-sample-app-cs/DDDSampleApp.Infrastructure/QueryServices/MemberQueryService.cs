using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.UseCase.QueryServices;
using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.QueryServices;

public class MemberQueryService : IMemberQueryService
{
  private readonly ApplicationContext _dbContext;

  public MemberQueryService(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<IList<MemberEntity>> FetchAllAsync()
  {
    return await _dbContext.Members
        .Select(m => new MemberEntity(
            new MemberId(m.Id),
            m.Name,
            new Position(m.Position)
        ))
        .ToListAsync();
  }
}
