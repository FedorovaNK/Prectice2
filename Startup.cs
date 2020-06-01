using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TorgObject.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using TorgObject.ApplicationServices.GetPechatProductListUseCase;
using TorgObject.ApplicationServices.Ports.Gateways.Database;
using TorgObject.ApplicationServices.Repositories;
using TorgObject.DomainObjects.Ports;

namespace TorgObject.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TorgContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "TorgObject.db")}")
            );

            services.AddScoped<ITorgDatabaseGateway, TorgEFSqliteGateway>();

            services.AddScoped<DbPechatProductRepository>();
            services.AddScoped<IReadOnlyPechatProductRepository>(x => x.GetRequiredService<DbPechatProductRepository>());
            services.AddScoped<IPechatProductRepository>(x => x.GetRequiredService<DbPechatProductRepository>());

            services.AddScoped<IGetPechatProductListUseCase, GetPechatProductListUseCase>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
