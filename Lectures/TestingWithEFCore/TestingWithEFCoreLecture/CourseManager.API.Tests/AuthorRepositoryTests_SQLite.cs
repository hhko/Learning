using CourseManager.API.DbContexts;
using CourseManager.API.Models;
using CourseManager.API.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace CourseManager.API.Tests
{
    public class AuthorRepositoryTests_SQLite
    {
        private readonly ITestOutputHelper _output;

        public AuthorRepositoryTests_SQLite(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetAuthor_EmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new CourseContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var authorRepository = new AuthorRepository(context);

                // Assert
                Assert.Throws<ArgumentException>(
                    // Act      
                    () => authorRepository.GetAuthor(Guid.Empty));
            }
        }

        [Fact]
        public void GetAuthors_NonForeignKey_ThrowDbUpdateException()
        {
            // Arrange
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new CourseContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                // Foreign Key
                //context.Countries.Add(new Country()
                //{
                //    Id = "BE",
                //    Description = "Belgium"
                //});

                context.Authors.Add(new Author()
                { FirstName = "Kevin", LastName = "Dockx", CountryId = "BE" });

                // Assert
                // Microsoft.EntityFrameworkCore.DbUpdateException : An error occurred while updating the entries. See the inner exception for details.
                // ----Microsoft.Data.Sqlite.SqliteException : SQLite Error 19: 'FOREIGN KEY constraint failed'.
                Assert.Throws<DbUpdateException>(
                    // Act
                    () => context.SaveChanges());
            }
        }

        [Fact]
        public void GetAuthors_PageSizeIsThree_ReturnsThreeAuthors()
        {
            // Arrange
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new CourseContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                context.Countries.Add(new Country()
                {
                    Id = "BE",
                    Description = "Belgium"
                });

                context.Countries.Add(new Country()
                {
                    Id = "US",
                    Description = "United States of America"
                });

                context.Authors.Add(new Author()
                { FirstName = "Kevin", LastName = "Dockx", CountryId = "BE" });
                context.Authors.Add(new Author()
                { FirstName = "Gill", LastName = "Cleeren", CountryId = "BE" });
                context.Authors.Add(new Author()
                { FirstName = "Julie", LastName = "Lerman", CountryId = "US" });
                context.Authors.Add(new Author()
                { FirstName = "Shawn", LastName = "Wildermuth", CountryId = "BE" });
                context.Authors.Add(new Author()
                { FirstName = "Deborah", LastName = "Kurata", CountryId = "US" });

                context.SaveChanges();
            }

            using (var context = new CourseContext(options))
            {
                //context.Database.OpenConnection();
                //context.Database.EnsureCreated();

                var authorRepository = new AuthorRepository(context);

                // Act
                var authors = authorRepository.GetAuthors(2, 3);

                // Assert
                Assert.Equal(2, authors.Count());
            }
        }

        [Fact]
        public void AddAuthor_AuthorWithoutCountryId_AuthorHasBEAsCountryId()
        {
            // Arrange
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseSqlite(connection)
                .UseLoggerFactory(new LoggerFactory(new[] {
                    new SqliteLoggerProvider(log =>
                    {
                        _output.WriteLine(log);
                    }) }))
                .Options;

            using (var context = new CourseContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                context.Countries.Add(new Country()
                {
                    Id = "BE",
                    Description = "Belgium"
                });

                context.SaveChanges();
            }

            using (var context = new CourseContext(options))
            {
                //context.Database.OpenConnection();
                //context.Database.EnsureCreated();

                var authorRepository = new AuthorRepository(context);
                var authorToAdd = new Author()
                {
                    FirstName = "Kevin",
                    LastName = "Dockx",
                    Id = Guid.Parse("d84d3d7e-3fbc-4956-84a5-5c57c2d86d7b")
                };

                // Act
                authorRepository.AddAuthor(authorToAdd);
                authorRepository.SaveChanges();
            }

            using (var context = new CourseContext(options))
            {
                //context.Database.OpenConnection();
                //context.Database.EnsureCreated();

                // Assert
                var authorRepository = new AuthorRepository(context);
                var addedAuthor = authorRepository.GetAuthor(
                    Guid.Parse("d84d3d7e-3fbc-4956-84a5-5c57c2d86d7b"));
                Assert.Equal("BE", addedAuthor.CountryId);
            }
        }
    }
}
