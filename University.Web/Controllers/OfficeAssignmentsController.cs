using System.Linq;
using System.Web.Mvc;
using University.BL.Data;
using University.BL.DTOs;


namespace University.Web.Controllers
{
    public class OfficeAssignmentsController : Controller
    {

        private readonly UniversityContext context = new UniversityContext();
        // GET: OfficeAssignments
        public ActionResult Index()
        {
            //SELECT * FROM OfficeAssignments
            var query = context.OfficeAssignments.Include("Instructor").ToList();

            var offices = query.Select(x => new OfficeAssignmentDTO
            {
                InstructorID = x.InstructorID,
                Location = x.Location,
                Instructor = new InstructorDTO
                {
                    FirstMidName = x.Instructor.FirstMidName,
                    LastName = x.Instructor.LastName
                }


            });

            return View(offices);
        }


        [HttpGet]
        public ActionResult Create()
        {
            LoadData();
            context.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult Create(OfficeAssignmentDTO office)
        {
            LoadData();
            context.SaveChanges();

            if (!ModelState.IsValid)
            {

                return View(ModelState);
            }

            
            return RedirectToAction("Index");

            
        }

        public void LoadData()
        {
            var Instructors = context.Instructors.Select(x => new InstructorDTO
            {

                ID = x.ID,
                LastName = x.LastName
            }).ToList();

            // value, text

            ViewData["Instructors"] = new SelectList(Instructors, "ID", "FullName");

        }
    }
}