using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using com.Entities;
using System.Web.Http.ModelBinding;
using com.MovieBusinessLayer;
using MovieService.ModelBinder;

namespace MovieService.Controllers
{
    
    public class MovieController : ApiController
    {
        MovieBusinessLayer movieBLayer = null;
        
        public MovieController(MovieBusinessLayer MovieBLayer)
        {
            movieBLayer = MovieBLayer;
        }

        [Route("api/Movie/{query}")]
        [HttpGet]
        public IHttpActionResult GetSortedBy(String query=null)
        {
            List<Movie> movies = SortBy(query);          
            return Ok<List<Movie>>(movies);
        }

        [HttpGet]
        [Route("api/Movie/{id:int?}")]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = null;

            try
            {
                movie = movieBLayer.GetMovieById(id);

                if (movie == null) 
                {
                    NotFound();
                }
            }
            catch
            {
                throw;
            }

            return Ok<Movie>(movie);
        }

        [HttpGet]        
        [Route("api/Movie")]
        public IHttpActionResult GetMovies()
        {
            List<Movie> movies = null;
            try
            {
                movies = movieBLayer.GetAllMovies();

                if ((movies == null) || (movies.Count == 0))
                {
                    NotFound();
                }
            }
            catch
            {
                throw;
            }
           
            return Ok<List<Movie>>(movies);
        }

        [HttpPost]
        [Route("api/Movie")]
        public IHttpActionResult Post([FromBody] Movie Movie)
        {            
            try
            {
                if (!String.IsNullOrEmpty(Movie.Title))
                {
                    movieBLayer.CreateMovie(Movie);                      
                }
                else
                {
                    BadRequest("Movie Title is Empty.");
                }            
            }
            catch {
                throw;
            }

            return Ok();
        }

        [HttpPut]       
        [Route("api/movie/{id}")]
        public IHttpActionResult PutMovie([FromUri]string id, [FromBody] Movie Movie)
        {
            try
            {
                if (Movie.MovieId.HasValue)
                {
                    if (!String.IsNullOrEmpty(Movie.Title))
                    {
                        int Id = -1;

                        if (Int32.TryParse(id, out Id))
                        {
                            movieBLayer.UpdateMovie(Id, Movie);
                        }
                        else
                        {
                            BadRequest("Id of the movie to be updated has to be a numeric.");
                        }
                    }
                    else
                    {
                        BadRequest("Movie Title is invalid");
                    }
                }
                else
                {
                    BadRequest("Movie Id is invalid");
                }
            }
            catch
            {
                throw;
            }

            return Ok();
        }
               
        public List<Movie> SortBy(string SortQuery)
        {
            List<Movie> results=null;

            if (String.IsNullOrEmpty(SortQuery))
            {
                SortQuery = "Title ASC";
            }

            try
            {
                results = movieBLayer.GetSortedBy(SortQuery);

                if ((results == null) || (results.Count == 0))
                {
                    NotFound();
                }               
            }
            catch
            {
                throw;
            }

             return results;            
        }
        

        [Route("api/Movie/{Left}/{Oper}/{Right}")]
        [HttpGet]
        public IHttpActionResult SearchMovies(string Left,string Oper,string Right)
        {
            List<Movie> results = null;

            if ((Left == null) || (Oper == null) ||(Right==null))
            {
                return RedirectToRoute("MovieGet", new { controller="Movie"});
            }

            if(Oper.ToLower()=="gt")
            {
                Oper = ">";
            }
            if (Oper.ToLower() == "lt")
            {
                Oper = "<";
            }

            try {

                SearchObject so = new SearchObject( Left,Oper,Right );
                
                results = movieBLayer.SearchMovie(so);
                
                if((results==null) ||(results.Count==0))
                {
                    NotFound();
                }
            }
            catch {
                throw;
            }

            return Ok<List<Movie>>(results);
        }
    }
}
    