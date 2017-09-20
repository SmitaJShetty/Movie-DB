using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Entities;
using System.Collections.ObjectModel;

namespace com.Cache
{
    public interface ICache
    {
        void Create(Movie Movie);
        void Update(int Id,Movie Movie);       
        List<Movie> GetAllMovies();
        Movie GetMovieById(int MovieId);
        List<Movie> GetSortedByColumn(string SortQuery);
        List<Movie> SearchMovies(SearchObject SO);
        void Invalidate();
        void ReplenishCacheFromSource(List<Movie> Movies);
       
    }
}
