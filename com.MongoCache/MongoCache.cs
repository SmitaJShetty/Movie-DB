using System;
using System.Collections.Generic;
using com.Cache;
using com.Entities;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Collections.Concurrent;
using System.Data.Objects;
using System.Diagnostics;

namespace com.MongoCache
{
    public class MongoCache:ICache
    {
        private MongoConnector _mongoConnector;
       
        public MongoCache()
        {
            _mongoConnector = new MongoConnector();
           // _mongoConnector.MongoClient();
        }

        public void Create(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int MovieId)
        {

            throw new NotImplementedException();
        }

        public List<Movie> GetSortedByColumn(string SortQuery)
        {
            throw new NotImplementedException();
        }


        public List<Movie> SearchMovies(SearchObject SO)
        { throw new NotImplementedException(); }

        public void Invalidate()
        { throw new NotImplementedException(); }

        public void ReplenishCacheFromSource(List<Movie> Movies)
        { throw new NotImplementedException(); }

    }
}
