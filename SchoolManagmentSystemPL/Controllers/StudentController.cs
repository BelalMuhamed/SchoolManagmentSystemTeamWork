using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystemBLL.UnitOfWork;

namespace SchoolManagmentSystemPL.Controllers
{
    public class StudentController : Controller
    {
        private readonly UnitofWork unit;

        public StudentController(UnitofWork _unit)
        {
            unit = _unit;
        }
        public IActionResult Index()
        {
            

           
            return View();
        }
    }
}
