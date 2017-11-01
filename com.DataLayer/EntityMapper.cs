using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using com.Entities;
using com.CustomExceptions;

namespace com.Store
{
    public class EntityMapper
    {
        public List<Movie> ConvertToLocalEntities(IEnumerable<Movie> MovieData)
        {
            List<Movie> movies = new List<Movie>();

            foreach (Movie md in MovieData)
            {
                movies.Add(ConvertSingleSourceEntityToLocal(md));
            }

            return movies;
        }

        public Movie ConvertSingleSourceEntityToLocal(Movie MovieData)
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

        public List<Movie> ConvertToSourceEntities(IEnumerable<Movie> Movies)
        {
            List<Movie> movieData = new List<Movie>();

            foreach (Movie m in Movies)
            {
                movieData.Add(ConvertSingleLocalEntityToSource(m));
            }

            return movieData;
        }

        public Movie ConvertSingleLocalEntityToSource(Movie Movie)
        {
            Movie movieData = null;

            movieData = new Movie()
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
