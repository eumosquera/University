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
            var query = context.Departments.Include("Instructor").ToList();

            var deparments = query.Where(x => x.StartDate < DateTime.Now)
                .Select(x => new DepartmentDTO
                {
                    DepartmentID = x.DepartmentID,
                    Name = x.Name,
                    Budget = x.Budget,
                    StartDate = x.StartDate,
                    InstructorID = x.InstructorID,
                    Instructor =  new InstructorDTO
                    {
                        FirstMidName = x.Instructor.FirstMidName,
                        LastName = x.Instructor.LastName
                    }
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

        [HttpGet]
        public ActionResult Create()
        {

            LoadData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentDTO department)
        {

            try
            {


                LoadData();

                if (!ModelState.IsValid)
                    return View(department);

                if (department.StartDate > DateTime.Now)
                    throw new Exception("La fecha no puede ser mayor a la fecha actual");
                context.Departments.Add(new BL.Models.Department
                {
                    Name = department.Name,
                    Budget = department.Budget,
                    StartDate = department.StartDate,
                    InstructorID = department.InstructorID

                });
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }


            return View(department);
        }
        public void LoadData()
        {
            var Instructors = context.Instructors.Select(x => new InstructorDTO
            {

                ID = x.ID,
                FirstMidName = x.FirstMidName,
                LastName = x.LastName
            }).ToList();
            ViewData["Instructors"] = new SelectList(Instructors, "ID", "FullName");

        }

        [HttpGet]
        public ActionResult Edit(int departmentid)
        {

            LoadData();
            var deparment = context.Departments.Where(x => x.DepartmentID == departmentid)
                                                .Select(x => new DepartmentDTO
                                                {
                                                    DepartmentID = x.DepartmentID,
                                                    Name = x.Name,
                                                    Budget = x.Budget,
                                                    StartDate = x.StartDate,
                                                    InstructorID = x.InstructorID

                                                }).FirstOrDefault();

            return View(deparment);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentDTO department)
        {

            try
            {
                LoadData();

                if (!ModelState.IsValid)
                    return View(department);
                if (department.StartDate > DateTime.Now)
                    throw new Exception("La fecha no puede ser mayor a la fecha actual");
                var departmentModel = context.Departments.FirstOrDefault(x => x.DepartmentID == department.DepartmentID);

                departmentModel.Name = department.Name;
                departmentModel.Budget = department.Budget;
                departmentModel.StartDate = department.StartDate;
                departmentModel.InstructorID = department.InstructorID;
                //aplique cambios
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(department);


        }

        [HttpGet]

        public ActionResult Delete(int departmentid)
        {
            var departmentModel = context.Departments.FirstOrDefault(x => x.DepartmentID == departmentid);
            context.Departments.Remove(departmentModel);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }//FIN PUBLIC CLASS CONTROLLER

} // FIN NAMESPACE