using CourseScheduling.Models;
using CourseScheduling.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseScheduling.Controllers
{
    public class DegreeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Pathway()
        {
            int? studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null) return RedirectToAction("Login", "Account");

            var student = _context.Students
                .Include(s => s.Enrollments)
                .FirstOrDefault(s => s.StudentId == studentId);

            if (student == null) return NotFound();

            var requirements = _context.DegreeRequirements
                .Include(dr => dr.Course)
                .Where(dr => dr.DegreeId == student.DegreeId)
                .ToList();

            var viewModel = new DegreePathwayViewModel
            {
                MajorName = student.Major,
                Courses = requirements.Select(req =>
                {
                    var enrollment = student.Enrollments.FirstOrDefault(e => e.CourseId == req.CourseId);
                    string status;

                    if (enrollment != null)
                    {
                        status = enrollment.Grade != null ? "Completed" : "In Progress";
                    }
                    else
                    {
                        status = "Not Taken";
                    }

                    return new DegreeCourseStatus
                    {
                        CourseCode = req.CourseCode,
                        CourseName = req.Course.CourseName,
                        Status = status
                    };
                }).ToList()
            };

            return View(viewModel);
        }



    }
}
