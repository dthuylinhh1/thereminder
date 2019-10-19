using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheReminder.Models
{
    public partial class Student
    {
        public Student()
        {
            Task = new HashSet<Task>();
        }

        public int StudentId { get; set; }
        [Key]
        public int StudentNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty("StudentNumberNavigation")]
        public ICollection<Task> Task { get; set; }
    }
}
