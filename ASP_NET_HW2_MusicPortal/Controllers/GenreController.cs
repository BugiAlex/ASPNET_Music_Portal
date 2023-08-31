using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Web.Mvc;

namespace ASP_NET_HW2_MusicPortal.Controllers
{
    public class GenreController : Controller
    {
        IGenreService genreService;
        public GenreController(IGenreService rep)
        {
            this.genreService = rep;
        }
        public ActionResult Index()
        {
            var genres = genreService.GetGenres();
            return View(genres);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string Name)
        {
            try
            {
                GenreDTO genreNew = new GenreDTO();
                genreNew.Name = Name;
                genreService.CreateGenre(genreNew);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            GenreDTO genreEdit = genreService.GetGenre(id);

            return View(genreEdit);
        }

        [HttpPost]
        public ActionResult Edit(int id, string Name)
        {
            GenreDTO genreEdit = genreService.GetGenre(id);
            try
            {
                
                genreEdit.Name = Name;
                genreService.UpdateGenre(genreEdit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genreEdit);
            }
        }
        public ActionResult Delete(int id)
        {
            GenreDTO genreDelete = genreService.GetGenre(id);
            return View(genreDelete);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                genreService.DeleteGenre(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                genreService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
