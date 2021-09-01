﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    class DepartmentDTO
    {

        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        //nav
        public int InstructorID { get; set; }

        public InstructorDTO Instructor { get; set; }

    }
}
