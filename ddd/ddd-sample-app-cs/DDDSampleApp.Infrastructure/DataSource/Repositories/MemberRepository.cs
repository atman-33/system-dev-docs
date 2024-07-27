using DDDSampleApp.Domain.DomainModels.Member.Repositories;
using DDDSampleApp.Domain.Features.Member.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
  private readonly ApplicationContext _dbContext;

  public MemberRepository(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<MemberEntity> FindByPositionAsync(Position position)
  {
    var member = await _dbContext.Members
      .Include(m => m.Todos)
      .FirstOrDefaultAsync(m => m.Position == position.Value);

    if (member == null)
    {
      throw new Exception($"Member not found. Position: {position}");
    }

    return member.ToEntity();
  }

  public Task UpdateAsync(MemberEntity member)
  {
    throw new NotImplementedException();
  }
}
