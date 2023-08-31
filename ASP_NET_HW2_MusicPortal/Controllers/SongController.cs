using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;

namespace ASP_NET_HW2_MusicPortal.Controllers
{
    public class SongController : Controller
    {
        ISongService songService;
        IGenreService genreService;
        IUserService userService;
        public SongController(ISongService repS, IGenreService repG, IUserService repU)
        {
            this.songService = repS;
            this.genreService = repG;
            this.userService = repU;
        }
        public ActionResult Index()
        {
            var songs = songService.GetSongs();
            return View(songs);
        }
        public ActionResult Create()
        {
            var genres = genreService.GetGenres();
            ViewBag.Genres = genres;
            return View();
        }
        [HttpPost]
        public ActionResult Create(IEnumerable<HttpPostedFileBase> fileUpload, string Name, string Singer, int idGenre)
        {
            try
            {
                foreach (var file in fileUpload)
                {
                    if (file == null) continue;
                    string filename = Path.GetFileName(file.FileName);
                    string tempfolder = Server.MapPath("/Songs");
                    if (filename != null)
                    {
                        file.SaveAs(Path.Combine(tempfolder, filename));
                        SongDTO newSong = new SongDTO();
                        newSong.Name = Name;
                        newSong.Singer = Singer;
                        newSong.Path = "/Songs/" + filename;
                        UserDTO user = userService.GetUser((int)Session["idUser"]);
                        newSong.UserName = user.Name;
                        GenreDTO genre = genreService.GetGenre(idGenre);
                        newSong.Genre = genre.Name;
                        songService.CreateSong(newSong);
                    }

                    
                }               
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Edit(int id) 
        {
            SongDTO songEdit = songService.GetSong(id);
            var genres = genreService.GetGenres();
            ViewBag.genres = genres;

            return View(songEdit);
        }

        [HttpPost]
        public ActionResult Edit(int id, string Name, string Singer, string Genre)
        {
            try
            {
                SongDTO songEdit = songService.GetSong(id);
                songEdit.Singer = Singer;
                songEdit.Name = Name;
                songEdit.Genre = Genre;
                songService.UpdateSong(songEdit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            SongDTO songDelete = songService.GetSong(id);
            return View(songDelete);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SongDTO songDelete = songService.GetSong(id);
                string path = Server.MapPath(songDelete.Path);
                FileInfo fi = new FileInfo(path);
                fi.Delete();
                songService.DeleteSong(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Download(int id)
        {
            try
            {
                SongDTO tmp = songService.GetSong(id);               
                string file_path = Server.MapPath(tmp.Path);              
                string file_type = "application/mp3";      
                string file_name = tmp.Path.Substring(tmp.Path.LastIndexOf('/')+1);                                
                return File(file_path,file_type,file_name);               
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                songService.Dispose();
                genreService.Dispose();
                userService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
