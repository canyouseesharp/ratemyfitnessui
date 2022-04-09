using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RateMyFitness.Core.Data
{
    /// <summary>
    /// Helper to create a DbContext instance depending on environment and which assembly to place them in.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class DesignTimeDbContextFactory<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        protected string ConnectionStringName { get; }
        protected string MigrationsAssemblyName { get; }

        /// <summary>
        /// Init with required dependencies.
        /// </summary>
        /// <param name="connectionStringName">Connection string name, assuming located within appsettings.</param>
        /// <param name="migrationsAssemblyName">Which assembly to place the migrations in.</param>
        public DesignTimeDbContextFactory(string connectionStringName, string migrationsAssemblyName)
        {
            ConnectionStringName = connectionStringName;
            MigrationsAssemblyName = migrationsAssemblyName;
        }

        /// <summary>
        /// Create a DbContext with the arguments passed.
        /// </summary>
        /// <param name="args">DbContext specific arguments.</param>
        /// <returns></returns>
        public TContext CreateDbContext(string[] args)
        {
            return Create(
                Directory.GetCurrentDirectory(),
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "PRODUCTION",
                ConnectionStringName,
                MigrationsAssemblyName);
        }

        /// <summary>
        /// To be overridden - create 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        /// <summary>
        /// Create a DbContext using a connection string name, assumed located within appsettings.
        /// Example = "default" etc.
        /// Proxy method without passing environment name.
        /// </summary>
        /// <param name="connectionStringName">Connection string name.</param>
        /// <param name="migrationsAssemblyName">Which assembly to place the migrations in.</param>
        /// <returns></returns>
        public TContext CreateWithConnectionStringName(string connectionStringName, string migrationsAssemblyName)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "PRODUCTION";

            var basePath = AppContext.BaseDirectory;

            return Create(basePath, environmentName, connectionStringName, migrationsAssemblyName);
        }

        /// <summary>
        /// Main creator of a DbContext using all required arguments.
        /// </summary>
        /// <param name="basePath">Base path of appsettings file.</param>
        /// <param name="environmentName">Environment name to use.</param>
        /// <param name="connectionStringName">Connection string name.</param>
        /// <param name="migrationsAssemblyName">Which assembly to place the migrations in.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private TContext Create(string basePath, string environmentName, string connectionStringName, string migrationsAssemblyName)
        {
            /// Load the environment specific appsettings.
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString(connectionStringName);
            Console.WriteLine($"Environment: {environmentName ?? "PRODUCTION"}");

            if (string.IsNullOrWhiteSpace(connstr))
            {
                throw new InvalidOperationException($"Could not find a connection string named '{connectionStringName}'.");
            }
            else
            {
                return CreateWithConnectionString(connectionStringName, connstr, migrationsAssemblyName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringName">Connection string name.</param>
        /// <param name="connectionString">Actual connection string.</param>
        /// <param name="migrationsAssembly">Which assembly to place the migrations in.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private TContext CreateWithConnectionString(string connectionStringName, string connectionString, string migrationsAssembly)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
             $"{nameof(connectionString)} is null or empty.",
             nameof(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            Console.WriteLine(
                "DesignTimeDbContextFactory.Create(string): Connection string: {0}",
                connectionStringName);

            optionsBuilder.UseSqlite(connectionString, db => db.MigrationsAssembly(migrationsAssembly));

            DbContextOptions<TContext> options = optionsBuilder.Options;

            return CreateNewInstance(options);
        }
    }
}

