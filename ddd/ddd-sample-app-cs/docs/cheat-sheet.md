# チートシート

## アプリ実行

```sh
dotnet run --project DDDSampleApp.Wpf
```

- Blazorアプリ開発は下記コマンドで実行すれば開発し易い。

```sh
dotnet watch --project DDDSampleApp.Wpf --no-hot-reload
```

## Tailwind CSS反映ホットリロード

```sh
cd DDDSampleApp.Wpf
npx tailwindcss -i .\Styles\app.css -o .\wwwroot\styles\app.css --watch
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
