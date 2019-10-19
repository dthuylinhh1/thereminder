using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheReminder.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        [Required]
        [StringLength(100)]
        public string TaskName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Required]
        [StringLength(10)]
        public string CompleteStatus { get; set; }
        public int StudentNumber { get; set; }

        [ForeignKey("StudentNumber")]
        [InverseProperty("Task")]
        public Student StudentNumberNavigation { get; set; }
    }
}
