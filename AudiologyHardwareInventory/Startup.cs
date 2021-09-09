using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudiologyHardwareInventory.BusinessLayer;
using AudiologyHardwareInventory.DataAccessLayer;
using AudiologyHardwareInventory.Interface;
using AudiologyHardwareInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace AudiologyHardwareInventory
{
    public static class MyAppData
    {
        public static IServiceCollection data;
    }
    public class Startup
    {
        //public IServiceCollection contextUnitTest = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // string DevConnection= "Server=MD2VGA1C\\LOCAL_MS_SQL;Database=HardWareInventory;Trusted_Connection=True;MultipleActiveResultSets=True;"
            services.AddDbContext<HardwareInventoryContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            //services.AddDbContext<HardwareInventoryContext>(options =>
            //    options.UseSqlServer(DevConnection));


            services.AddTransient<IRepository<Team>, GenericRepository<Team>>();
            services.AddScoped<ITeam, TeamOperations>();
            MyAppData.data=services.AddTransient<TeamOperations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

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
