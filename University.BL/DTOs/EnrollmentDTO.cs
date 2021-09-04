using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class EnrollmentDTO
    {
        [Required()]
        public int EnrollmentID { get; set; }

        [Required()]
        public int CourseID { get; set; }

        [Required()]
        public int StudentID { get; set; }

       
        public CourseDTO Course { get; set; }
        public StudentDTO Student { get; set; }

    }
}
