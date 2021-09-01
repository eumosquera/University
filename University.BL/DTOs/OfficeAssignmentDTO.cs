using System;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class OfficeAssignmentDTO
    {
        [Required()]
        public int InstructorID { get; set; }

        [Required()]
        [StringLength(50)]
        public string Location { get; set; }

        //nav
        public InstructorDTO Instructor { get; set; }

    }
}
