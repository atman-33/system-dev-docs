﻿using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.Domain.DomainModels.TodoType.Entities;

public class TodoTypeEntity
{
    public TodoTypeEntity(TodoTypeId id, string name)
    {
        Id = id;
        Name = name;
    }

    public TodoTypeId Id { get; private set; }

    public string Name { get; private set; }
}