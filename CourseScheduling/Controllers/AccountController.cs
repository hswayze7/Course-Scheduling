﻿using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using CourseScheduling.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using CourseScheduling.Services;
using Microsoft.CodeAnalysis.Scripting;

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

            var student = _context.Students.FirstOrDefault(s => s.StudentId == model.StudentId);


            // Set authentication
            HttpContext.Session.SetInt32("StudentId", student.StudentId);

            return RedirectToAction("Profile", "Account"); // Redirect to profile page
        }



        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //Debugging. 
            Console.WriteLine("DEBUG: Register method called.");

            //Debugging. 
            Console.WriteLine("DEBUG: Register method called.");

            //Debugging. 
            Console.WriteLine($"DEBUG: FirstName = {model.FirstName}");
            Console.WriteLine($"DEBUG: LastName = {model.LastName}");
            Console.WriteLine($"DEBUG: Email = {model.Email}");
            Console.WriteLine($"DEBUG: Major = {model.Major}");
            Console.WriteLine($"DEBUG: Year = {model.Year}");

            //Debugging. 
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"DEBUG: ModelState Error - {error.ErrorMessage}");
                }
                return View(model);
            }

            try
            {
                //Debugging. 
                Console.WriteLine("DEBUG: Calling StudentService.CreateStudent.");

                var newStudent = await _studentService.CreateStudent(
                    model.FirstName,
                    model.LastName,
                    model.Email,
                    model.Password,
                    model.Major,
                    model.Year
                );
                //Debugging. 
                Console.WriteLine($"DEBUG: Student successfully created: {newStudent.FirstName} {newStudent.LastName}");

                TempData["SuccessMessage"] = $"Account for {newStudent.FirstName} {newStudent.LastName} created! Please log in."; //Shows message to user that the creation was successful.

                return RedirectToAction("Login", "Account"); //Routes user back to the login page after successful creation
            }
            catch (Exception ex)
            {
                //Debugging. 
                Console.WriteLine($"DEBUG: Exception occurred - {ex.Message}");
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
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
