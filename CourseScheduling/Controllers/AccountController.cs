using CourseScheduling.Models;
using Microsoft.AspNetCore.Mvc;
using CourseScheduling.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace CourseScheduling.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(StudentLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null)
                {
                    return BadRequest("Model cannot be null.");
                }

                var student = _context.Students
                    .FirstOrDefault(s => s.StudentId == model.StudentId && s.Password == model.Password);

                if (student == null)
                {
                    ModelState.AddModelError("", "Invalid student ID or password.");
                    return View(model);
                }

                HttpContext.Session.SetInt32("StudentId", student.StudentId);
                return RedirectToAction("Search", "Course");
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            TempData["LogoutMessage"] = "You have successfully logged out.";
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password, // 🔒 Consider hashing for production
                    Major = model.Major,
                    Year = model.Year
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                // TempData carries info across redirect
                TempData["SuccessMessage"] = $"Registration successful! Your Student ID is: {student.StudentId}";
                return RedirectToAction("Register");
            }

            return View(model);
        }
    }
}
