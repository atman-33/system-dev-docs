using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.Models.TodoType;

public class TodoTypeDomain
{
    public TodoTypeDomain(TodoTypeId id, string name)
    {
        Id = id;
        Name = name;
    }

    public TodoTypeId Id { get; private set; }

    public string Name { get; private set; }
}
