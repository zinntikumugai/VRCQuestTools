# VRCQuestTools

主に Oculus Quest 対応を想定した VRChat 向け Unity Editor 拡張です。

## 内容

### Convert Avatar for Quest

選択したアバターに以下の操作を自動的に行い、Quest 用にアップロードできるように変換します (大抵は Very Poor)。

- アバターとマテリアルの複製
- シェーダーを VRChat/Mobile/Toon Lit に変更
- 元々のマテリアルの Color, Emission を反映したテクスチャの生成
- DynamicBone や Cloth などの使用不可コンポーネントの削除

コピーを作成することで元のアバターに変更を加えないため、既存のプロジェクトでそのまま使用することができます。

### Remove Missing Components

オブジェクトから "Missing" 状態のコンポーネントを削除します。
DynamicBone を導入していないプロジェクトでアバターをアップロードできないときに使用します。

### Tools/Remove Unsupported Components

DynamicBone や Cloth など、Quest 用アバターで使用できないコンポーネントを削除します。

### Tools/BlendShapes Copy

SkinnedMeshRenderer に設定されたブレンドシェイプ(シェイプキー)の値を別の SkinnedMeshRenderer にコピーします。
PC 用と Quest 用で別々のモデルを使用する場合などに、設定済みシェイプキーを移す際に使用します。

### Auto Remove Vertex Colors

シーン内のアバターのメッシュから頂点カラーを自動的に取り除き、一部アバターで VRChat/Mobile 系シェーダーを使用する際に真っ黒になるなどテクスチャの色が正しく表示されない問題を対策します。

### Unity Settings for Quest

Quest 対応に有用な Unity の設定を有効化します。

## 使用方法

unitypackage を導入後、ヒエラルキーでアバターを選択した状態でメニューから「VRCQuestTools」を選択すると各機能を使用できます。
一部機能は自動的に有効になっています。

## 動作確認環境

- Windows 10 64-bit
- macOS Big Sur (Intel CPU)
- Ubuntu 20.04 LTS
- Unity 2018.4.20f1
- VRCSDK2 / VRCSDK3

## 利用規約

本ツールは MIT ライセンスで提供されます。

```
MIT License

Copyright (c) 2020 kurotu

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

## 連絡先

Twitter: https://twitter.com/kurotu

## 更新履歴

- 2021/2/6: v0.3.0
    - 更新確認機能を追加
    - macOS, Linux で「Quest用のテクスチャを生成する」機能が動作するように変更
    - アバターの変換完了時にダイアログで通知するように変更
    - 変換済みアバターのデフォルトの保存先を Assets/KRT/QuestAvatars に変更
    - 生成したマテリアルとテクスチャをそれぞれ Materials, Textures フォルダに保存するように変更
    - 「Remove Missing Components」で Unpack Prefab が不要な場合には実行しないように変更
    - メニューの表示順を調整
- 2021/1/24: v0.2.1
    - プロジェクトを開いたときに「Auto Remove Vertex Colors」のチェックが反映されない問題を修正
- 2020/11/29: v0.2.0
    - 「Remove Missing Components」「Remove Unsupported Components」を追加
    - オブジェクトの右クリックメニューに VRCQuestTools を追加
    - Quest 用テクスチャを生成する際にテクスチャサイズを制限する機能を追加
    - メニューの実装を整理
- 2020/11/09: v0.1.2
    - Missing になっている DynamicBone を含むアバターを変換すると Unity がクラッシュする問題を修正
- 2020/10/28: v0.1.1
    - RenderTexture を使用するマテリアルがあると変換が停止する問題を修正
    - メッセージの内容を一部変更
- 2020/10/10: v0.1.0
    - 公開
