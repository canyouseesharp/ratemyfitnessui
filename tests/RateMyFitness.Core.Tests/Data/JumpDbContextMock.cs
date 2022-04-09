using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RateMyFitness.Core.Models;
using RateMyFitness.Core.Tests.Fixtures.Models;

namespace RateMyFitness.Core.Tests.Data
{
    /// <summary>
    /// Provide an in memory DbContext for testing with seed data.
    /// </summary>
    public class JumpDbContextMock : DbContext
    {
        public DbSet<Jump> Jumps { get; set; } = default!;
        public DbSet<JumpStandard> JumpStandards { get; set; } = default!;

        public JumpDbContextMock(DbContextOptions<JumpDbContextMock> options) : base(options) { }

        /// <summary>
        /// Seed data into DB from fixture data.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenderType>()
                .HasData(SeedGenderData());
            modelBuilder.Entity<Rating>()
                .HasData(SeedRatingData());
            modelBuilder.Entity<JumpStandard>()
                .HasData(SeedJumpStandardData());
        }

        /// <summary>
        /// Return a list of seed data fixture objects.
        /// </summary>
        /// <typeparam name="TSeedFixture">Type of seed data.</typeparam>
        /// <param name="seedFile">The seed file location.</param>
        /// <returns></returns>
        protected IEnumerable<TSeedFixture> GetSeedDataAsList<TSeedFixture>(string seedFile)
        {
            using StreamReader r = new(seedFile);
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<TSeedFixture>>(json);
        }

        /// <summary>
        /// Seed the data from the gender json file. We need to return this as an anonymous list as a workaround for
        /// EF Core's limitation with loading relationships with .HasData
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> SeedGenderData()
        {
            var data = GetSeedDataAsList<GenderTypeFixture>(@"Fixtures/GenderSeedData.json");
            return data.Select(g =>
            {
                return new
                {
                    Id = g.Id,
                    Label = g.Label
                };
            }
            );
        }

        /// <summary>
        /// Seed the rating json data. We need to return this as an anonymous list as a workaround for
        /// EF Core's limitation with loading relationships with .HasData
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> SeedRatingData()
        {
            var data = GetSeedDataAsList<RatingFixture>(@"Fixtures/RatingSeedData.json");
            return data.Select(r =>
            {
                return new
                {
                    Id = r.Id,
                    Description = r.Description
                };
            }
            );
        }

        /// <summary>
        /// Seed jump standards. We need to return this as an anonymous list as a workaround for
        /// EF Core's limitation with loading relationships with .HasData
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> SeedJumpStandardData()
        {
            var data = GetSeedDataAsList<JumpStandardFixture>(@"Fixtures/JumpStandardSeedData.json");
            return data.Select(js =>
            {
                return new
                {
                    Id = js.Id,
                    AgeMin = js.AgeMin,
                    AgeMax = js.AgeMax,
                    GenderId = js.GenderId,
                    MeasurementMin = js.MeasurementMin,
                    MeasurementMax = js.MeasurementMax,
                    RatingId = js.RatingId
                };
            }
            );
        }
    }

    /// <summary>
    /// Factory for generating DbContext instances for tests
    /// </summary>
    public class JumpDbContextMockFactory : IDisposable
    {
        private SqliteConnection? Connection;

        /// <summary>
        /// Basic wrapper around getting the DbContext optiobns.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private DbContextOptions<JumpDbContextMock> CreateOptions()
        {
            if (Connection is null)
            {
                throw new InvalidOperationException("Connection not established");
            }
            return new DbContextOptionsBuilder<JumpDbContextMock>()
                .UseSqlite(Connection).Options;
        }

        /// <summary>
        /// Create an instance.
        /// TODO: Possibly move out the connection string to appsettings.
        /// </summary>
        /// <returns></returns>
        public JumpDbContextMock CreateContext()
        {
            if (Connection == null)
            {
                Connection = new SqliteConnection("DataSource=:memory:");
                Connection.Open();

                var options = CreateOptions();
                using var context = new JumpDbContextMock(options);
                context.Database.EnsureCreated();
            }

            return new JumpDbContextMock(CreateOptions());
        }

        /// <summary>
        /// Ensure correct disposal.
        /// </summary>
        public void Dispose() => GC.SuppressFinalize(this);
    }
}

