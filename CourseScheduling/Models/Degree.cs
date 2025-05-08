namespace CourseScheduling.Models
{
    public class Degree
    {
        public int DegreeId { get; set; }   
        public string MajorName { get; set; }
        public ICollection<DegreeRequirement> Requirements { get; set; }
    }
}
