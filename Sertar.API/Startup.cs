using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sertar.DataLayer.Contexts.UserContext;
using Sertar.Helpers.Settings;

namespace Sertar.API
{
    public class Startup
    {
        #region Fields

        private SettingsHelper _settingsHelper;

        #endregion

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Constructors

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _settingsHelper = new SettingsHelper(configuration);
        }

        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabases(services);
            services.AddControllers();
        }

        // This methods gets called by the ConfigureServices function. Use this to setup EntityFramework.
        private void ConfigureDatabases(IServiceCollection services)
        {
            switch (Configuration.GetValue("DatabaseTypes:UserDatabase", "mysql"))
            {
                case "postgres":
                {
                    services.AddDbContext<PostgresUserContext>(options =>
                        options.UseNpgsql(Configuration.GetConnectionString("UserDatabase"),
                            b => b.MigrationsAssembly("Sertar.Migrations.Postgres")));
                    break;
                }
                case "mysql":
                {
                    services.AddDbContext<MysqlUserContext>(options =>
                        options.UseMySql(Configuration.GetConnectionString("UserDatabase"),
                            b => b.MigrationsAssembly("Sertar.Migrations.Mysql")));
                    break;
                }
            }
        }

        #endregion
    }
}