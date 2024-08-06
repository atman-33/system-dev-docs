using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.UseCase.QueryServices;
using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.QueryServices;

public class TodoQueryService : ITodoQueryService
{
  private readonly ApplicationContext _dbContext;

  public TodoQueryService(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task DeleteAsync(TodoId todoId)
  {
    await _dbContext.Todos
      .Where(t => t.Id == todoId.Value)
      .ExecuteDeleteAsync();
  }
}
