using System;
using System.Collections.Generic;
using System.Web.Mvc;
using University.BL.Models;
using University.BL.DTOs;
using University.BL.Data;
using System.Linq;
using PagedList;

namespace University.Web.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly UniversityContext context = new UniversityContext();


        [HttpGet]
        public ActionResult Index(int? instructorID, int? pageSize, int? page)
        {
            #region Consluta Instructor
            var query = context.Instructors.ToList();

            var instructors = query.Where(x => x.HireDate < DateTime.Now)
                                .Select(x => new InstructorDTO
                                {
                                    ID = x.ID,
                                    FirstMidName = x.FirstMidName,
                                    LastName = x.LastName,
                                    HireDate = x.HireDate
                                }).ToList();


            #endregion


            #region Lista Instructores

            if (instructorID != null)
            {
                var deparments = (from q in context.Departments
                                  join r in context.Instructors on q.InstructorID equals r.ID
                                  where q.InstructorID == instructorID
                                  select new DepartmentDTO
                                  {
                                      InstructorID = q.InstructorID,
                                      Name = q.Name

                                  }).ToList();

                ViewBag.Deparments = deparments;
            }

            #endregion

            #region Paginacion
            //Si viene nulo dele 10 por defecto
            pageSize = (pageSize ?? 10);
            //si viene igual por defecto llevelo a la 1 
            page = (page ?? 1);
            ViewBag.pageSize = pageSize;
            #endregion 
            return View(instructors.ToPagedList(page.Value, pageSize.Value));
        }


    }
}