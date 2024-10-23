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

            var courses = _context.Courses.ToList();
            return View(courses);
        }

        // Enroll in a course
        [HttpPost]
        public async Task<IActionResult> Enroll(int courseId, int studentId)
        {
            var enrollment = new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId,
                RegisteredAt = DateTime.Now
            };
            _context.StudentCourses.Add(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
