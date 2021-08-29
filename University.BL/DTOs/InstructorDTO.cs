using System;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class InstructorDTO
    {

        [Display(Name = "ID")]
        [Required(ErrorMessage = "El campo ID es requerido")] //ID OPCIONAL PORQUE NO SE ENVIA EN LA VISTA
        public int ID { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "El campo Last Name es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string LastName { get; set; }

        [Display(Name = "First MidName")]
        [Required(ErrorMessage = "El campo First MidName es requerido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string FirstMidName { get; set; }

        [Display(Name ="Hire Date")]
        [Required(ErrorMessage ="El campo Hire Date es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", LastName, FirstMidName);
            }
        }
    }
}
