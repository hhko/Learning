using Microsoft.EntityFrameworkCore;
using System;

namespace Step_01_Repository
{
    class Program
    {
        static void Main(string[] args)
        {
            var entryPoint = new EntryPoint(
                new SqlServerUserRepository(
                    new UserDbContext(
                        new DbContextOptions<UserDbContext>())));

            entryPoint.CreateUser("고길동");
        }
    }
}
