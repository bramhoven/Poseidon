using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poseidon.Helpers.Settings;
using Poseidon.DataLayer.Contexts.ServerContext;
using Poseidon.DataLayer.Contexts.UserContext;
using Poseidon.DataLayer.Servers;
using Poseidon.DataLayer.Users;

namespace Poseidon.API
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbUserContext userContext, DbServerContext serverContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // Setup databases
            userContext.Database.EnsureCreated();
            userContext.Database.Migrate();
            serverContext.Database.EnsureCreated();
            serverContext.Database.Migrate();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabases(services);

            services.AddScoped<IServerDal, ServerDal>();
            services.AddScoped<IUserDal, UserDal>();

            services.AddControllers();
        }

        // This methods gets called by the ConfigureServices function. Use this to setup EntityFramework.
        private void ConfigureDatabases(IServiceCollection services)
        {
            switch (Configuration.GetValue("DatabaseTypes:UserDatabase", "mysql"))
            {
                case "postgres":
                {
                    services.AddDbContext<DbUserContext, PostgresUserContext>(options =>
                        options.UseNpgsql(Configuration.GetConnectionString("UserDatabase"),
                            b => b.MigrationsAssembly("Poseidon.Migrations.Postgres")));
                    break;
                }
                case "mysql":
                {
                    services.AddDbContext<DbUserContext, MysqlUserContext>(options =>
                        options.UseMySql(Configuration.GetConnectionString("UserDatabase"),
                            b => b.MigrationsAssembly("Poseidon.Migrations.Mysql")));
                    break;
                }
            }

            switch (Configuration.GetValue<string>("DatabaseTypes:ServerDatabase", "mysql"))
            {
                case "postgres":
                {
                    services.AddDbContext<DbServerContext, PostgresServerContext>(options =>
                        options.UseNpgsql(Configuration.GetConnectionString("ServerDatabase"), b => b.MigrationsAssembly("Poseidon.Migrations.Postgres")));
                    break;
                }
                case "mysql":
                {
                    services.AddDbContext<DbServerContext, MysqlServerContext>(options =>
                        options.UseMySql(Configuration.GetConnectionString("ServerDatabase"), b => b.MigrationsAssembly("Poseidon.Migrations.Mysql")));
                    break;
                }
            }
        }

        #endregion
    }
}