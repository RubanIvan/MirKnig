using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication4;

namespace MVC_MirKnig3.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        [HttpGet]
        public ActionResult Index(int bookid)
        {
            MirKnigEntities MirKnigEntities = new MirKnigEntities();
            ViewBag.Genre = MirKnigEntities.Genre.ToList();

            var data = MirKnigEntities.GetBookById(bookid);
            if (data.Count() == 0) return RedirectToAction("Index", "Genre");


            var model = MirKnigEntities.GetBookById(bookid).First();

            ViewBag.GenreId = model.GenreID;
            ViewBag.Title = model.Title;

            ViewBag.Comments = MirKnigEntities.GetComment(bookid);


            return View(model);
            
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            MirKnigEntities MirKnigEntities = new MirKnigEntities();

            int id;
            if (!int.TryParse(Request.Params["BookId"], out id))return RedirectToAction("Index", "Genre");

            @User.Identity.GetUserId();

            MirKnigEntities.AddComment(id, @User.Identity.GetUserId(), Request.Params["comment"]);
            MirKnigEntities.SaveChanges();
            return RedirectToAction("Index", "Book", new {bookid = id});

        }

    }
}
