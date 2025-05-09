using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using CourseScheduling.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using CourseScheduling.Services;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CourseScheduling.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context; //Inject DB
        private readonly StudentService _studentService; // Inject StudentService

        public AccountController(ApplicationDbContext context, StudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        // Display login form
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }


        // Handle login logic
        [HttpPost("Login")]
        public IActionResult Login(StudentLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                return BadRequest("Model cannot be null.");
            }

            var student = _context.Students
                .FirstOrDefault(s => s.Username == model.Username && s.Password == model.Password);

            if (student == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }

            // Set session using the StudentId (still primary key)
            HttpContext.Session.SetInt32("StudentId", student.StudentId);

            return RedirectToAction("Profile", "Account");
        }




        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost("Register")]
        
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            var matchedDegree = _context.Degrees
    .FirstOrDefault(d => d.MajorName.ToLower() == model.Major.Trim().ToLower());

            if (matchedDegree == null)
            {
                ModelState.AddModelError("Major", "This major is not recognized. Please enter a valid one.");

                // Re-show the form
                return View(model);
            }


            if (!ModelState.IsValid)
            {
                foreach (var kvp in ModelState)
                {
                    foreach (var error in kvp.Value.Errors)
                    {
                        Console.WriteLine($"FIELD: {kvp.Key} ? ERROR: {error.ErrorMessage}");
                    }
                }
                return View(model);
            }

            
            if (_context.Students.Any(s => s.Email == model.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(model);
            }

            
            if (_context.Students.Any(s => s.Username == model.Username))
            {
                ModelState.AddModelError("Username", "This username already exists. Please contact support.");
                return View(model);
            }

            
            var newStudent = await _studentService.CreateStudent(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password,
                model.Major,
                model.Year,
                model.Username,
                matchedDegree.DegreeId
            );

            TempData["SuccessMessage"] = $"Account for {newStudent.FirstName} {newStudent.LastName} created! Please log in.";
            return RedirectToAction("Login", "Account");
        }




        // Logout
        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            Console.WriteLine("DEBUG: Logout method called");
            HttpContext.Session.Clear();  // Clear the session
            TempData["LogoutMessage"] = "You have successfully logged out."; // Logout message
            //return RedirectToAction("Login", "Account");
            return Redirect("~/Account/Login");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            // Get the logged-in student ID from session
            int? studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return RedirectToAction("Login"); // Redirect if not logged in
            }

            // Fetch student info from database
            var student = _context.Students
                .Where(s => s.StudentId == studentId)
                .Select(s => new StudentProfileViewModel
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    Major = s.Major,
                    Year = s.Year,
                    EnrolledCourses = _context.Enrollments
                        .Where(e => e.StudentId == studentId)
                        .Select(e => new CourseViewModel
                        {
                            CourseCode = e.Course.CourseCode,
                            CourseName = e.Course.CourseName,
                            Professor = e.Course.Professor,
                            Time = e.Course.Time
                        }).ToList()
                }).FirstOrDefault();

            if (student == null)
            {
                return RedirectToAction("Login"); // Redirect if no student found
            }

            return View(student);
        }
    }
}
