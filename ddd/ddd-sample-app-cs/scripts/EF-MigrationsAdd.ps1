# マイグレーションコメントを入力する
$comment = Read-Host "Please input migration comment."

# Infrastructureに移動
Set-Location $PSScriptRoot
Set-Location ../
Set-Location DDDSampleApp.Infrastructure

# マイグレーションファイルを作成
dotnet ef migrations add $comment --output-dir Data\Migrations