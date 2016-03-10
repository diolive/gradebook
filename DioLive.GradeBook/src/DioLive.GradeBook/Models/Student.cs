using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DioLive.GradeBook.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}