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
            }

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
            Console.WriteLine("Enroll method triggered");
            // Get the logged-in student's ID from Session
            var studentId = HttpContext.Session.GetInt32("StudentId");
            Console.WriteLine($"Student ID: {studentId}, Course ID: {courseId}");
            if (studentId == null)
            {
                Console.WriteLine("StudentId is null. Redirecting to login.");
                return RedirectToAction("Login", "Account");
            }

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
                await _context.SaveChangesAsync();
                Console.WriteLine("Enrollment successful.");
            }
            else
            {
                Console.WriteLine("Student already enrolled in this course.");
            }

            // Redirect back to the course index page after enrolling
            return RedirectToAction(nameof(Index));
        }
    }
}




/*using CourseScheduling.Models;
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
            // Check if the student is logged in (using Session)
            if (HttpContext.Session.GetInt32("StudentId") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var studentId = HttpContext.Session.GetInt32("StudentId");

            var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                ViewBag.StudentName = student.Name;
            }

            // Fetch the logged-in student's enrollments
            var enrollments = _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)  // Include course details
                .ToList();

            // Pass the enrollments to the view
            ViewBag.Enrollments = enrollments;

            var courses = _context.Courses.ToList();
            return View(courses);
        }

        // Enroll in a course
        [HttpPost]
        public async Task<IActionResult> Enroll(int courseId)
        {
            // Get the logged-in student's ID from TempData (or Session if using Session)
            if (TempData["StudentId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var studentId = HttpContext.Session.GetInt32("StudentId");

            // Check if the student is already enrolled in the course to prevent duplicate enrollments
            var existingEnrollment = _context.StudentCourses
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
                await _context.SaveChangesAsync();
            }

            // Redirect back to the course index page after enrolling
            return RedirectToAction(nameof(Index), new { studentId = studentId });

        }

    }
}*/
