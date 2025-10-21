using Microsoft.EntityFrameworkCore; // AddDbContext metodunu ve UseSqlServer metodunu tanýmak için!
using ECommerce.DatabaseAccessLayer.Contexts; // MyContext sýnýfýnýza eriþmek için!

namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // ----------------------------------------------------
            // EF CORE DB CONTEXT KAYDI (Dependency Injection)
            // ----------------------------------------------------

            // 1. appsettings.json dosyasýndan "DefaultConnection" adlý baðlantý dizisini al
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // 2. MyContext'i servis konteynerine kaydet
            builder.Services.AddDbContext<MyContext>(options =>
                // MS SQL Server'ý ve baðlantý dizisini kullanacaðýmýzý belirtiyoruz
                options.UseSqlServer(connectionString)
            );

            // ----------------------------------------------------

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}