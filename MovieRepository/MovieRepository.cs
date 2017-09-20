using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.Entities;
using com.Store;

namespace com.MovieRepository
{
    public class MovieRepository:IMovieRepository
    {
        IStore store = null;

        public MovieRepository(IStore Store)
        {
            store = Store; 
        }

        public void CreateMovie(Movie Movie)
        {   
            store.Create(Movie);
        }

        public void UpdateMovie(int Id,Movie Movie)
        {
            store.Update(Id,Movie);     
        }

        public List<Movie> GetMovies()
        {
            List<Movie> results = store.GetAllMovies();
            return results;
        }

        public List<Movie> GetSortedBy(string SortQuery)
        {
            List<Movie> results = store.GetSortedByColumn(SortQuery);   
            return results;
        }

        public List<Movie> SearchBy(SearchObject SO)
        {
            List<Movie> results = store.SearchMovies(SO);
            return results;
        }
            
        public Movie GetMovieById(int MovieId)
        {
            return store.GetMovieById(MovieId);
        }
    }
}
