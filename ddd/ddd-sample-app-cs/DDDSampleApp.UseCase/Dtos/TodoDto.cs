using DDDSampleApp.Domain.Features.Todo.Entities;

namespace DDDSampleApp.UseCase;

public record class TodoDto(
  TodoEntity Todo,
  string Content,
  DateTime? DeadLine,
  string TodoTypeName
);
