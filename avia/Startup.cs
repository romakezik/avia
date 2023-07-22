using DataLayer;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "Avia.Cookie";
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        });

        services.AddSession(options =>
        {
            options.Cookie.Name = "Avia.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(30);
        });

        services.AddControllersWithViews();

        services.AddRazorPages();
        var connection = Configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<EFDBContext>(options => options.UseMySQL(connection, b => b.MigrationsAssembly("DataLayer")));
        services.AddScoped<EFDBContext>();
        services.AddMvc();

    }



    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        Users us = new();
        app.UseSession();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseDeveloperExceptionPage();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "booking",
                pattern: "{controller=Ticket}/{action=Index}/{id?}");
            endpoints.MapControllerRoute(
                name: "search",
                pattern: "{controller=Home}/{action=Search}/{id?}");
            
            endpoints.MapControllerRoute(
                name: "Register",
                pattern: "{controller=Account}/{action=Register}/{id?}",
                 endpoints.MapControllerRoute(
                name: "Register",
                pattern: "{controller=Ticket}/{action=Book}/{ticketid?}",
               
            endpoints.MapControllerRoute(
                name: "ticket",
                 pattern: "{controller=Ticket}/{action=ConfirmOrder}/{ticketid?}"            
                )));
        });
    }

}
