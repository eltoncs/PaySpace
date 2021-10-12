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

namespace PaySpace.Api
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
            services.AddControllers();

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

            dataContext.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InjectBusinessDependecies(IServiceCollection services)
        {
            services.AddScoped<IRepository<Calc>, CalcRepository>();
            services.AddScoped<Repository<Calc, PaySpaceDbContext>, CalcRepository>();
            services.AddScoped<Repository<CalcMethod, PaySpaceDbContext>, CalcMethodRepository>();
            services.AddScoped<ICalcMethodRepository, CalcMethodRepository>();
            services.AddScoped<IProgressiveTableRepository, ProgressiveTableRepository>();
            services.AddScoped<Repository<ProgressiveTable, PaySpaceDbContext>, ProgressiveTableRepository>();

            services.AddScoped<IFlatRateStrategy, FlatRateStrategy>();
            services.AddScoped<IFlatValueStrategy, FlatValueStrategy>();
            services.AddScoped<IProgressiveStrategy, ProgressiveStrategy>();
        }
    }
}
