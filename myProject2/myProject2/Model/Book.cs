using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject2.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime FirstDate { get; set; }

        [Required]
        public DateTime SecondDate { get; set; }

        [Required]
        public string Symptoms { get; set; }
        
    }
}