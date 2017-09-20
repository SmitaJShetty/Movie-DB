using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using com.Entities;
using MoviesLibrary;
using com.CustomExceptions;

namespace com.Store
{
    public class EntityMapper
    {
        public List<Movie> ConvertToLocalEntities(IEnumerable<MovieData> MovieData)
        {
            List<Movie> movies = new List<Movie>();

            foreach (MovieData md in MovieData)
            {
                movies.Add(ConvertSingleSourceEntityToLocal(md));
            }

            return movies;
        }

        public Movie ConvertSingleSourceEntityToLocal(MovieData MovieData)
        {
            Movie movie = null;

            if  ((MovieData ==null) || (MovieData.MovieId < 1))
            {
                throw new InvalidSouceDataException();
            }
            else
            {
                movie = new Movie()
                {
                    Cast = MovieData.Cast.ToList(),
                    Classification = MovieData.Classification,
                    MovieId = MovieData.MovieId,
                    Rating = MovieData.Rating,
                    ReleaseDate = MovieData.ReleaseDate,
                    Title = MovieData.Title,
                    Genre = MovieData.Genre
                };
            }

            return movie;
        }

        public List<MovieData> ConvertToSourceEntities(IEnumerable<Movie> Movies)
        {
            List<MovieData> movieData = new List<MovieData>();

            foreach (Movie m in Movies)
            {
                movieData.Add(ConvertSingleLocalEntityToSource(m));
            }

            return movieData;
        }

        public MovieData ConvertSingleLocalEntityToSource(Movie Movie)
        {
            MovieData movieData = null;

            movieData = new MovieData()
            {
                Cast = Movie.Cast.ToArray(),
                Classification = Movie.Classification,
                Genre = Movie.Genre,
                Rating = Movie.Rating,
                ReleaseDate = Movie.ReleaseDate,
                Title = Movie.Title
            };

            return movieData;            
        }
    }
}
