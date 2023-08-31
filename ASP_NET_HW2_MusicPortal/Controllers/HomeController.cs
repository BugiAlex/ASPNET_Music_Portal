using System.Collections.Generic;
using System.Web.Mvc;
using ASP_NET_HW2_MusicPortal.Models;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;

namespace ASP_NET_HW2_MusicPortal.Controllers
{
    public class HomeController : Controller
    {
        ISongService songService;
       public HomeController(ISongService rep)
        {
            this.songService = rep;
        }

        public ActionResult Index()
        {
            var songs = songService.GetSongs();
            List<ViewSong> viewSongsList = new List<ViewSong>();
            foreach (SongDTO i in songs)
            {
                ViewSong tmp = new ViewSong();
                tmp.Id = i.Id;
                tmp.Name = i.Name; 
                tmp.Genre = i.Genre;
                tmp.Singer = i.Singer;
                tmp.User = i.UserName;
                tmp.Path = i.Path;
                viewSongsList.Add(tmp);
            }
            return View(viewSongsList);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                songService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
