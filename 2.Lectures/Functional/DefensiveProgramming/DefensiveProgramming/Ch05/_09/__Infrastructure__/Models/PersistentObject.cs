using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ch03._09.__Infrastructure__.Models
{
    public class PersistentObject
    {
        [Key]
        public int Id { get; set; }
    }
}
