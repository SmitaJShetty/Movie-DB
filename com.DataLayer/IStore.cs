using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Entities;

namespace com.Store
{
    public interface IStore
    {
        void Create(Movie M);
        void Update(int Id,Movie M);
        List<Movie> SearchMovies(SearchObject SO);
        List<Movie> GetAllMovies();
        Movie GetMovieById(int MovieId);
        List<Movie> GetSortedByColumn(string SortColumn);
        void InvalidateCache();
        void ReplenishCacheFromSource();
    }
}
