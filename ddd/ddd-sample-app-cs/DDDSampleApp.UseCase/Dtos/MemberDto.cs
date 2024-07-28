using DDDSampleApp.Domain.ValueObjects;

namespace DDDSampleApp.UseCase.Dtos;
public record class MemberDto(
    MemberId Id,
    string Name,
    Position Position,
    IList<TodoDto> Todos
    );
