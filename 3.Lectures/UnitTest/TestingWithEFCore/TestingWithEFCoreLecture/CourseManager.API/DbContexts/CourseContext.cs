using CourseManager.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.API.DbContexts
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Country> Countries { get; set; }

        // Case 1. 외부에서 옵션 전달받기
        //   단위 테스트에서 옵션을 주입 시킬 수 있다
        public CourseContext(DbContextOptions<CourseContext> options)
         : base(options)
        {
            // _options.Extensions[1] StoreName : "CourseManagerInMemoryDB", string
        }

        // Case 2. 직접 옵션 설정하기
        // TODO : 호출이 안된다. 언제 호출되는 것일까? EF Core NuGet Console 명령일 때 호출되는 것일까?
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //base.OnConfiguring(optionsBuilder);

        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //            .UseInMemoryDatabase("CourseManagerInMemoryDB");
        //    }
        //}
    }
}
