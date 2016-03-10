using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DioLive.GradeBook.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Display(Order = 1)]
        public int Number { get; set; }

        [Display(Order = 2)]
        [Required]
        public string Title { get; set; }

        [Display(Order = 3)]
        public int MaxResult { get; set; }

        [Display(Order = 4)]
        public DateTime Deadline { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}