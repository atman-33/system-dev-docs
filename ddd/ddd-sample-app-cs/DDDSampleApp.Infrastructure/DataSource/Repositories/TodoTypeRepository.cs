using DDDSampleApp.Domain.DomainModels.TodoType.Entities;
using DDDSampleApp.Domain.DomainModels.TodoType.Repositories;
using DDDSampleApp.Infrastructure.Data;
using DDDSampleApp.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DDDSampleApp.Infrastructure;

public class TodoTypeRepository : ITodoTypeRepository
{
  private readonly ApplicationContext _dbContext;

  public TodoTypeRepository(ApplicationContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<IList<TodoTypeEntity>> FindAllAsync()
  {
    var todoTypes = await _dbContext.TodoTypes.ToListAsync();
    return todoTypes.Select(t => t.ToEntity()).ToList();
  }
}
