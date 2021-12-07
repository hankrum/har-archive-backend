using Har.Archive.Backend.Api.Mappers;
using Har.Archive.Backend.Data;
using Har.Archive.Backend.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Har.Archive.Backend.Api
{
    public class Startup
    {
        private static readonly string ApplicationName = typeof(Program).Assembly.GetName().Name;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            this.RegisterData(services);
            this.RegisterServices(services);
        }

        private void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<MsSqlDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HarFilesContext"),
                b => b.MigrationsAssembly("Har.Archive.Backend.Api")));

            services.BuildServiceProvider().GetService<MsSqlDbContext>().Database.Migrate();

            services.AddScoped(typeof(IEfRepository<>), typeof(EFRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(HarArchiveMapperProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ApplicationName, Version = "v1" });
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IHarFileService, HarFileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HAR File Archive");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
