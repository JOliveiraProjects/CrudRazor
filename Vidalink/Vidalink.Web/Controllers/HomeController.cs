using System.Web.Mvc;

namespace Vidalink.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Data.UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                var user = Services.User.Login(objUser);
                if (user != null)
                {
                    Session["UserID"] = user.UserId.ToString();
                    Session["UserName"] = user.UserName.ToString();
                    return RedirectToAction("Index");
                }
            }
            return View(objUser);
        }

        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Login");

            var list = Services.Task.ListTaskLastExceDate(5);
            return View(list);
        }

        public ActionResult Exit()
        {
            Session.Remove("UserID");
            Session.Remove("UserName");
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}