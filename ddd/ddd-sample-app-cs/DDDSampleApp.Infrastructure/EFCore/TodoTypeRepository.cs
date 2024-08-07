using DDDSampleApp.Domain.Models.TodoType;
using DDDSampleApp.Infrastructure;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure.EFCore;

public class TodoTypeRepository : ITodoTypeRepository
{
  private readonly ApplicationContext _dbContext;

  public TodoTypeRepository(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<IList<TodoTypeDomain>> FetchAllAsync()
  {
    var todoTypes = await _dbContext.TodoTypes.ToListAsync();
    return todoTypes.Select(t => t.ToDomain()).ToList();
  }
}
