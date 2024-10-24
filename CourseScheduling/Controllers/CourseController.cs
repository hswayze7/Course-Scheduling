using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CourseScheduling.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show the list of available courses
        public IActionResult Index()
        {
            // Retrieve the StudentId from the session
            var studentId = HttpContext.Session.GetInt32("StudentId");

            if (studentId == null)
            {
                // If not logged in, redirect to the login page
                return RedirectToAction("Login", "Account");
                Console.WriteLine($"STUDENT THAT IS LOGGED IN: {studentId}");
            }
            Console.WriteLine($"INDEX STUDENT THAT IS LOGGED IN: {studentId}");
            // Fetch the student and include enrollments
            var student = _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)  // Ensure the Course details are included in enrollments
                .FirstOrDefault(s => s.StudentId == studentId);

            // If student exists, pass the student's name and enrolled courses to the view
            if (student != null)
            {
                ViewBag.StudentName = student.Name;  // Student's name for display
                ViewBag.Enrollments = student.Enrollments.ToList();  // Pass enrollments to ViewBag

                foreach (var enrollment in ViewBag.Enrollments)
                {
                    Console.WriteLine($"Enrolled in: {enrollment.Course.CourseName}");
                }
            }

            // Fetch all available courses
            var courses = _context.Courses.ToList();

            // Return the view with available courses
            return View(courses);
        }

        // Enroll in a course
        [HttpPost]
        public async Task<IActionResult> Enroll(int courseId)
        {
            Console.WriteLine("Enroll method triggered PRESSED");

            Console.WriteLine("Enroll method triggered");
            // Get the logged-in student's ID from Session
            var studentId = HttpContext.Session.GetInt32("StudentId");
            Console.WriteLine($"Student ID: {studentId}, Course ID: {courseId}");
            if (studentId == null)
            {
                Console.WriteLine("StudentId is null. Redirecting to login.");
                return RedirectToAction("Login", "Account");
            }
            Console.WriteLine($"ENROLL STUDENT THAT IS LOGGED IN: {studentId}");
            Console.WriteLine($"Attempting to enroll StudentId: {studentId} in CourseId: {courseId}");

            // Check if the student is already enrolled in the course
            var existingEnrollment = _context.Enrollments
                .FirstOrDefault(e => e.CourseId == courseId && e.StudentId == studentId);

            if (existingEnrollment == null)
            {
                var enrollment = new Enrollment
                {
                    CourseId = courseId,
                    StudentId = (int)studentId,
                    EnrollmentDate = DateTime.Now
                };

                _context.Enrollments.Add(enrollment);
                try
                {


                    await _context.SaveChangesAsync();
                    Console.WriteLine("Enrollment successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving enrollment: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Student already enrolled in this course.");
            }

            var student = _context.Students
           .Include(s => s.Enrollments)
           .ThenInclude(e => e.Course)
           .FirstOrDefault(s => s.StudentId == studentId);

            // Redirect back to the course index page after enrolling
            return RedirectToAction(nameof(Index));
        }
    }
}
