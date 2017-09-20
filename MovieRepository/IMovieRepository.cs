using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Entities;

namespace com.MovieRepository
{
    public interface IMovieRepository
    {
        void CreateMovie(Movie M);
        void UpdateMovie(int Id,Movie M);
        List<Movie> GetMovies();
        List<Movie> GetSortedBy(string SortByColumn);
        List<Movie> SearchBy(SearchObject So);
        Movie GetMovieById(int MovieId);

    }
}
