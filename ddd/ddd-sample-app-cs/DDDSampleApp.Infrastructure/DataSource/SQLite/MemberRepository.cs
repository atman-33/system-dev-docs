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
      .FirstOrDefaultAsync(x => x.Position == position.Value);

    if (member == null)
    {
      throw new Exception($"Member not found. Position: {position}");
    }

    return new MemberEntity(
      new MemberId(member.Id),
      member.Name,
      new Position(member.Position));
  }

  public Task UpdateAsync(MemberEntity member)
  {
    throw new NotImplementedException();
  }
}
