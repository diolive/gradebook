using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DioLive.GradeBook.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        public int Number { get; set; }

        [Required]
        public string Title { get; set; }

        public int MaxResult { get; set; }

        public DateTime Deadline { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}