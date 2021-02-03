using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.API.Models
{
    [Table("Author")]
    public class Author
    {
        // TODO : DatabaseGenerated 이해하기
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        // TODO : Foreign Key 설정 방법 이해하기
        [Required]
        public string CountryId { get; set; }

        public Country Country { get; set; }
    }
}
