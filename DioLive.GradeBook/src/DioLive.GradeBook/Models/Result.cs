using System;

namespace DioLive.GradeBook.Models
{
    public class Result
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }

        public int Value { get; set; }

        public DateTime CompleteDate { get; set; }
    }
}