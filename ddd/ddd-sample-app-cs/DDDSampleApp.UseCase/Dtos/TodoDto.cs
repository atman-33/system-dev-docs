using DDDSampleApp.Domain.Models.Member;

namespace DDDSampleApp.UseCase;

public record class TodoDto(
  TodoDomain TodoDomain,
  string Content,
  DateTime? DeadLine,
  string TodoTypeName
);
