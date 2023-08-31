using MusicPortal.BLL.DTO;
using System;
using System.Collections.Generic;


namespace MusicPortal.BLL.Interfaces
{
    public interface IGenreService: IDisposable
    {
        void CreateGenre(GenreDTO teamDto);
        void UpdateGenre(GenreDTO teamDto);
        void DeleteGenre(int id);
        GenreDTO GetGenre(int id);
        IEnumerable<GenreDTO> GetGenres();
    }
}
