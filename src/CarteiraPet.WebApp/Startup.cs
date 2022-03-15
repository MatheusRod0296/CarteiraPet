using CarteiraPet.Infra;
using CarteiraPet.Infra.Domain.Data;
using CarteiraPet.Infra.Identity.Data;
using CarteiraPet.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarteiraPet.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("carteirapetIdentity")));
            
            services.AddDbContext<CarteiraPetContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("carteirapet")));
           
           services.AddDefaultIdentity<ApplicationUser>(options =>
               {
                   options.SignIn.RequireConfirmedAccount = false;
                   options.Password.RequireDigit = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequiredUniqueChars = 0;
               })
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
           services.RegisterServices();
           
           services.AddHttpContextAccessor();
           
           services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dataContext, CarteiraPetContext carteiraPetContext)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "Test")
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            dataContext.Database.Migrate();
            carteiraPetContext.Database.Migrate();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
