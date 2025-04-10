using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseScheduling.Models
{
    public class DegreeRequirement
    {
        public int Id { get; set; }

        [Required]
        public string Major { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public bool IsRequired { get; set; }
        public int? SemesterSuggestion { get; set; }

        public Course Course { get; set; }
    }
}
