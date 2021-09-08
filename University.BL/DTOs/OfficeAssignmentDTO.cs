using System;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class OfficeAssignmentDTO
    {
        [Display(Name = "InstructorID")]
        [Required(ErrorMessage = "El campo InstructorID es requerido.")]
        public int InstructorID { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "El campo Location es requerido.")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Location { get; set; }

        //nav
        public InstructorDTO Instructor { get; set; }

    }
}
