using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseInstructorDTO
    {
        [Required()]
        public int ID { get; set; }
        [Required()]
        public int CourseID { get; set; }
        [Required()]
        public int InstructorID { get; set; }

        //nav
        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
