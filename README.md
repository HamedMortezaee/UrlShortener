# URL Shortener

یک سرویس کوتاه‌کننده لینک مبتنی بر ASP.NET Core که امکان ساخت لینک کوتاه، بازیابی لینک اصلی و مشاهده تاریخچه دسترسی‌ها را فراهم می‌کند.

## فناوری‌ها

- .NET 5 و ASP.NET Core Web API
- Entity Framework Core و SQL Server
- MediatR
- Swagger

## اجرا

ابتدا رشته اتصال `UrlShortenerApiDB` را در فایل `UrlShortener.Api/appsettings.json` تنظیم کنید، سپس دستورات زیر را اجرا کنید:

```bash
dotnet restore
dotnet ef database update --project UrlShortener.DataAccess.EFCore --startup-project UrlShortener.Api
dotnet run --project UrlShortener.Api
```

پس از اجرا، برنامه به‌صورت پیش‌فرض روی `http://localhost:5000` در دسترس است.
