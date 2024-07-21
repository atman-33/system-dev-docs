# BlazorでTailwind CSSを設定

## 参考URL

[Blazor WASMでTailwind CSSを使う](https://qiita.com/k-yamamoto/items/a78ab6bea37414cd3308)
[2024: Blazor のウェブアプリで tailwind.css を利用 (ASP.NET Core / .Net 8.0 対象）](https://qiita.com/Meister619/items/b33b8570ee29aeb4a84a)

## ステップ

### Tailwind CSSをインストール

Blazorのcsprojファイルがあるディレクトリ（プレゼンテーション層）で下記を実行する。

```sh
npx tailwindcss init
```

## tailwind config ファイルを変更

- content に razor を追加する。

`DDDSampleApp.Wpf\tailwind.config.js`

```js
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor,html}'], // razor, htmlファイルを設定
  theme: {
    extend: {},
  },
  plugins: [],
}
```

### app.cs ファイルを作成

- Styles\app.css を作成

`DDDSampleApp.Wpf\Styles\app.css`

```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

- wwwroot\styles\app.css を作成

`DDDSampleApp.Wpf\wwwroot\styles\app.css`

- app.css参照をindex.htmlに追加

`DDDSampleApp.Wpf\wwwroot\index.html`

```html
<link href="css/app.css" rel="stylesheet" />
```

### tailwindを反映するホットリロードモード起動

```sh
npx tailwindcss -i .\Styles\app.css -o .\wwwroot\styles\app.css --watch
```

> このコマンドはtailwind.config.jsのcontentが変更されると/wwwroot/css/app.cssを更新するプログラム。
> 開発中は実行させておく。
