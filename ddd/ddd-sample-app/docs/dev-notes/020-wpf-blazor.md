# WPFでBlazor Hybridを構成

## ステップ

### NuGetパッケージを追加

プレゼンテーション層（Wpf）に、`Microsoft.AspNetCore.Components.WebView.Wpf`を追加する。

```powershell
cd {プレゼンテーション層のプロジェクト}
dotnet add package Microsoft.AspNetCore.Components.WebView.Wpf --version 8.0.70
```

> パッケージは最新版ではなく、.NETのVer.と合わせる事に注意する。

### プロジェクトファイルを編集

`ddd\ddd-sample-app\DDDSampleApp.Wpf\DDDSampleApp.Wpf.csproj`

- `<Project>`を、`Microsoft.NET.Sdk`を`Microsoft.NET.Sdk.Razor`に変更する。
- `<Propertyroup>`にルート名前空間を設定する。

```xml
-<Project Sdk="Microsoft.NET.Sdk">
+<Project Sdk="Microsoft.NET.Sdk.Razor">
  ...
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <UseWPF>true</UseWPF>
+   <RootNamespace>DDDSampleApp.Wpf</RootNamespace>
  </PropertyGroup>

</Project>
```

### Blazorのコンテンツを追加

#### _Imports.razor

`_Imports.razor`をプロジェクトに追加して`Microsoft.AspNetCore.Components.Web`名前空間を追加する。

`ddd\ddd-sample-app\DDDSampleApp.Wpf\_Imports.razor`

```r
@using Microsoft.AspNetCore.Components.Web
```

#### index.html

`wwwroot`フォルダをプロジェクトに追加して、さらに`index.html`を追加する。

`ddd\ddd-sample-app\DDDSampleApp.Wpf\wwwroot\index.html`

```html
<!DOCTYPE html>
<html lang="ja">

<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>WpfBlazorApp</title>
  <base href="/" />
  <link href="styles/app.css" rel="stylesheet" />
</head>

<body>

  <div id="app">Loading...</div>

  <div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
  </div>

  <script src="_framework/blazor.webview.js"></script>

</body>

</html>
```

#### app.css（サンプルのCSS）

`ddd\ddd-sample-app\DDDSampleApp.Wpf\wwwroot\styles\app.css`

```css
html, body {
  font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif;
}

h1:focus {
  outline: none;
}

a, .btn-link {
  color: #0071c1;
}

.btn-primary {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.valid.modified:not([type=checkbox]) {
  outline: 1px solid #26b050;
}

.invalid {
  outline: 1px solid red;
}

.validation-message {
  color: red;
}

#blazor-error-ui {
  background: lightyellow;
  bottom: 0;
  box-shadow: 0 -1px 2px rgba(0, 0, 0, 0.2);
  display: none;
  left: 0;
  padding: 0.6rem 1.25rem 0.7rem 1.25rem;
  position: fixed;
  width: 100%;
  z-index: 1000;
}

#blazor-error-ui .dismiss {
    cursor: pointer;
    position: absolute;
    right: 0.75rem;
    top: 0.5rem;
}
```

#### Counter.razor（サンプルのコンポーネント）

`DDDSampleApp.Wpf\wwwroot\components\Counter.razor`

```r
<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

#### HomePage.razor

`ddd\ddd-sample-app\DDDSampleApp.Wpf\wwwroot\pages\HomePage.razor`

```r
@page "/"
@using DDDSampleApp.Wpf.wwwroot.components

<h3>HomePage</h3>

<Counter />

@code {

}
```

### BlazorWebViewコントロールを追加

`ddd\ddd-sample-app\DDDSampleApp.Wpf\MainWindow.xaml`

- Windowタグに属性（blazor, pages）を追加

```xml
<Window
...
        xmlns:blazor="clr-namespace:Microsoft.AspNetCore.Components.WebView.Wpf;assembly=Microsoft.AspNetCore.Components.WebView.Wpf"
        xmlns:pages="clr-namespace:DDDSampleApp.Wpf.wwwroot.pages"
        mc:Ignorable="d"
>
```

- RootComponentsプロパティにHomePageコンポーネントを追加する。

```xml
    <Grid>
        <blazor:BlazorWebView HostPage="wwwroot\index.html" Services="{DynamicResource services}">
            <blazor:BlazorWebView.RootComponents>
                <blazor:RootComponent Selector="#app" ComponentType="{x:Type pages:HomePage}" />
            </blazor:BlazorWebView.RootComponents>
        </blazor:BlazorWebView>
    </Grid>
```

```xml
<Window x:Class="DDDSampleApp.Wpf.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:blazor="clr-namespace:Microsoft.AspNetCore.Components.WebView.Wpf;assembly=Microsoft.AspNetCore.Components.WebView.Wpf"
        xmlns:local="clr-namespace:DDDSampleApp.Wpf"
        xmlns:pages="clr-namespace:DDDSampleApp.Wpf.wwwroot.pages"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <blazor:BlazorWebView HostPage="wwwroot\index.html" Services="{DynamicResource services}">
            <blazor:BlazorWebView.RootComponents>
                <blazor:RootComponent Selector="#app" ComponentType="{x:Type pages:HomePage}" />
            </blazor:BlazorWebView.RootComponents>
        </blazor:BlazorWebView>
    </Grid>
</Window>
```

### MainWindow.xaml.csにコードを追加

`ddd\ddd-sample-app\DDDSampleApp.Wpf\MainWindow.xaml.cs`

```cs
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DDDSampleApp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
```

以上の実装を完了後、アプリが起動するか確認する。  

```powershell
dotnet run
```
