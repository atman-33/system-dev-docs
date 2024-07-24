# Infrastructureに移動
Set-Location $PSScriptRoot
Set-Location ../
Set-Location DDDSampleApp.Infrastructure

# マイグレーションファイルを削除
dotnet ef migrations remove
