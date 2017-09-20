using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.CustomExceptions;

namespace com.MovieRepository.Tests
{
    [TestClass]
    public class MovieRepository_test
    {
        [TestMethod]
        public void Constructor_Should_CreateInstance_AndShould_Assign_InternalStore()
        {
            
        }

        [TestMethod]
        public void CreateMovie_Should_Add_ANew_MovieToStore()
        { }

        [TestMethod]
        public void UpdateMovie_Should_UpdateMovie_InStore_If_ItExists()
        { }

        [TestMethod]
        [ExpectedException(typeof(MovieDoesNotExistException))]
        public void UpdateMovie_Should_Throw_MovieDoesntExistsException_IFMovieDoesntExist()
        { }

        [TestMethod]
        public void GetMovies_Should_Return_AllMovies()
        { 
        
        }
        [TestMethod]
        public void GetSortedBy_Should_Return_Sorted_List()
        { }

        [TestMethod]
        public void SearchBy_Should_Return_SearchedList()
        { }

        [TestMethod]
        public void GetMovieById_Should_Return_MovieForValiid_Id()
        { }

       [TestMethod]
        public void GetMovieById_Should_Return_NUllifMovie_DoesNOtExist()
        { 
            
        }
        
    }
}
