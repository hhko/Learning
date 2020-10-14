using Ch03._09.__Infrastructure__.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._09.__Infrastructure__
{
    public class CollegeModel : DbContext
    {
        public CollegeModel()
            : base("name=CollegeModel")
        {

        }

        public virtual DbSet<Professor> Professors { get; set; }
    }
}
