# ルートディレクトリに移動
Set-Location $PSScriptRoot
Set-Location ../

Set-Location DDDSampleApp.Wpf
npx tailwindcss -i .\Styles\app.css -o .\wwwroot\styles\app.css --watch
