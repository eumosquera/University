using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        [Display(Name = "Course ID")]
        [Required(ErrorMessage = "El campo CourseID es requerido.")]
        public int CourseID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "El campo Title es requerido.")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Title { get; set; }

        [Display(Name = "Credits")]
        [Required(ErrorMessage = "El campo Credits es requerido.")]
        public int Credits { get; set; }
    }
}
