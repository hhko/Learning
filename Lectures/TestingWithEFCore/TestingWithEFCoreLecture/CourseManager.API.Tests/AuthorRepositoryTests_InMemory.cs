using CourseManager.API.DbContexts;
using CourseManager.API.Models;
using CourseManager.API.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace CourseManager.API.Tests
{
    public class AuthorRepositoryTests_InMemory
    {
        [Fact]
        public void GetAuthors_PageSizeIsThree_ReturnsThreeAuthors()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CourseContext>()
                // InMemory 데이터베이스를 격리시킨다.
                .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
                .Options;

            using (var context = new CourseContext(options))
            {
                // Foreign Key가 등록되어 있지 않아도 테스트가 성공한다.
                // why?
                //   InMemory 데이터베이스는 Relationship 데이터베이스가 아니기 때문이다.
                //context.Countries.Add(new Country()
                //{
                //    Id = "BE",
                //    Description = "Belgium"
                //});

                //context.Countries.Add(new Country()
                //{
                //    Id = "US",
                //    Description = "United States of America"
                //});

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
                var authorRepository = new AuthorRepository(context);

                // Act
                var authors = authorRepository.GetAuthors(2, 3);

                // Assert
                Assert.Equal(2, authors.Count());
            }
        }

        [Fact]
        public void GetAuthor_EmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
                .Options;

            using (var context = new CourseContext(options))
            {
                var authorRepository = new AuthorRepository(context);

                // Assert
                Assert.Throws<ArgumentException>(
                    // Act      
                    () => authorRepository.GetAuthor(Guid.Empty));
            }
        }

        [Fact]
        public void AddAuthor_AuthorWithoutCountryId_AuthorHasBEAsCountryId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CourseContext>()
                .UseInMemoryDatabase($"CourseDatabaseForTesting{Guid.NewGuid()}")
                .Options;

            using (var context = new CourseContext(options))
            {
                // 단위 테스트가 격리(Isolation)되지 않으면 예외가 발생한다.
                // 이전 단위 테스트에서 이미 "BE" Id가 추가되어 있기 때문이다.
                context.Countries.Add(new Country()
                {
                    Id = "BE",
                    Description = "Belgium"
                });

                context.SaveChanges();
            }

            using (var context = new CourseContext(options))
            {
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
                // Assert
                var authorRepository = new AuthorRepository(context);
                var addedAuthor = authorRepository.GetAuthor(
                    Guid.Parse("d84d3d7e-3fbc-4956-84a5-5c57c2d86d7b"));
                Assert.Equal("BE", addedAuthor.CountryId);
            }
        }
    }
}
