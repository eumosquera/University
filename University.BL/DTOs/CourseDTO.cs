using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        [Required()]
        public int CourseID { get; set; }

        [Required()]
        public string Title { get; set; }

        [Required()]
        public int Credits { get; set; }
    }
}
