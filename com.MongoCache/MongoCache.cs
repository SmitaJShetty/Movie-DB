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
        private string _moviedbName;
        private string _movieCollectionName;

        public MongoCache()
        {
            _mongoConnector = new MongoConnector();
            _moviedbName = "movie-db";
            _movieCollectionName = "movies";            
        }

        public void Create(Movie movie)
        {
            _mongoConnector.AddDocument(_moviedbName, _movieCollectionName, movie);
        }

        public void Update(int Id, Movie movie)
        {
            _mongoConnector.UpdateMovieAsync(_moviedbName, _movieCollectionName, Id, movie);
        }

        public List<Movie> GetAllMovies()
        {
          return  _mongoConnector.GetAllDocuments(_moviedbName, _movieCollectionName).Result;
        }

        public Movie GetMovieById(int MovieId)
        {
            var collection = _mongoConnector.GetCollection(_moviedbName, _movieCollectionName);            
            return _mongoConnector.GetDocumentByMovieId(collection,MovieId);
        }

        public List<Movie> GetSortedByColumn(string SortQuery)
        {
            throw new NotImplementedException();
        }
        
        public List<Movie> SearchMovies(SearchObject SO)
        {
            _mongoConnector.SearchMovies(_moviedbName,_movieCollectionName);
        }

        public void Invalidate()
        { throw new NotImplementedException(); }

        public void ReplenishCacheFromSource(List<Movie> Movies)
        { throw new NotImplementedException(); }

    }
}
