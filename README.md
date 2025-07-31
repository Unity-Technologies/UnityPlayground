# Unity Playground

![playground.png](https://imgur.com/NvAFtsp.jpg)

このプロジェクトは、Unity Asset Store で配布している [Playground](https://assetstore.unity.com/packages/templates/tutorials/unity-learn-playground-urp-109917) を更新・バグ修正・日本語対応したものです。

## 説明

このプロジェクトは、初心者が Unity ですぐにゲームを作れるようにするためのプロジェクトです。初心者向けのワークショップを開くために作られています。このプロジェクトには物理エンジンを使った 2D ゲームを作るためのシンプルなコンポーネント（スクリプト コンポーネント）が含まれています。

## ドキュメント

### このプロジェクトの目的

このプロジェクトは 2D の物理エンジンを使ったゲームを可能な限り柔軟に作れることを目指して作られています。プロジェクトにはそれぞれ一つの最小限の事だけができるコンポーネントが多数含まれています。それらを組み合わせて、さまざまなゲームを作れるようになっています。

このプロジェクトを使うには Unity Editor の使い方や、GameObject やコンポーネントの仕組み、シーンビュー、ゲームビューなどをある程度は知っておく必要があります。それらは以下の「使い方」からリンクされている「Unity Playground を始める」で可能な限り説明しています。

### 使い方

- [Playground のセットアップ（動画）](https://www.youtube.com/watch?v=THIkRRrueHw&t=73s)
- [Unity Playground を始める](https://bboydaisuke.cloudfree.jp/2021/04/25/playground/)
- [Playground リファレンス ガイド 1](https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-1/)
- [Playground リファレンス ガイド 2](https://bboydaisuke.cloudfree.jp/2021/04/26/playground-reference-guide-2/)
- [Playground でいろいろ作ってみよう](https://bboydaisuke.cloudfree.jp/2022/05/04/make-game-with-playground/)

### ソフトウェア要件

Unity 2022.3 以降

### ハードウェア要件

ノート PC 程度

### 変更履歴

- **1.6.1**
  - プロジェクト設定により余計な Collider Bounds が見えているのを見えないようにした
  - v1.5 でフォントを削除したことに伴う、セリフやインベントリの表示不具合を修正した
  - Playground 独自のインスペクタ表示をできないようにした
  - 不要なパッケージをプロジェクトから削除し、Cinemachine パッケージを追加した
  - コメントやメッセージに日本語訳を追加した
  - ソースコードを C# として正しい形に成形した
  - v1.6 で Render Pipeline が URP に変更されていたが、それを Built-in Render Pipeline に戻した
  - いくつかのサンプルゲームを追加した
  - v1.1 でディレクトリ構造が深くなっていたのを、シンプルに戻した

- **1.6**
  - Made compatible with URP
  - [Updated Github branch](https://github.com/Unity-Technologies/UnityPlayground)
  - Fixed dropdown bug in inspector
  - Fixed wording for movement inputs in inspector

- **1.5**
  - Updated to 2022.2
  - Varela Font removed for simplicity.
  - Changed from Gamma to Linear color space due to SRGB textures

- **1.4**
  - Updated to 2021.3
  - Asset includes 3rd party component Varela Font under included OFL 1.1 license.
  
- **1.3**
  - Updated to 2019.4

- **1.1** _(2023/05/24)_ 
    - Upgraded to 2022.2
    - Upgraded to Universal Render Pipeline
    - Removed Varela Font and replaced by Built-in font
    - Changed folders structure to match Asset Store requirements
- **1.0** _(2018/12/12)_ 
    - initial release on the Asset Store.
