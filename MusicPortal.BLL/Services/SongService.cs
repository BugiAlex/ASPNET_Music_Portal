using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Collections.Generic;
using MusicPortal.BLL.Infrastructure;
using MusicPotal.DAL.Interfaces;
using MusicPotal.DAL.Models;

namespace MusicPortal.BLL.Services
{
    public class SongService : ISongService
    {
        IUnitOfWork db { get; set; }
        public SongService(IUnitOfWork uow)
        {
            this.db = uow;
        }
        public void CreateSong(SongDTO songDto)
        {
            Song newSong = new Song
            {
                Id = songDto.Id,
                Name = songDto.Name,
                Singer = songDto.Singer,
                Path = songDto.Path,
                Genre = songDto.Genre,
                UserName = songDto.UserName
            };
            db.Songs.Create(newSong);
            db.Save();
        }
        public void UpdateSong(SongDTO songDto)
        {
            Song updateSong = db.Songs.Get(songDto.Id);           
            updateSong.Name = songDto.Name;         
            updateSong.Singer = songDto.Singer;
            updateSong.Genre = songDto.Genre;            
            db.Songs.Update(updateSong);
            db.Save();
        }
        public void DeleteSong(int id)
        {
            db.Songs.Delete(id);
            db.Save();
        }
        public SongDTO GetSong(int id)
        {
            var song = db.Songs.Get(id);
            if (song == null)
                throw new ValidationException("Wrong song!", "");
            return new SongDTO
            {
                Id = song.Id,
                Name = song.Name,
                Path = song.Path,
                UserName = song.UserName,
                Genre = song.Genre,
                Singer = song.Singer
            };
        }
        public IEnumerable<SongDTO> GetSongs()
        {
            List<SongDTO> songsDTO = new List<SongDTO>();
            var songs = db.Songs.GetAll();
            foreach (var i in songs)
            {
                SongDTO newSongDTO = new SongDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    Path = i.Path,
                    Singer = i.Singer,
                    UserName = i.UserName,
                    Genre = i.Genre
                };
                songsDTO.Add(newSongDTO);
            }
            return songsDTO;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
