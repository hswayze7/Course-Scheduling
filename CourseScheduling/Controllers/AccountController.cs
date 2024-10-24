using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CourseScheduling.Controllers
{
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
                var student = _context.Students
                    .FirstOrDefault(s => s.StudentId == model.StudentId && s.Password == model.Password);

                if (student != null)
                {
                    // Set authentication
                    HttpContext.Session.SetInt32("StudentId", student.StudentId);
                    return RedirectToAction("Index", "Course");  // Redirect to the course page
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
