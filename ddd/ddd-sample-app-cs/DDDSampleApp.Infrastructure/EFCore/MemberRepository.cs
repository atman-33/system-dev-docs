﻿using DDDSampleApp.Domain.Models.Member;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
  private readonly ApplicationContext _dbContext;

  public MemberRepository(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<MemberDomain> FetchByPositionAsync(Position position)
  {
    var member = await _dbContext.Members
      .Include(m => m.Todos)
      .FirstOrDefaultAsync(m => m.Position == position.Value);

    if (member == null)
    {
      throw new Exception($"Member not found. Position: {position}");
    }

    return member.ToDomain();
  }

  public async Task UpdateAsync(MemberDomain updatedMember)
  {
    var existingMember = await _dbContext.Members.FindAsync(updatedMember.Id.Value);

    if (existingMember == null)
    {
      throw new Exception($"Member not found. MemberId: {updatedMember.Id}");
    }

    // 1. メンバー情報を更新する。
    _dbContext.Members.Entry(existingMember).CurrentValues.SetValues(updatedMember.ToEntity());

    // 2-1. 先にmemberに含まれるtodosを全て削除する。
    await _dbContext.Todos.Where(t => t.MemberId == updatedMember.Id.Value).ExecuteDeleteAsync();

    // 2.2 新しいtodosを全て追加する。
    foreach (var todo in updatedMember.Todos)
    {
      _dbContext.Todos.Add(todo.ToEntity(updatedMember.Id));
    }

    await _dbContext.SaveChangesAsync();  // Commit
  }
}
