using CourseManager.API.DbContexts;
using CourseManager.API.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CourseManager.API.Tests
{
    public class AuthorRepositoryTests_SQLite
    {
        [Fact]
        public void GetAuthor_EmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<CourseContext>()
                //.UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
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
    }
}
