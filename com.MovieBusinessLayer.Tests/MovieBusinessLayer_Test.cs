using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MBLayer= com.MovieBusinessLayer;
using System.Collections.Generic;
using com.MovieRepository;
using com.Entities;
using System.Linq;

namespace com.MovieBusinessLayer_Tests
{
    [TestClass]
    public class MovieBusinessLayer_Test
    {      
        [TestMethod]
        public void GetAllMovies_Should_Return_List_Of_Movies()
        {
            List<Movie> fakeMovies=new List<Movie>(){
            new Movie(){ MovieId=1,Title="First Movie",Rating=2},
            new Movie(){MovieId=2,Title="Second Movie",Rating=1},
            new Movie(){MovieId=3,Title="Third Movie",Rating=4}
            };
            Mock<IMovieRepository> mockRepository=new Mock<IMovieRepository>();
            mockRepository.Setup(m => m.GetMovies()).Returns(fakeMovies);

            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            List<Movie> actual= movieBLayer.GetAllMovies();

            Assert.AreEqual(actual.Count, fakeMovies.Count);           
        }

        [TestMethod]
        public void GetAllMovies_Should_Return_Null_For_Empty_MovieList()
        {
            List<Movie> fakeMovies = new List<Movie>();
            Mock<IMovieRepository> mockRepository = new Mock<IMovieRepository>();
            mockRepository.Setup(m => m.GetMovies()).Returns(fakeMovies);
            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            List<Movie> actual= movieBLayer.GetAllMovies();

            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void GetMovieById_Should_Return_NUll_For_Movie_For_Invalid_Input()
        {
            List<Movie> fakeMovies = new List<Movie>(){
            new Movie(){ MovieId=1,Title="First Movie",Rating=2},
            new Movie(){MovieId=2,Title="Second Movie",Rating=1},
            new Movie(){MovieId=3,Title="Third Movie",Rating=4}
            };
            
            Mock<IMovieRepository> mockRepository = new Mock<IMovieRepository>();
            mockRepository.Setup(m => m.GetMovies()).Returns(fakeMovies);
            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            Movie actual = movieBLayer.GetMovieById(4);

            Assert.IsNull(actual);
            
        }

        [TestMethod]
        public void GetMovieById_Should_return_Valid_MovieObject_For_Valid_SearcParameters()
        {
            List<Movie> fakeMovies = new List<Movie>(){
            new Movie(){ MovieId=1,Title="First Movie",Rating=2},
            new Movie(){MovieId=2,Title="Second Movie",Rating=1},
            new Movie(){MovieId=3,Title="Third Movie",Rating=4}
            };

            bool called=false;

            Mock<IMovieRepository> mockRepository = new Mock<IMovieRepository>();
            mockRepository.Setup(m => m.GetMovieById(It.IsAny<int>())).Callback(()=>called=true);

            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            Movie actual = movieBLayer.GetMovieById(3);

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void CreateMovie_Should_Be_Invoked()
        {          
            Movie createdMovie=null;
            Mock<IMovieRepository> mockRepository = new Mock<IMovieRepository>();
          
            mockRepository.Setup(m => m.CreateMovie(It.IsAny<Movie>())).Callback<Movie>((m) => {
                createdMovie = m;
            });

            string title = "New Movie";
            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            movieBLayer.CreateMovie(new Movie(){Title=title});

            Assert.AreEqual(createdMovie.Title, title);
        }

        [TestMethod]
        public void UpdateMovie_Should_Be_Invoked()
        {
            bool called = false;
           
            Mock<IMovieRepository> mockRepository=new Mock<IMovieRepository>();
            mockRepository.Setup(m=>m.UpdateMovie(It.IsAny<int>(), It.IsAny<Movie>())).Callback(()=> called=true);
                       
            string title = "Updated Movie";
            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            movieBLayer.UpdateMovie(1, new Movie() { Title = title });
            Assert.IsTrue(called);

        }

        [TestMethod]
        public void SearchMovie_Should_Be_Invoked()
        {
            Mock<IMovieRepository> mockRepository = new Mock<IMovieRepository>();
            mockRepository.Setup(m => m.SearchBy(It.IsAny<SearchObject>())).Returns(new List<Movie>(){ 
             new Movie(){MovieId=1},
             new Movie(){MovieId=2}
            });

            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            List<Movie> actual= movieBLayer.SearchMovie(new SearchObject("MovieId","=", "1"));
            Assert.AreEqual(actual.Count, 2);

        }     

        [TestMethod]
        public void GetSortedBy_Should_Be_Invoked()
        {
            Mock<IMovieRepository> mockRepository = new Mock<IMovieRepository>();
            mockRepository.Setup(m => m.GetSortedBy(It.IsAny<string>())).Returns(new List<Movie>(){ 
             new Movie(){MovieId=1},
             new Movie(){MovieId=2}
            });

            MBLayer.MovieBusinessLayer movieBLayer = new MBLayer.MovieBusinessLayer(mockRepository.Object);
            List<Movie> actual = movieBLayer.GetSortedBy("MovieId Ascending");
            Assert.AreEqual(actual.ElementAt(0).MovieId,1);
        }            
    }
}
