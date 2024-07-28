using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Mapping;
using DDDSampleApp.UseCase;
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

  public async Task<IList<TodoDto>> FetchAllAsync(MemberId memberId)
  {
    return await _dbContext.Todos
      .Include(t => t.TodoType)
      .Where(t => t.MemberId == memberId.Value)
      .Select(t => t.ToDto())
      .ToListAsync();
  }
}
