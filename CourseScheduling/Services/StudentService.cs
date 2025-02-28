using CourseScheduling.Models;
using System;
using System.Linq;

namespace CourseScheduling.Services
{
    //Service to create a new student (user) and save into database
    public class StudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(string firstName, string lastName, string email, string password, string major, string year)
        {
            //Debugging. 
            Console.WriteLine("DEBUG: Inside CreateStudent method.");

            //Checks for same email between users ----- no repeats
            if (_context.Students.Any(s => s.Email == email))
            {
                //Debugging. 
                Console.WriteLine("DEBUG: Student with this email already exists.");
                throw new Exception("A student with this email already exists.");
            }

            //create new student object
            var newStudent = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Major = major,
                Year = year
            };

            //Debugging. 
            Console.WriteLine($"DEBUG: Adding student {newStudent.FirstName} {newStudent.LastName} to database.");

            _context.Students.Add(newStudent); //Saves / adds to database
            int changes = await _context.SaveChangesAsync();
            //Debugging. 
            Console.WriteLine($"DEBUG: SaveChangesAsync() affected {changes} rows.");

            //Debugging. //Debugging. //Debugging. 
            if (changes == 0)
            {
                Console.WriteLine("ERROR: No data was saved to the database.");
                throw new Exception("Failed to save student to the database.");
            }

            return newStudent;
        }
    }
}
