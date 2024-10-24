using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        public async Task<IActionResult> Index()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");

            if (studentId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var availableCourses = await _context.Courses.ToListAsync();

            // Fetch the student's enrolled courses
            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            
            var enrolledCourses = student?.Enrollments.ToList() ?? new List<Enrollment>();

            var viewModel = new CourseEnrollmentViewModel
            {
                AvailableCourses = availableCourses,
                EnrolledCourses = enrolledCourses
            };

            return View(viewModel); // Pass the view model to the view
        }


        // Enroll in a course

        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] EnrollViewModel model)
        {
            Console.WriteLine($"Received CourseId: {model.CourseId}");

            if (model.CourseId <= 0)
            {
                Console.WriteLine("Invalid CourseId.");
                return BadRequest("Invalid courseId.");
            }

            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }

            var course = await _context.Courses.FindAsync(model.CourseId);
            if (course == null)
            {
                return BadRequest("Course not found.");
            }

            // Check if the student is already enrolled in this course
            var existingEnrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.CourseId == model.CourseId && e.StudentId == studentId);

            if (existingEnrollment == null)
            {
                // Add the enrollment to the database
                var enrollment = new Enrollment
                {
                    CourseId = model.CourseId,
                    StudentId = studentId.Value,  // Ensure studentId is not null
                    EnrollmentDate = DateTime.Now
                };

                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();  // Save the new enrollment to the database
                Console.WriteLine("Enrollment successful.");
            }
            else
            {
                Console.WriteLine("Student is already enrolled in this course.");
            }

            return Ok("Enrollment successful.");
        }


        [HttpGet]
        public async Task<IActionResult> GetEnrolledCourses()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }

            // Get the student's enrolled courses
            var enrollments = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course) // Include the course details
                .ToListAsync();

            // Return the partial view with updated enrollments
            return PartialView("_EnrolledCourses", enrollments);
        }


    }
}
