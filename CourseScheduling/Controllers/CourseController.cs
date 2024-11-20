using CourseScheduling.Models;
using CourseScheduling.ViewModel;

//using CourseScheduling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CourseScheduling.Controllers
{
    //Controller to handle the user's viewment of classes to enroll in as well as classes that the user is already enrolled in
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly Scraper _scraper;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
            //_scraper = scraper;

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

            //Declaration of variable to add / total the amount of credits for all courses enrolled in by student
            int totalCredits = enrolledCourses.Sum(e => e.Course?.Credits ?? 0);

            var viewModel = new CourseEnrollmentViewModel
            {
                AvailableCourses = availableCourses,
                EnrolledCourses = enrolledCourses
                
            };

            return View(viewModel); // Pass the view model to the view
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalCredits()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }

            var totalCredits = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .SumAsync(e => e.Course.Credits);

            return Json(new { totalCredits });
        }

        [HttpGet]
        public async Task<IActionResult> SearchCourses(string courseName, string courseCode)
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(courseName))
            {
                query = query.Where(c => c.CourseName.Contains(courseName));
            }

            if (!string.IsNullOrEmpty(courseCode))
            {
                query = query.Where(c => c.CourseCode.Contains(courseCode));
            }

            var availableCourses = await query.ToListAsync();

            return PartialView("_AvailableCoursesTable", availableCourses); // Render just the table rows
        }



        //Created for the continue button on the search page. This will allow a user to skip the search option for classes and go straight to the list of classes
        public async Task<IActionResult> ListCourses(string courseName = null, string courseCode = null)
        {
            // Retrieve the studentId from the session
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if not logged in
            }

            // Query all courses or apply filters based on search input
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(courseName))
            {
                query = query.Where(c => c.CourseName.Contains(courseName));
            }

            if (!string.IsNullOrEmpty(courseCode))
            {
                query = query.Where(c => c.CourseCode.Contains(courseCode));
            }

            var availableCourses = await query.ToListAsync();

            // Fetch the student's enrolled courses
            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.StudentId == studentId);

            var enrolledCourses = student?.Enrollments.ToList() ?? new List<Enrollment>();

            // Create the view model, passing both available and enrolled courses
            var viewModel = new CourseEnrollmentViewModel
            {
                AvailableCourses = availableCourses,
                EnrolledCourses = enrolledCourses,
                SearchCourseName = courseName,
                SearchCourseCode = courseCode
            };

            return View("Index", viewModel); // Use Index.cshtml to display courses
        }





        // Enroll in a course
        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] EnrollViewModel model)
        {
            //Getting student ID
            var studentId = HttpContext.Session.GetInt32("StudentId");
            //Error checking
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }
            //Error checking for courseID to make sure course is there
            if (model.CourseId <= 0)
            {
                return BadRequest("Invalid courseId.");
            }

            // Check if the student is already enrolled in the course
            var existingEnrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == model.CourseId);

            if (existingEnrollment != null)
            {
                return BadRequest("You are already enrolled in this course.");
            }

            var course = await _context.Courses.FindAsync(model.CourseId);
            if (course == null)
            {
                return BadRequest("Course not found.");
            }

            // Create a new enrollment
            var enrollment = new Enrollment
            {
                StudentId = (int)studentId,
                CourseId = model.CourseId,
                EnrollmentDate = DateTime.Now
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok("Enrollment successful.");
        }

        //Gives the student an option to delete a course after selecting to enroll in said course
        [HttpPost]
        public async Task<IActionResult> DeleteEnrollment([FromBody] int enrollmentId)
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }

            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.EnrollmentId == enrollmentId && e.StudentId == studentId);

            if (enrollment == null)
            {
                return BadRequest("Enrollment not found or not authorized to delete.");
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            Console.WriteLine("Enrollment deleted successfully.");
            return Ok("Enrollment deleted successfully.");
        }


        //Function to grab what classes the student is enrolled in + add to calendar
        [HttpGet]
        public async Task<IActionResult> GetEnrolledCourses()
        {
            //Assigns studentID to variable
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }

            var enrollments = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .Distinct()
                .ToListAsync();

            // Prepare events for FullCalendar
            var calendarEvents = new List<object>();

            foreach (var enrollment in enrollments)
            {
                var startDateTimes = GetDateTimesForEvent(enrollment.Course.Time, "start");
                var endDateTimes = GetDateTimesForEvent(enrollment.Course.Time, "end");

                for (int i = 0; i < startDateTimes.Count; i++)
                {
                    calendarEvents.Add(new
                    {
                        title = enrollment.Course.CourseName,
                        start = startDateTimes[i].ToString("s"), 
                        end = endDateTimes[i].ToString("s")      
                    });
                }
            }

            return Json(calendarEvents);
        }


        [HttpGet]
        public async Task<IActionResult> GetEnrolledCoursesTable()
        {
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }

            var enrollments = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .ToListAsync();

            return PartialView("_EnrolledCourses", enrollments);
        }

        //Function to help populate the calendar object and split up the string to determine when classes are
        private List<DateTime> GetDateTimesForEvent(string timeString, string type)
        {
            // Mapping of days to DayOfWeek values
            var dayMap = new Dictionary<string, DayOfWeek>
            {
                { "M", DayOfWeek.Monday },
                { "T", DayOfWeek.Tuesday },
                { "W", DayOfWeek.Wednesday },
                { "TR", DayOfWeek.Thursday },
                { "F", DayOfWeek.Friday },
                { "S", DayOfWeek.Saturday },
                { "U", DayOfWeek.Sunday }
            };

            // Split the timeString into day(s) and time range
            var parts = timeString.Split(new[] { ' ' }, 3);
            if (parts.Length != 3)
            {
                throw new FormatException("Invalid time format. Expected format: 'Days StartTime - EndTime'.");
            }

            var days = parts[0].Split('/'); // Split days if there are multiple, -> "M/W/F"
            var timeRange = parts[1] + " " + parts[2]; // Combine start time and end time
            var times = timeRange.Split(new[] { " - " }, StringSplitOptions.None);
            if (times.Length != 2)
            {
                throw new FormatException("Invalid time range format. Expected format: 'StartTime - EndTime'.");
            }

            var timeToParse = type == "start" ? times[0] : times[1];

            // Parse the time into hours, minutes, and AM/PM
            var timeMatch = System.Text.RegularExpressions.Regex.Match(timeToParse.Trim(), @"(\d+):(\d+) (AM|PM)");
            if (!timeMatch.Success)
            {
                throw new FormatException("Invalid time format. Expected format: 'HH:MM AM/PM'.");
            }

            int hours = int.Parse(timeMatch.Groups[1].Value);
            int minutes = int.Parse(timeMatch.Groups[2].Value);
            string meridian = timeMatch.Groups[3].Value;

            if (meridian == "PM" && hours != 12) hours += 12;
            if (meridian == "AM" && hours == 12) hours = 0;

            DateTime today = DateTime.Today;
            HashSet<DateTime> uniqueEventDates = new HashSet<DateTime>();

            // Generate dates for each specified day
            foreach (var day in days)
            {
                if (dayMap.TryGetValue(day.Trim(), out DayOfWeek targetDay))
                {
                    int daysUntilTarget = ((int)targetDay - (int)today.DayOfWeek + 7) % 7;
                    DateTime eventDate = today.AddDays(daysUntilTarget).AddHours(hours).AddMinutes(minutes);

                    // Use HashSet to ensure uniqueness of event dates
                    uniqueEventDates.Add(eventDate);
                }
            }

            return uniqueEventDates.ToList();
        }

      //  [HttpPost]
    /*    public async Task<IActionResult> ImportCourses()
        {
            var url = "http://catalog.wichita.edu/undergraduate/courses/cs/";
            var courses = await _scraper.ScrapeCourseCatalogAsync(url);

            foreach (var course in courses)
            {
                if (!_context.Courses.Any(c => c.CourseName == course.Title))
                {
                    _context.Courses.Add(new CourseScheduling.Models.Course
                    {
                        CourseName = course.Title,
                        Description = course.CourseName,
                        Credits = course.Credits
                    });
                }
            }

            await _context.SaveChangesAsync();

            return Ok("Courses imported successfully.");
        }
*/
        public IActionResult Search()
        {
            var viewModel = new SearchViewModel
            {
                CourseName = string.Empty,
                CourseCode = null,
                Results = new List<Course>()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> SearchResults(string CourseName, string CourseCode)
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(CourseName))
            {
                query = query.Where(c => c.CourseName.Contains(CourseName));
            }

            if (!string.IsNullOrEmpty(CourseCode))
            {
                query = query.Where(c => c.CourseCode.Contains( CourseCode)); // Adjust to handle string IDs
            }

            var results = await query.ToListAsync();

            var viewModel = new SearchViewModel
            {
                CourseName = CourseName,
                CourseCode = CourseCode,
                Results = results
            };

            return View("Search", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseDetails(int courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            return Json(new
            {
                course.CourseName,
                course.CourseCode,
                course.Credits,
                course.Time,
                course.Professor,
                course.Description
            });
        }


    }
}
