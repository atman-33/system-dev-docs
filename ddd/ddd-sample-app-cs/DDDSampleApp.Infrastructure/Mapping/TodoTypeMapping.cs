using DDDSampleApp.Domain.Models.TodoType;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.Infrastructure.Entities;

namespace DDDSampleApp.Infrastructure.Mapping;

public static class TodoTypeMapping
{

  public static TodoTypeDomain ToDomain(this TodoTypeEntity todoType)
  {
    return new TodoTypeDomain(new TodoTypeId(todoType.Id), todoType.Name);
  }
}
