using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using CourseScheduling.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CourseScheduling.Controllers
{
    //Controller to handle that user login.
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display the login form
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Handle login logic
        [HttpPost]
        public IActionResult Login(StudentLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the student exists in the database
                if (model == null)
                {
                    return BadRequest("Model cannot be null.");
                }

                Console.WriteLine($"StudentId: {model.StudentId}, Password: {model.Password}");

                var student = _context.Students
                    .FirstOrDefault(s => s.StudentId == model.StudentId && s.Password == model.Password);

                if (student == null)
                {
                    return Unauthorized("Invalid student ID or password.");
                }

                if (student != null)
                {
                    // Set authentication
                    HttpContext.Session.SetInt32("StudentId", student.StudentId);
                    //return RedirectToAction("Index", "Course");  // Redirect to the course page
                    return RedirectToAction("Search", "Course"); //Goes to the search page
                }
                else
                {
                    ModelState.AddModelError("", "Invalid student ID or password.");
                }
            }

            return View(model);
        }

        // Logout 
        public IActionResult Logout()
        {
            TempData["LogoutMessage"] = "You have successfully logged out."; //Displays a message after logging out stating that the action was successful
            HttpContext.Session.Clear();  // Clear the session
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Code to create user and save to the database
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password, // Make sure to hash passwords in production
                    Major = model.Major,
                    Year = model.Year
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                ViewBag.RegistrationSuccess = true;
                // Set success message
                //TempData["SuccessMessage"] = "Registration successful! Your account has been created.";

                //return RedirectToAction("Login", "Account"); // Redirect to the login page or any other page
                return View(model);
                
            }

            return View(model);
        }

    }
}
