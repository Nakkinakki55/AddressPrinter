# ハガキ印刷デスクトップアプリ

このアプリはC#とVisual Studioを使用して開発された、住所や宛名を簡単に印字できるデスクトップアプリです。郵便番号を入力すると、住所を自動的に入力してくれる機能を搭載しており、非常にシンプルかつ使いやすい設計となっています。

## 特徴
- **郵便番号検索**: `zipcloud` APIを利用し、郵便番号から住所を自動入力
- **ハガキ印字**: 入力された住所・宛名・所属先を簡単にハガキに印刷
- **使いやすいGUI**: シンプルで直感的な操作画面

## 使用技術
- **プログラミング言語**: C#
- **IDE**: Visual Studio 2022
- **API**: `zipcloud`（郵便番号検索API）

## アプリの実行場所
アプリの実行ファイルは以下にあります
```txt
\AddressPrinter\AddressPrinterPart2\AddressPrinter\bin\Debug\AddressPrinter.exe
```

## インストール方法
1. このリポジトリをクローンします。
```txt
git clone https://github.com/Nakkinakki55/AddressPrinter.git
cd AddressPrinter
```

## 使用方法
1. アプリを起動し、郵便番号と宛名、所属先を入力。

2. [住所検索] ボタンをクリックし、自動入力を確認。

3. [印刷] ボタンを押してハガキに印刷します。

## 画面スクリーンショット
![image](https://github.com/user-attachments/assets/ea112fc6-530c-48bc-b78a-48627b856ea7)

![image](https://github.com/user-attachments/assets/ec105275-a080-4d04-9f69-94627188f299)






