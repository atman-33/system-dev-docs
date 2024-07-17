# 初期セットアップ

## ステップ

### ソリューション作成

```powershell
dotnet new sln -n DDDSampleApp
```

### プレゼンテーション層を追加

- WPFプロジェクト作成
- ソリューションにプロジェクトを追加

```powershell
mkdir DDDSampleApp.Wpf
dotnet new wpf -o DDDSampleApp.Wpf
dotnet sln DDDSampleApp.sln add DDDSampleApp.Wpf/DDDSampleApp.Wpf.csproj
```

### インフラ層を追加

- クラスライブラリ作成
- ソリューションにプロジェクトを追加

```powershell
mkdir DDDSampleApp.Infrastructure
dotnet new classlib -o DDDSampleApp.Infrastructure
dotnet sln DDDSampleApp.sln add DDDSampleApp.Infrastructure/DDDSampleApp.Infrastructure.csproj
```

### ユースケース層を追加

- クラスライブラリ作成
- ソリューションにプロジェクトを追加

```powershell
mkdir DDDSampleApp.UseCase
dotnet new classlib -o DDDSampleApp.UseCase
dotnet sln DDDSampleApp.sln add DDDSampleApp.UseCase/DDDSampleApp.UseCase.csproj
```

### ドメイン層を追加

- クラスライブラリ作成
- ソリューションにプロジェクトを追加

```powershell
mkdir DDDSampleApp.Domain
dotnet new classlib -o DDDSampleApp.Domain
dotnet sln DDDSampleApp.sln add DDDSampleApp.Domain/DDDSampleApp.Domain.csproj
```

### テストを追加

- テストプロジェクト作成
- ソリューションにプロジェクトを追加

```powershell
mkdir DDDSampleAppTest.Tests
dotnet new mstest -o DDDSampleAppTest.Tests
dotnet sln DDDSampleApp.sln add DDDSampleAppTest.Tests/DDDSampleAppTest.Tests.csproj
```

### プロジェクト間参照を追加

- プレゼンテーション層: インフラ層、ユースケース層、ドメイン層の参照を追加

```powershell
dotnet add DDDSampleApp.Wpf/DDDSampleApp.Wpf.csproj reference DDDSampleApp.Infrastructure/DDDSampleApp.Infrastructure.csproj DDDSampleApp.UseCase/DDDSampleApp.UseCase.csproj DDDSampleApp.Domain/DDDSampleApp.Domain.csproj
```

- インフラ層: ユースケース層、ドメイン層の参照を追加

```powershell
dotnet add DDDSampleApp.Infrastructure/DDDSampleApp.Infrastructure.csproj reference DDDSampleApp.UseCase/DDDSampleApp.UseCase.csproj DDDSampleApp.Domain/DDDSampleApp.Domain.csproj
```

- ユースケース層: ドメイン層の参照を追加

```powershell
dotnet add DDDSampleApp.UseCase/DDDSampleApp.UseCase.csproj reference DDDSampleApp.Domain/DDDSampleApp.Domain.csproj
```

- テスト: インフラ層、ユースケース層、ドメイン層の参照を追加

```powershell
dotnet add DDDSampleAppTest.Tests/DDDSampleAppTest.Tests.csproj reference DDDSampleApp.Infrastructure/DDDSampleApp.Infrastructure.csproj DDDSampleApp.UseCase/DDDSampleApp.UseCase.csproj DDDSampleApp.Domain/DDDSampleApp.Domain.csproj
```