# シンプル仙台製造所 本数計管理システム

添付画像に基づいて作成したシンプルなC# .NET作業者マスタ画面です。

## 🚀 すぐにデバッグ実行できる機能

- **Visual Studio Code対応**: F5キーでデバッグ実行可能
- **コマンドライン実行**: `dotnet run`で即座に起動
- **シンプル設計**: 最小限のコードで動作

## 📋 機能一覧

### ✅ 作業者データ管理
- 作業者番号、名前1、名前2の表示
- データの登録（新規・更新）
- データの削除
- 行クリックによる選択

### ✅ ユーザーインターフェース
- 画像と同じデザイン
- Windows風のクラシックボタン
- メッセージ表示領域
- 下部メニューボタン（アラート表示）

## 🛠️ 技術構成

- **フレームワーク**: ASP.NET Core 8.0 MVC
- **言語**: C#
- **フロントエンド**: HTML + CSS + JavaScript
- **データ**: メモリ内リスト（シンプル実装）

## 🏃‍♂️ クイックスタート

### 1. Visual Studio Codeでデバッグ実行

```
1. このフォルダをVS Codeで開く
2. F5キーを押す
3. ブラウザが自動で開きます
```

### 2. コマンドラインで実行

```bash
# プロジェクトフォルダに移動
cd SimpleWorkerSystem

# アプリケーション起動
dotnet run

# ブラウザで以下にアクセス
# http://localhost:5000
```

### 3. 特定ポートで実行

```bash
dotnet run --urls="http://localhost:5001"
```

## 🎯 使用方法

### 作業者登録
1. 右側フォームに情報入力
2. 「登録」ボタンクリック
3. テーブルに新しいデータが追加されます

### 作業者削除
1. テーブルの行をクリックして選択
2. 「削除」ボタンクリック
3. 確認ダイアログで「OK」

### データ選択
- テーブルの行をクリックすると右側フォームに値が自動入力されます

## 📁 プロジェクト構造

```
SimpleWorkerSystem/
├── Controllers/
│   └── HomeController.cs          # メインコントローラー
├── Models/
│   └── Worker.cs                  # 作業者データモデル
├── Views/
│   ├── Home/
│   │   └── Index.cshtml          # メイン画面
│   └── Shared/
│       └── _Layout.cshtml        # レイアウト
├── .vscode/
│   ├── launch.json               # デバッグ設定
│   └── tasks.json                # ビルドタスク
├── Program.cs                    # アプリエントリーポイント
└── README.md                     # このファイル
```

## 🔧 デバッグ情報

### ブレークポイント設定可能場所
- `HomeController.cs` の各アクションメソッド
- `Index.cshtml` のJavaScript関数

### 開発モード確認
- プロジェクトは開発モード（Development）で起動
- 詳細エラー情報が表示されます
- ホットリロード対応（`dotnet watch run`）

## 🎨 カスタマイズ

### デザイン変更
- `Views/Home/Index.cshtml`のCSSセクションを編集

### 機能追加
- `HomeController.cs`にアクションメソッド追加
- `Models/Worker.cs`にプロパティ追加

### データ永続化
- Entity Framework Core追加
- データベース接続実装

## 初期データ

起動時に以下のサンプルデータが登録されています：
- 作業者番号: 001
- 名前1: JFE  
- 名前2: タロウ

## トラブルシューティング

### ポートが使用中の場合
```bash
dotnet run --urls="http://localhost:5002"
```

### ビルドエラーの場合
```bash
dotnet clean
dotnet build
```

---

**このプロジェクトは、Visual Studio CodeのF5キーまたは`dotnet run`コマンドですぐにデバッグ実行できます！**