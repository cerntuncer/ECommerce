using BusinessLogicLayer.DesignPatterns.GenericRepositories.ConcreteRepositories;
using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.CategoryHandler.DTOs;
using BusinessLogicLayer.Services.Analysis;
using BusinessLogicLayer.Services.Auth;
using ECommerce.DatabaseAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// 1. CONTROLLERS & JSON AYARLARI
// ============================================================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Sonsuz döngüleri engeller (Örn: Product -> Category -> Product)
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        // C# isimlerini (PascalCase) JSON içinde aynen korur. 
        // Presentation katmanýndaki DTO'larýn veriyi okuyabilmesi için bu satýr hayati önem taþýr.
        options.JsonSerializerOptions.PropertyNamingPolicy = null;

        // Enum deðerlerini (Status vb.) sayý yerine metin olarak döndürür
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// ============================================================
// 2. SWAGGER (API Test Arayüzü)
// ============================================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ============================================================
// 3. DATABASE CONTEXT
// ============================================================
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        // Migration dosyalarýnýn bu projede (ApiLayer) toplanmasýný saðlar
        b => b.MigrationsAssembly("ApiLayer"))
);

// ============================================================
// 4. DEPENDENCY INJECTION (Baðýmlýlýk Kayýtlarý)
// ============================================================
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFlagRepository, FlagRepository>();
builder.Services.AddScoped<IAnalysisService, AnalysisService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// ============================================================
// 5. MEDIATR (Ýþ Mantýðý Tetikleyici)
// ============================================================
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllCategoryHandleRequest).Assembly)
);

// ============================================================
// 6. CORS (Farklý Portlardan Eriþime Ýzin Ver)
// ============================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// ============================================================
// 7. MIDDLEWARE (Ara Katmanlar - Sýralama Önemlidir)
// ============================================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Tarayýcýda /swagger adresini aktif eder
}

app.UseStaticFiles(); // Resimler vb. statik dosyalar için
app.UseHttpsRedirection();

app.UseRouting(); // Ýsteklerin doðru Controller'a yönlendirilmesini saðlar

// CORS her zaman Routing'den sonra, Authorization'dan önce gelmelidir
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers(); // API uç noktalarýný (endpoints) haritalar

app.Run();