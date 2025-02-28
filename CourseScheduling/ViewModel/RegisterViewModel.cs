using System.ComponentModel.DataAnnotations;
using CourseScheduling.Models;
using CourseScheduling.ViewModel;

namespace CourseScheduling.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        public  string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public  string LastName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public  string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public  string Password { get; set; }
        [Required(ErrorMessage = "Your year is required")]
        public  string Year { get; set; }
        [Required(ErrorMessage = "Major is required")]
        public  string Major { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }

       // public Student Student { get; set; }
    }


}
