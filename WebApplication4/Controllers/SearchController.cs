using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4;

namespace MVC_MirKnig3.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            MirKnigEntities MirKnigEntities = new MirKnigEntities();
            ViewBag.Genre = MirKnigEntities.Genre.ToList();

            string title = Request.QueryString["title"];
            ViewBag.Title = title;

            int Page = 0;
            Int32.TryParse(Request.QueryString["page"], out Page);

            string author = Request.QueryString["author"];
            ViewBag.Author = author;

            string description = Request.QueryString["description"];
            ViewBag.Description = description;

            int GenreID = 0;
            Int32.TryParse(Request.QueryString["genreId"], out GenreID);
            ViewBag.GenreID = GenreID;

            ViewBag.CurPage = Page;
            ViewBag.MaxPage = MirKnigEntities.GetFindMaxPage(Page, title, author, description, GenreID).First().Value;

            var model = MirKnigEntities.FindBook(Page, title, author, description, GenreID).ToList();

            return View(model);
            
        }

        public ActionResult Advance()
        {
            MirKnigEntities MirKnigEntities = new MirKnigEntities();
            ViewBag.Genre = MirKnigEntities.Genre.ToList();

            

            return View();
        }

    }
}
