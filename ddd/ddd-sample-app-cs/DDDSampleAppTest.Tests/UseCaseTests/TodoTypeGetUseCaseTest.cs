using DDDSampleApp.Domain.DomainModels.TodoType.Entities;
using DDDSampleApp.Domain.DomainModels.TodoType.Repositories;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.UseCase.Services.TodoType;
using Moq;

namespace DDDSampleAppTest.Tests.UseCaseTests;

[TestClass]
public class TodoTypeGetUseCaseTest
{
  [TestMethod]
  public async Task TodoTypeを取得する()
  {
    var todoTypes = new List<TodoTypeEntity>{
      new TodoTypeEntity(new TodoTypeId(), "仕事"),
      new TodoTypeEntity(new TodoTypeId(), "プライベート"),
    };

    var todoTypeRepositoryMock = new Mock<ITodoTypeRepository>();
    todoTypeRepositoryMock
      .Setup(x => x.FetchAllAsync())
      .ReturnsAsync(todoTypes);

    var useCase = new TodoTypeGetUseCase(todoTypeRepositoryMock.Object);

    IEnumerable<TodoTypeEntity> result = await useCase.ExecuteAsync();
    Assert.AreEqual(2, result.Count());
    Assert.AreEqual("プライベート", result.ElementAt(0).Name);
  }
}
