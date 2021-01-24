using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Step_01_Repository
{
    [Table("Users")]
    public class UserDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
