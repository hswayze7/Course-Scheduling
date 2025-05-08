using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseScheduling.Models
{
    public class DegreeRequirement
    {
        public int DegreeRequirementId { get; set; }

        public int DegreeId { get; set; }

        public string CourseCode { get; set; }

        [Required]
        public string Major { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public bool IsRequired { get; set; }
        public int? SemesterSuggestion { get; set; }

        public Course Course { get; set; }

        public Degree Degree { get; set; }
    }
}
