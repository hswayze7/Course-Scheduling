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
                var enrollment = new StudentCourse
                {
                    CourseId = courseId,
                    StudentId = (int)studentId,
                    RegisteredAt = DateTime.Now
                };
                _context.StudentCourses.Add(enrollment);
                await _context.SaveChangesAsync();
            }

            // Redirect back to the course index page after enrolling
            return RedirectToAction("Index");
        }

    }
}
