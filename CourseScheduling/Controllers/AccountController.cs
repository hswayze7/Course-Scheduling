using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
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
            HttpContext.Session.Clear();  // Clear the session
            return RedirectToAction("Login");
        }
    }
}
