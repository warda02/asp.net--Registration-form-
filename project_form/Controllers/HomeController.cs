
using project_form;
using System.Linq;
using System.Web.Mvc;


namespace Project_form.Controllers

{
    public class HomeController : Controller
    {
        enrollEntities1 obj = new enrollEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student a)
        {

            obj.Students.Add(a);
            obj.SaveChanges();
            return RedirectToAction("login", "Home");


        }
         
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Student e)
        {
            var f = obj.Students.Where(model => model.Email == e.Email && model.Password == e.Password).FirstOrDefault();

            if (f != null)
            {
                return RedirectToAction("Welcome", "Home");

            }
            else
            {
                return View();

            }
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}
