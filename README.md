# MornArbor

## 概要

Arborステートマシンフレームワークの拡張ライブラリ。ゲームフローの管理とシーン遷移を統制する。

## 依存関係

| 種別 | 名前 |
|------|------|
| 外部パッケージ | Arbor 3.x |
| Mornライブラリ | MornSaveKey, MornSound, MornTween, MornUGUI, MornUtil |

## 使い方

### カスタムステートの作成

`SubBase` クラスを継承してカスタム状態を作成します。

```csharp
public class MyCustomState : SubBase
{
    protected override void OnAwake()
    {
        // 初期化処理
    }

    protected override void OnStart()
    {
        // 開始時処理
    }
}
```

### ExitCodeによる状態遷移

```csharp
// ステートからの遷移
TransitionByExitCode(ExitCode.Success);
```

### ログ出力

```csharp
MornArborUtil.Log("ステートマシンのログ");
```
