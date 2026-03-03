# Highway Urge Runner 🚗💨🚻

> 高速道路を走行中、限界を迎える前にSA/PAにたどり着け！
> シンプルな操作で緊張感あふれるハイパーカジュアルゲーム

[![Unity](https://img.shields.io/badge/Unity-6-black?logo=unity)](https://unity.com/)
[![C#](https://img.shields.io/badge/C%23-.NET%20Standard%202.1-blue?logo=csharp)](https://docs.microsoft.com/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-WebGL-green)](https://docs.unity3d.com/Manual/webgl-building.html)

## 🎮 ゲーム概要

高速道路を走行中、尿意が限界に達する前にSA（サービスエリア）/PA（パーキングエリア）にたどり着くカジュアルドッジゲーム。
左右の車線変更だけで遊べるシンプルな操作でありながら、尿意メーターと交通状況の緊張感がプレイヤーを引きつけます。

- **ジャンル**: ハイパーカジュアル / ドッジゲーム
- **プラットフォーム**: WebGL（ブラウザ）
- **想定プレイ時間**: 30秒〜2分/ステージ

## 🎯 コアメカニクス

### プレイヤー操作
- 左右の車線変更のみのシンプル操作
- タップ操作（モバイル）/ 矢印キー（PC）対応

### ゲームシステム
- **尿意メーター**: 時間経過で上昇、100%到達でゲームオーバー
- **車線速度差**: 左車線（安全・遅い）/ 中央車線（バランス）/ 右車線（速い・危険）
- **SA/PA**: 複数配置、任意のSAに入ればクリア

### アイテム
- 🍬 **ボンタン飴**: 尿意-10%（救済アイテム）
- 🥤 **ドリンク**: 尿意+12%（トラップ）
- 💥 **でこぼこゾーン**: 尿意+4% + 画面揺れ

## 🛠️ 技術スタック

| カテゴリ | 技術 |
|---------|------|
| **Engine** | Unity 6 |
| **Language** | C# (.NET Standard 2.1) |
| **UI** | UI Toolkit (UXML + USS) |
| **Build Target** | WebGL |
| **Architecture** | Singleton + ScriptableObject |

### 主要技術要素
- ✅ **UI Toolkit**: 最新のUI Toolkitを採用（UGUI不使用）
- ✅ **ScriptableObject**: ステージデータ・スポーン設定の管理
- ✅ **オブジェクトプール**: 効率的なオブジェクト管理
- ✅ **ルールベースAI**: スポーンディレクターによる動的な交通生成
- ✅ **WebGL最適化**: ブラウザでの快適な動作を重視

## 📁 プロジェクト構成

```
Assets/
├── Scripts/
│   ├── Core/           # GameManager, GameState
│   ├── Player/         # PlayerController
│   ├── Spawning/       # SpawnDirector, SpawnProfile(SO)
│   ├── Urge/           # UrgeSystem
│   ├── Obstacles/      # ObstacleVehicle, ItemPickup
│   ├── Stage/          # StageData(SO), SAZone
│   └── UI/             # NavUIController, 各画面のUI制御
├── Data/               # ScriptableObject アセット
├── UI/                 # UXML + USS
├── Prefabs/            # プレハブ
├── Art/                # スプライト・マテリアル
└── Scenes/
    └── Main.unity      # シングルシーン構成
```

## 🎨 設計思想

### アーキテクチャ
- **責務の明確化**: 各クラスは単一の責務を持つ（Single Responsibility Principle）
- **データ駆動設計**: ScriptableObjectでゲームバランスを調整可能
- **疎結合**: イベント駆動で各システムを独立させる

### コーディング規約
- 名前空間: `HighwayUrge.*`
- 命名: PascalCase（クラス/メソッド）、camelCase（フィールド/変数）
- XMLドキュメントコメント必須
- マジックナンバー禁止（const or SerializeField）

## 📊 開発状況

🚧 **開発中**（2026年2月〜）

### 開発フェーズ
- [x] 企画・設計
- [ ] プロトタイプ実装
- [ ] コアゲームループ実装
- [ ] UI/UX実装
- [ ] バランス調整
- [ ] WebGLビルド最適化
- [ ] 公開

## 🎯 開発目標

### 技術目標
- ✅ クリーンなコード設計
- ✅ 保守性の高いアーキテクチャ
- ✅ UI Toolkitの実践的な活用
- ✅ WebGLでの快適な動作（60fps維持）

### ゲーム目標
- シンプルで中毒性のあるゲームプレイ
- 初見プレイヤーでも直感的に遊べる操作性
- リプレイ性の高いステージ設計

## 📝 ライセンス

個人プロジェクト

## 👤 作成者

**Maruyama Daisuke**
- GitHub: [@daiMaruyama](https://github.com/daiMaruyama)
- Portfolio: [https://daimaruyama.github.io/](https://daimaruyama.github.io/)

---

**作成日**: 2026年2月
**開発環境**: Unity 6 / C# / UI Toolkit / WebGL
