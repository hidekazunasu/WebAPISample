using Microsoft.EntityFrameworkCore;
using Sample.Models;

// WebAPIアプリケーションのビルダーを作成
var builder = WebApplication.CreateBuilder(args);

// エンドポイントのAPIエクスプローラーを追加
builder.Services.AddEndpointsApiExplorer();

// Swaggerを使用してAPIドキュメントを生成するための設定を追加
builder.Services.AddSwaggerGen();

// コントローラーを追加
builder.Services.AddControllers();

// SampleDbCotextをDI（依存性注入）に登録
builder.Services.AddDbContext<SampleDbCotext>(options =>
{
    // コネクション文字列を取得
    var path = builder.Configuration.GetConnectionString("MyDbConnection");

    // SQLiteを使用するためのオプションを設定
    DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlite(path);

    // SampleDbCotextのConfigPathプロパティにコネクション文字列を設定
    SampleDbCotext.ConfigPath = path;
});

// アプリケーションをビルド
var app = builder.Build();

// 開発環境の場合、Swaggerを有効にしてAPIドキュメントを表示
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ルーティングを有効化
app.UseRouting();

// エンドポイントを有効化
app.UseEndpoints(x => x.MapControllers());

// HTTPSリダイレクトを有効化
app.UseHttpsRedirection();

// アプリケーションを実行
app.Run();
