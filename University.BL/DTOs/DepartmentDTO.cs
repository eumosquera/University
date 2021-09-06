using System;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class DepartmentDTO
    {
        [Required()]
        public int DepartmentID { get; set; }

        [Required()]
        public string Name { get; set; }

        [Required()]
        public decimal Budget { get; set; }

        [Required()]
        public DateTime StartDate { get; set; }

        //nav
        public int InstructorID { get; set; }

        public InstructorDTO Instructor { get; set; }

    }
}
