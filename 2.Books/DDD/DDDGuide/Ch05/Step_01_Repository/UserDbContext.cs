using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Step_01_Repository
{
    public class UserDbContext : DbContext
    {
        public static UserDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<UserDbContext>();
            builder.UseSqlServer(ConfigurationManager.ConnectionStrings["FooConnection"].ConnectionString);
            var options = builder.Options;
            var context = new UserDbContext(options);

            return context;
        }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }
    }
}
