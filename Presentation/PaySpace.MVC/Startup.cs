using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpace.Infra.Data;
using PaySpace.Infra.Data.Repository;
using PaySpaceApplication.Method.Strategies;

namespace PaySpace.MVC
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
            services.AddControllersWithViews();

            services.AddDbContext<PaySpaceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            this.InjectBusinessDependecies(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PaySpaceDbContext dataContext)
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

            dataContext.Database.Migrate();

            app.UseHttpsRedirection();
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

        private void InjectBusinessDependecies(IServiceCollection services)
        {
            services.AddScoped<IRepository<Calc>, CalcRepository>();
            services.AddScoped<Repository<CalcMethod, PaySpaceDbContext>, CalcMethodRepository>();
            services.AddScoped<ICalcMethodRepository, CalcMethodRepository>();
            services.AddScoped<IProgressiveTableRepository, ProgressiveTableRepository>();
            services.AddScoped<Repository<ProgressiveTable, PaySpaceDbContext>, ProgressiveTableRepository>();

            services.AddSingleton<IFlatRateStrategy, FlatRateStrategy>();
            services.AddSingleton<IFlatValueStrategy, FlatValueStrategy>();
            services.AddSingleton<IProgressiveStrategy, ProgressiveStrategy>();
        }
    }
}
