# Infrastructureに移動
Set-Location $PSScriptRoot
Set-Location ../
Set-Location DDDSampleApp.Infrastructure

# マイグレーション実行
dotnet ef database update
