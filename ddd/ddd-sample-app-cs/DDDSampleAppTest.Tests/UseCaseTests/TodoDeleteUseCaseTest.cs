using DDDSampleApp.Domain.Features.Todo.Entities;
using DDDSampleApp.Domain.ValueObjects;
using DDDSampleApp.UseCase.QueryServices;
using DDDSampleApp.UseCase.Services.Todo;
using Moq;

namespace DDDSampleAppTest.Tests.UseCaseTests
{
  [TestClass]
  internal class TodoDeleteUseCaseTest
  {
    [TestMethod]
    public void 不要_Todoを削除する()
    {
      // ダミーデータ作成
      var todo = new TodoEntity("タスク", null, new TodoTypeId());

      // mock作成
      var todoQueryServiceMock = new Mock<ITodoQueryService>();

      // ユースケース生成（リポジトリ引数）
      var useCase = new TodoDeleteUseCase(todoQueryServiceMock.Object);

      // todoを削除
      useCase.Execute(todo);
    }
  }
}
