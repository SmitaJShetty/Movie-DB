using System.Collections.Generic;
using com.Entities;
using com.Cache;

namespace com.Store
{
    public class Store:IStore
    {
        EntityMapper entityMapper = null;
        MovieDataSource movieDataSource = null;
        ICache cache = null;
              
        public Store(ICache Cache)
        {
            cache = Cache;
            entityMapper = new EntityMapper();
            movieDataSource = new ();
            ReplenishCacheFromSource();
            
        }

        /// <summary>
        /// Create updates both Source (MovieLibrary) as well as local cache
        /// </summary>
        /// <param name="Movie"></param>
        public void Create(Movie Movie)
        {
            try {
                int MovieId= movieDataSource.Create(entityMapper.ConvertSingleLocalEntityToSource(Movie));
                Movie.MovieId = MovieId;
                cache.Create(Movie);       
            }
            catch {

                throw;
            }
        }

        /// <summary>
        /// Update modifies both Source (MovieLibrary) as well as local cache
        /// </summary>
        /// <param name="Movie"></param>
        public void Update(int Id,Movie Movie)
        {
            if ((Movie != null) && (Movie.MovieId != -1))
            {
                UpdateSource(Id,Movie);
                cache.Update(Id,Movie);
            }
        }

        /// <summary>
        /// Query will be a clause such as where clause 
        /// Eg: Title = "ABC" And Rating In (5,4)
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public List<Movie> SearchMovies(SearchObject SO)
        {
            return cache.SearchMovies(SO);
        }

        /// <summary>
        /// If Cacche is empty, then replenish it from Movie source the first time
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            return cache.GetAllMovies();        
        }

        public Movie GetMovieById(int MovieId)
        {
            return cache.GetMovieById(MovieId);
        }

        public List<Movie> GetSortedByColumn(string SortColumn)
        {
            return cache.GetSortedByColumn(SortColumn);          
        }

        /// <summary>
        /// Switches ids so that moviedata can contain the movie to be updated
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Movie"></param>
        private void UpdateSource(int Id,Movie Movie)
        {
            try
            {
                // MovieData movieData = entityMapper.ConvertSingleLocalEntityToSource(Movie);
                Movie movieData = new Movie()
                {
                    MovieId = Id
                };
                movieDataSource.Update(movieData);
            }
            catch   
            {
                throw;
            }
        }

        public void ReplenishCacheFromSource()
        {
            List<Movie> movieData= movieDataSource.GetAllData();
            //List<Movie> movies = entityMapper.ConvertToLocalEntities(movieData);
            cache.ReplenishCacheFromSource(movieData);
        }

        public void InvalidateCache()
        {
            cache.Invalidate();
        }
    }
}
