Write-Host "Starting app..."

# ルートディレクトリに移動
Set-Location $PSScriptRoot
Set-Location ../

dotnet run --project DDDSampleApp.Wpf

Write-Host "Done."