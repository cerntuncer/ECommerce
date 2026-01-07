using PresentationLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// 1. MVC Servislerini Ekle
// ============================================================
builder.Services.AddControllersWithViews();

// ============================================================
// 2. HttpClient ve ApiService Kaydý (API PORTU: 7045)
// ============================================================
builder.Services.AddHttpClient<ApiService>(client =>
{
    // API projemiz 7045 portunda çalýþtýðý için burayý eþitledik
    client.BaseAddress = new Uri("https://localhost:7045/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

var app = builder.Build();

// ============================================================
// 3. Middleware (Ara Katman) Yapýlandýrmasý
// ============================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // CSS ve JS dosyalarý için

app.UseRouting();

app.UseAuthorization();

// ============================================================
// 4. Route (Yönlendirme) Tanýmý - Varsayýlan: Product/Index
// ============================================================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();