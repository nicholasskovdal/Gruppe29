using Dive_Deep.Data;
using Dive_Deep.Models;
using Dive_Deep.Persistence;
using Dive_Deep.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dive_Deep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //INFO OM DBCONTEXT
            //DbContext er hjertet i Entity Framework core --> DbContext er forbindelsen mellem c#kode og database
            //Dette er en lambda, som bruges til at konfigurere DbContext’en.

            builder.Services.AddDbContext<DiveDeepContext>(options =>   //ikke default
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DiveDeepConnection"));
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) //ikke default
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DiveDeepContext>();

            //INFO OM SERVICES OG SCOPED
            //Server inject
            //.Services er en collection af services
            //Builder er en WebApplikationsBuilder der bruges til at konfigurere services
            //Services er dependency injection-containeren. ASP.NET Core bruger denne container til automatisk at oprette objekter og injicere dem, fx i controllers eller services.
            //AddScoped fortæller objektets levetid. Scoped er én instans pr http request. AddScoped betyder Én ny instans på request. (AddSingleton = Én instans i hele applikationen)
            //Her sker koblingen mellem interface og implementering. f.eks. (IProductRepo og ProductRepo) --> Når noget beder om IProductRepository, så giv dem en ProductRepository
            //Low coupling --> Klasser kender så lidt som muligt til hinandens konkrete implementeringer. Derfor vi bruger Private Readonly i controlleren

            //SOLID. D = Dependency Inversion Principle --> High-level moduler må ikke afhænge af low-level moduler Begge skal afhænge af abstraktioner
            //Controller = High-level
            //Repositpory = Low-level
            //Interface = Abstraktion
            builder.Services.AddScoped<IProductRepository, ProductRepository>(); //ikke default
            builder.Services.AddScoped<IBookingRepository, BookingRepository>(); //ikke default
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<ProductSelectionService>();

            //Dependency injection
            builder.Services.AddControllersWithViews(); //.AddContollersWithViews er en APS.net core extentionmethod. Den hjælper med at injecte alle services påvirket af .MapControllerRoute ind i .Services collection
            var app = builder.Build();

            app.UseHttpsRedirection(); //ikke default
            app.UseStaticFiles(); //ikke default

            app.UseRouting(); //ikke default

            app.UseAuthentication(); //ikke default
            app.UseAuthorization(); //ikke default

            app.MapControllerRoute( //Med denne metode så er vi nødt til at dependensy injecte vores andre metoder. Og denne metode kræver mange services.
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}"
                );


            app.MapRazorPages(); //ikke default
            app.Run();
        }
    }
}
