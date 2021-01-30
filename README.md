# DDD実装サンプル 
ASP .NET Core Web API での DDD 実装サンプルです。 以下の書籍に影響を受け、自分の理解をコードにしたものです。  
メディエーターパターンを使用した CQRS の実装も行っています。

## 使用フレームワーク・ライブラリ
- .NET Core 3.1.401 
- MediatR

## プロジェクト
|プロジェクト名|詳細|
|---|---|
|WebApi|コントローラーの実装を行っています。|
|Application|ユースケースの実装を行っています。|
|Domain|ドメインエンティティ、値オブジェクトの実装を行っています。|
|InMemoryInfrastructure|データの保存、取得処理などの実装を行っています。|


## 参考文献
- [ドメイン駆動設計入門 ボトムアップでわかる！ドメイン駆動設計の基本](https://www.shoeisha.co.jp/book/detail/9784798150727)
