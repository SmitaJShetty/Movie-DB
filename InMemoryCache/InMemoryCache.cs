using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using com.Cache;
using com.Entities;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Collections.Concurrent;
using com.CustomExceptions;
using System.Data.Objects;
using System.Diagnostics;

namespace com.InMemoryCache
{
    /// <summary>
    /// This class is a placeholder for a proper cache such as Redis or a db such as Mongo
    /// InMemoryCache implementation is not a scalable option
    /// </summary>
    public class InMemoryCache : ICache
    {
        private static ConcurrentDictionary<int?,Movie> MovieTable = null;
        
        static InMemoryCache()
        {
            MovieTable = new ConcurrentDictionary<int?,Movie>();
           
        }

        public void Create(Movie Movie)
        {
            if (Movie.MovieId.HasValue)
            {
                if (!MovieTable.ContainsKey(Movie.MovieId))
                {
                    if (MovieTable.TryAdd(Movie.MovieId, Movie))
                    {
                        Trace.Write("Add of Movie " + Movie.Title + " failed.");
                    }
                    else
                    {
                        throw new CreateNewMovieFailedException("New movie creation failed.");
                    }
                }
                else
                {
                    throw new NewMovieAlreadyExistsException();
                }
            }
        }

        /// <summary>
        /// Switch Ids, swap other attributes of the movie db
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Movie"></param>
        public void Update(int Id,Movie Movie)
        {
            if (Movie!=null)
            {
                if (Movie.MovieId.HasValue)
                {
                    if (MovieTable.ContainsKey(Id))
                    {
                        try
                        {
                            Movie.MovieId = Id;

                            if (MovieTable.TryUpdate(Id, Movie, MovieTable[Movie.MovieId]))
                            {
                                Trace.Write("Update of movie" + Movie.Title + " failed.");
                            }
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    else {
                        throw new MovieDoesNotExistException();
                    }

                }
            }          
        }

        public List<Movie> SearchMovies(SearchObject SrchObject)
        {
            List<Movie> movies = null;
            IQueryable<Movie> query=null;
            
            try
            {
                query = GenerateQueryFromValues(SrchObject);
                movies= query.AsEnumerable().ToList();
            }
            catch {
                throw;
            }

            return movies;
        }

        private IQueryable<Movie> GenerateQueryFromValues(SearchObject SObject)
        {
            string leftOperand = SObject.LeftOperand;
            IQueryable<Movie> query = null;

            if (leftOperand.Trim().ToLower().StartsWith("movieid")
                ||leftOperand.Trim().ToLower().StartsWith("releasedate")
                ||leftOperand.Trim().ToLower().StartsWith("rating"))
            {
                query =MovieTable.Values.Cast<Movie>().AsQueryable().Where(SObject.LeftOperand + SObject.Operator + SObject.RightOperand);
            }
            else
            {
                query = MovieTable.Values.Cast<Movie>().AsQueryable().Where(SObject.LeftOperand + SObject.Operator + "@0", SObject.RightOperand);
            }

            return query;
        }

        public List<Movie> GetAllMovies()
        {           
          return MovieTable.Values.ToList();
        }

        /// <summary>
        /// Gets a single movie based on Id.
        /// If no movie is found in the cache, a null is returned.
        /// </summary>
        /// <param name="MovieId"></param>
        /// <returns></returns>
        public Movie GetMovieById(int MovieId)
        {
            Movie foundMovie = null;

            if (MovieTable.ContainsKey(MovieId))
            {
                foundMovie = MovieTable[MovieId];
            }

            return foundMovie;
        }

        /// <summary>
        /// SortQuery of the form: "ColumnName ASC|DESC"
        /// </summary>
        /// <param name="SortQuery"></param>
        /// <returns></returns>
        public List<Movie> GetSortedByColumn(string SortQuery)
        {
          return  MovieTable.Values.AsQueryable().OrderBy(SortQuery).ToList();
        } 

        public void Invalidate()
        {
            MovieTable.Clear();            
        }

        public void ReplenishCacheFromSource(List<Movie> Movies)
        {
            foreach (Movie movie in Movies)
            {
                MovieTable.TryAdd(movie.MovieId, movie);
            }
        }
    }
    
}
