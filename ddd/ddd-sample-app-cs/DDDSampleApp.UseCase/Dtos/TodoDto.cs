using DDDSampleApp.Domain.Features.Todo.Entities;

namespace DDDSampleApp.UseCase;

public record class TodoDto(
  TodoEntity TodoEntity,
  string Content,
  DateTime? DeadLine,
  string TodoTypeName
);
