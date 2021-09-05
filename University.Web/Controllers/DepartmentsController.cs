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
    public class DepartmentsController : Controller
    {
        private readonly UniversityContext context = new UniversityContext();

        // GET: Departments
        [HttpGet]
        public ActionResult Index(int? departmentid, int? pageSize, int? page)
        {
            #region Consluta Deparments
            var query = context.Departments.ToList();

            var deparments = query.Where(x => x.StartDate < DateTime.Now)
                .Select(x => new DepartmentDTO
                {
                    DepartmentID = x.DepartmentID,
                    Name = x.Name,
                    Budget = x.Budget,
                    StartDate = x.StartDate

                }).ToList();
            #endregion
            #region Paginacion
            //Si viene nulo dele 10 por defecto
            pageSize = (pageSize ?? 10);
            //si viene igual por defecto llevelo a la 1 
            page = (page ?? 1);
            ViewBag.pageSize = pageSize;
            #endregion 
            return View(deparments.ToPagedList(page.Value, pageSize.Value));

        }

    }//FIN PUBLIC CLASS CONTROLLER

} // FIN NAMESPACE