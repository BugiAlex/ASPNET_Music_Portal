using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using System.Collections.Generic;
using MusicPortal.BLL.Infrastructure;
using MusicPotal.DAL.Interfaces;
using MusicPotal.DAL.Models;

namespace MusicPortal.BLL.Services
{
    public class GenreService: IGenreService
    {
        IUnitOfWork db { get; set; }
        public GenreService(IUnitOfWork uow)
        {
            this.db = uow;
        }
        public void CreateGenre(GenreDTO genreDto)
        {
            Genre newGenre = new Genre
            {
                Id = genreDto.Id,
                Name = genreDto.Name            
            };
            db.Genres.Create(newGenre);
            db.Save();
        }
        public void UpdateGenre(GenreDTO genreDto)
        {
            Genre updateGenre = db.Genres.Get(genreDto.Id);
            updateGenre.Name = genreDto.Name;
            db.Genres.Update(updateGenre);
            db.Save();
        }
        public void DeleteGenre(int id)
        {
            db.Genres.Delete(id);
            db.Save();
        }
        public GenreDTO GetGenre(int id)
        {
            var genre = db.Genres.Get(id);
            if (genre == null)
                throw new ValidationException("Wrong user!", "");
            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
        public IEnumerable<GenreDTO> GetGenres()
        {
            List<GenreDTO> genresDTO = new List<GenreDTO>();
            var genres = db.Genres.GetAll();
            foreach (var i in genres)
            {
                GenreDTO newGenreDTO = new GenreDTO
                {
                    Id = i.Id,
                    Name = i.Name
                };
                genresDTO.Add(newGenreDTO);
            }
            return genresDTO;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
