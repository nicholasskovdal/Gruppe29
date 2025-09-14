namespace Dive_Deep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews(); //ikke default
            var app = builder.Build();

            app.UseRouting(); //ikke default

            app.MapControllerRoute( //ikke default
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}"
                );

            app.UseStaticFiles(); //ikke default

            app.Run();
        }
    }
}
