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

            builder.Services.AddDbContext<DiveDeepContext>(options =>   //ikke default
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DiveDeepConnection"));
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) //ikke default
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DiveDeepContext>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>(); //ikke default
            builder.Services.AddScoped<IBookingRepository, BookingRepository>(); //ikke default
            builder.Services.AddScoped<BookingService>();


            builder.Services.AddControllersWithViews(); //ikke default
            var app = builder.Build();

            app.UseHttpsRedirection(); //ikke default
            app.UseStaticFiles(); //ikke default

            app.UseRouting(); //ikke default

            app.UseAuthentication(); //ikke default
            app.UseAuthorization(); //ikke default

            app.MapControllerRoute( //ikke default
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}"
                );


            app.MapRazorPages(); //ikke default
            app.Run();
        }
    }
}
