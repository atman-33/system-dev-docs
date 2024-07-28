using DDDSampleApp.Domain.Features.Member.Entities;

namespace DDDSampleApp.UseCase.Dtos;
public record class MemberDto(
    MemberEntity Member,
    IList<TodoDto> Todos
    );
