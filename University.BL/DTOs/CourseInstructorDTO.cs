﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    class CourseInstructorDTO
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int InstructorID { get; set; }

        //nav
        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
    }
}
