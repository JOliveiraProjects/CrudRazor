using System;
using System.Web.Mvc;

namespace Vidalink.Web.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return Redirect("/Home/Login");

            var list = Services.Task.ListActive();
            return View(list);
        }

        public ActionResult Search(string txtSearch)
        {
            if (Session["UserID"] == null)
                return Redirect("/Home/Login");

            var list = Services.Task.Search(txtSearch);
            return View(list);
        }

        public ActionResult Edit(int id = 0)
        {
            if (Session["UserID"] == null)
                return Redirect("/Home/Login");


            var s = HttpContext.Session["UserID"];
            var model = new Data.Task();
            
            if (id > 0)
            {
                model = Services.Task.Get(id);
                return View(model);
            }
            model.UserId = Convert.ToInt32(Session["UserID"]);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Data.Task model)
        {
            var result = Services.Task.SaveTask(model);
            return View(result);
        }


        public ActionResult Delete(int id)
        {
            var result = Services.Task.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}