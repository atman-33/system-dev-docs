using DDDSampleApp.Domain.DomainModels.TodoType.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Models;

namespace DDDSampleApp.Infrastructure.Mapping;

public static class TodoTypeMapping
{

  public static TodoTypeEntity ToEntity(this TodoType todoType)
  {
    return new TodoTypeEntity(new TodoTypeId(todoType.Id), todoType.Name);
  }
}
