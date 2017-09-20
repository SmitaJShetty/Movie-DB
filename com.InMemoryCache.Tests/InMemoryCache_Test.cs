using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.InMemoryCache;
using Moq;
using com.Entities;
using com.CustomExceptions;
using System.Collections.Generic;

namespace com.InMemoryCache.Tests
{
    [TestClass]
    public class InMemoryCache_Test
    {     

        [TestMethod]
        public void Create_Should_AddNewMovie_Without_Exceptions()
        {
            InMemoryCache cache = new InMemoryCache();
            Movie FakeMovie=new Movie(){
                MovieId=1,
                Title="New Movie"
            };

            cache.Create(FakeMovie);
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NewMovieAlreadyExistsException))]
        public void Create_Should_ThrowException_When_Movie_AlreadyExists()
        {
            InMemoryCache cache = new InMemoryCache();
            Movie FakeMovie1 = new Movie()
            {
                MovieId = 1,
                Title = "New Movie"
            };

            cache.Create(FakeMovie1);

            Movie FakeMovie2 = new Movie() { 
                MovieId =1,
                Title="New Movie"
            };

            cache.Create(FakeMovie2);
        }

        [TestMethod]
        public void INvalidate_Clears_Cache()
        {
            InMemoryCache cache = new InMemoryCache();
            cache.Create(new Movie() { MovieId=1,Title="New Movie"});

            cache.Invalidate();
            List<Movie> movies= cache.SearchMovies(new SearchObject("MovieId","=","1"));

            Assert.AreEqual(movies.Count, 0);
        }               
    }
}
