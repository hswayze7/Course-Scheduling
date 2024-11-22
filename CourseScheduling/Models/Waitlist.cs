namespace CourseScheduling.Models
{
    public class Waitlist
    {
        public int WaitlistId { get; set; }
        public int CourseId { get; set; }   
        public int StudentId { get; set; }
        public DateTime AddedToWaitlist { get; set; }


        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
