using System.ComponentModel.DataAnnotations;

namespace InstructorInformationSystem.Models
{
    public class Instructor
    {
        [Key]
        [Required(ErrorMessage = "Instructor ID is required.")]
        [Display(Name = "Instructor ID")]
        public required string InstructorID { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [Display(Name = "Full Name")]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public required string Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        public required string Designation { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [Display(Name = "Contact Number")]
        public required string ContactNumber { get; set; }

        [Required(ErrorMessage = "Majorship is required.")]
        public required string Majorship { get; set; }

        [Required(ErrorMessage = "Bachelor Degree is required.")]
        [Display(Name = "Bachelor Degree")]
        public required string BachelorDegree { get; set; }

        [Required(ErrorMessage = "E-mail Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [Display(Name = "E-mail Address")]
        public required string EmailAddress { get; set; }
    }
}