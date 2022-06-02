using GodelTourAgensy.BLL.Extensions;
using GodelTourAgensy.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GodelTourAgensy.BLL.Services;

namespace GodelTourAgensy
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            string usersConnectiion = Configuration.GetConnectionString("IdentityConnection");
            services.AddDbContext<GodelTourAgensyContext>(x => x.UseSqlServer(connection));
            services.AddDbContext<IdentityContext>(x => x.UseSqlServer(usersConnectiion));
            services.AddIdentity<IdentityUser, IdentityRole>(x => x.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<IdentityContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(AdditionalsService));
            services.AddServices();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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
            });
        }
    }
}