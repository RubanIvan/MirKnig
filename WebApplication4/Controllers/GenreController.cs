using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4;

namespace MVC_MirKnig3.Controllers
{
    public class GenreController : Controller
    {
        //
        // GET: /Genre/

        public ActionResult Index(int? genreid, int? page)
        {
            MirKnigEntities MirKnigEntities = new MirKnigEntities();
            ViewBag.Genre = MirKnigEntities.Genre.ToList();

            int Page = (page == null) ? 0 : page.Value;
            int GenreId = (genreid == null) ? 0 : genreid.Value;

            var model = MirKnigEntities.GetBookPage(Page, GenreId);

            ViewBag.CurPage = Page;
            ViewBag.MaxPage = MirKnigEntities.GetMaxPage(GenreId).First().Value;

            ViewBag.GenreId = GenreId;
            ViewBag.Title = "Mirknig 150 000 книг в бесплатном онлайн чтении.";

            return View(model);
            
        }

    }
}
