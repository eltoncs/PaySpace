using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaySpace.Api.Extensions;
using PaySpace.Domain.Model;
using PaySpace.Domain.Repository;
using PaySpace.Infra.Data;
using PaySpace.Infra.Data.Repository;
using PaySpaceApplication.Method.Strategies;
using PaySpaceApplication.Models;
using PaySpaceApplication.Services;


namespace PaySpace.Api
{
    public class Startup
    {
        readonly string corsAllowAllOrigins = "AllowAllOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsAllowAllOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddDbContext<PaySpaceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            this.InjectBusinessDependecies(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PaySpaceDbContext dataContext)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaySpace Tax Calculator Api V1");
                }
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();
            dataContext.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(corsAllowAllOrigins);
            //app.UseAuthorization();

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

            services.AddScoped<ICalcMethods, CalcMethods>();
            services.AddScoped<IFlatRateStrategy, FlatRateStrategy>();
            services.AddScoped<IFlatValueStrategy, FlatValueStrategy>();
            services.AddScoped<IProgressiveStrategy, ProgressiveStrategy>();

            services.AddScoped<ICalcServices, CalcServices>();
            
        }
    }
}
