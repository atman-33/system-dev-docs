# チートシート

## アプリ実行

```sh
dotnet run --project DDDSampleApp.Wpf
```

## Entity Framework Core コマンド

### マイグレーションファイル作成

```sh
cd {インフラ層のプロジェクト}
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
```

### マイグレーション実行

```sh
dotnet ef database update
```

### 最後のマイグレーションを削除する

```sh
dotnet ef migrations remove
```
