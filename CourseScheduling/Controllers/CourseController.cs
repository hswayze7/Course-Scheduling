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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Get the logged-in student's ID from the session
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Fetch all available courses
            var availableCourses = await _context.Courses.ToListAsync();

            // Fetch the student's enrolled courses
            var enrolledCourses = await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .ToListAsync();

            // Fetch the student's waitlisted courses
            var waitlistedCourses = await _context.Waitlists
                .Where(w => w.StudentId == studentId)
                .Include (w => w.Course)
                .Select(w => w.Course)
                .ToListAsync();

            // Check for time conflicts
            foreach (var course in availableCourses)
            {
                course.HasConflict = enrolledCourses.Any(enrolled =>
                    HasTimeConflict(enrolled.Course.Time, course.Time));
            }


            // Pass the data to the view using ViewBag or ViewModel
            ViewBag.EnrolledCourses = enrolledCourses;
            ViewBag.WaitlistedCourses = waitlistedCourses;

            var student = await _context.Students.FindAsync(studentId);
            var majorPrefix = GetCoursePrefixFromMajor(student.Major ?? "");
            var recommendedCourses = await _context.Courses
                .Where(c => c.CourseCode.StartsWith(majorPrefix))
                .ToListAsync();

            // Prepare the view model
            var viewModel = new CourseEnrollmentViewModel
            {
                StudentId = studentId.Value,
                AvailableCourses = availableCourses,
                EnrolledCourses = enrolledCourses,
                RecommendedCourses = recommendedCourses
            };

            return View(viewModel);
        }
        //Recommended courses based on CourseID
        public async Task<IActionResult> RecommendedCourses(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }

            var majorPrefix = GetCoursePrefixFromMajor(student.Major ?? "");

            var recommendedCourses = await _context.Courses
                .Where(c => c.CourseCode.StartsWith(majorPrefix))
                .ToListAsync();

            var viewModel = new RecommendationViewModel
            {
                Major = student.Major,
                RecommendedCourses = recommendedCourses
            };

            return View(viewModel); 
        }

        private static string GetCoursePrefixFromMajor(string major)
        {
            return major switch
            {
                "Computer Science" => "CS",
                "Business" => "BUS",
                "Mathematics" => "MATH",
                "Biology" => "BIO",
                _ => "" // Default fallback
            };
        }


        private bool HasTimeConflict(string time1, string time2)
        {
            try
            {
                var days1 = ExtractDays(time1);
                var timeRange1 = ExtractTimeRange(time1);

                var days2 = ExtractDays(time2);
                var timeRange2 = ExtractTimeRange(time2);

                // Check if any day overlaps
                if (days1.Intersect(days2).Any())
                {
                    // Check if the time ranges overlap
                    return timeRange1.start < timeRange2.end && timeRange1.end > timeRange2.start;
                }
            }
            catch
            {
               
            }

            return false;
        }

        // Helper method to extract days (e.g., "M/W/F")
        private List<string> ExtractDays(string timeString)
        {
            var parts = timeString.Split(' ', 2); // Split days and time range
            return parts[0].Split('/').Select(d => d.Trim()).ToList();
        }

        // Helper method to extract start and end times
        private (TimeSpan start, TimeSpan end) ExtractTimeRange(string timeString)
        {
            var parts = timeString.Split(' ', 2); // Split days and time range
            var timeRange = parts[1].Split('-').Select(t => t.Trim()).ToArray();
            var start = DateTime.ParseExact(timeRange[0], "h:mm tt", null).TimeOfDay;
            var end = DateTime.ParseExact(timeRange[1], "h:mm tt", null).TimeOfDay;
            return (start, end);
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
            // Getting student ID
            var studentId = HttpContext.Session.GetInt32("StudentId");
            if (studentId == null)
            {
                return Unauthorized("Student not logged in.");
            }

            // Error checking for courseID to make sure course is there
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

            // Find the course and check availability
            var course = await _context.Courses.FindAsync(model.CourseId);
            if (course == null)
            {
                return BadRequest("Course not found.");
            }

            if (course.CurrentEnrollment >= course.MaxCapacity)
            {
                return BadRequest("Course is full.");
            }


            var prerequisites = await _context.CoursePrerequisites
                .Where(p => p.CourseId == model.CourseId)
                .Select(p => p.PrerequisiteCourseId)
                .ToListAsync();

            var completedCourseIds = await _context.Enrollments
                .Where(e => e.StudentId == studentId && e.Grade != null) // only completed
                .Select(e => e.CourseId)
                .ToListAsync();

            var missing = prerequisites.Except(completedCourseIds).ToList();

            if (missing.Any())
            {
                return BadRequest("You have not completed all the prerequisites for this course.");
            }




            // Create a new enrollment
            var enrollment = new Enrollment
            {
                StudentId = (int)studentId,
                CourseId = model.CourseId,
                EnrollmentDate = DateTime.Now
            };

            _context.Enrollments.Add(enrollment);
            course.CurrentEnrollment += 1; // Update enrollment count
            await _context.SaveChangesAsync();

            // Return the updated course data to the client
            return Json(new
            {
                courseId = course.CourseId,
                courseCode = course.CourseCode,
                courseName = course.CourseName,
                credits = course.Credits,
                time = course.Time,
                professor = course.Professor,
                maxCapacity = course.MaxCapacity,
                currentEnrollment = course.CurrentEnrollment
            });
        }




        //Gives the student an option to delete a course after selecting to enroll in said course
        [HttpPost]
        public async Task<IActionResult> DeleteEnrollment([FromBody] int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
            {
                return NotFound("Enrollment not found.");
            }

            var course = await _context.Courses.FindAsync(enrollment.CourseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            _context.Enrollments.Remove(enrollment);
            course.CurrentEnrollment -= 1; // Decrement the current enrollment count
            await _context.SaveChangesAsync();

            // Return the updated course data to the client
            return Json(new
            {
                courseId = course.CourseId,
                currentEnrollment = course.CurrentEnrollment,
                maxCapacity = course.MaxCapacity
            });
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
      /*  public IActionResult Search()
        {
            var viewModel = new StudentProfileViewModel
            {
                CourseName = string.Empty,
                CourseCode = null,
                Results = new List<Course>()
            };

            return View(viewModel);
        }*/

     /*   [HttpGet]
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

            var viewModel = new StudentProfileViewModel
            {
                CourseName = CourseName,
                CourseCode = CourseCode,
                Results = results
            };

            return View("Search", viewModel);
        }
*/
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
