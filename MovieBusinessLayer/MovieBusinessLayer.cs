using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.MovieRepository;
using com.Entities;

namespace com.MovieBusinessLayer
{
    public class MovieBusinessLayer
    {
        private IMovieRepository _repository = null;

        public MovieBusinessLayer(IMovieRepository Repository)
        {
            _repository = Repository;
        }

        public List<Movie> GetAllMovies()
        {
           return _repository.GetMovies();
        }

        public Movie GetMovieById(int MovieId)
        {
            return _repository.GetMovieById(MovieId);
        }

        public void CreateMovie(Movie NewMovie)
        {            
            _repository.CreateMovie(NewMovie);
        }

        public void UpdateMovie(int Id,Movie ToUpdateMovie)
        {
            _repository.UpdateMovie(Id,ToUpdateMovie);
        }

        public List<Movie> SearchMovie(SearchObject So)
        {
           return _repository.SearchBy(So);
        }

        public List<Movie> GetSortedBy(string SortQuery)
        {
            return _repository.GetSortedBy(SortQuery);
        }
    }
}
