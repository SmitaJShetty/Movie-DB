using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MovieService.Tests
{
    [TestClass]
    public class MovieController_Test
    {
        [TestMethod]
        public void Constructor_Should_Create_A_Valid_NonNull_Object()
        {

        }

        [TestMethod]
        public void Constructor_Should_Create_A_Valid_Object_With_Valid_Properties()
        { }

        [TestMethod]
        public void GetMoviesById_Should_Return_Result_With_200_For_Valid_Movie()
        { 
        
        }

        [TestMethod]
        public void GetMovieById_Should_Return_BadRequest_For_Invalid_Movie()
        { }

        [TestMethod]
        public void GetMovieById_Should_Return_Ok_For_Valid_Movie_With_MovieContent_InResponse()
        { 
            
        }

        [TestMethod]
        public void GetMovies_Should_Return_NotFound_For_Empty_Result()
        { }

        [TestMethod]
        public void GetMovies_Should_Return_OkResult_For_NonEmptyResult()
        { 
        
        }

        [TestMethod]
        public void GetMovies_Should_ThrowException_For_ErroneousCase()
        { }

        [TestMethod]
        public void CreateMovie_Should_Return_Ok_For_Valid_Input()
        { }

        [TestMethod]
        public void CreateMovie_Should_Return_BadRequest_For_Empty_Id()
        { }

        [TestMethod]
        public void CreateMovie_Should_Return_BadRequest_For_Empty_Title()
        { 
        
        }

        [TestMethod]
        public void UpdateMovie_Should_Return_BadRequest_For_Empty_Title()
        { }

        [TestMethod]
        public void UpdateMovie_Should_Return_BadRequest_For_Empty_Id()
        { }

        [TestMethod]
        public void UpdateMovie_Should_Return_OKResult_For_Valid_Movie()
        { }

        [TestMethod]
        public void UpdateMovie_Should_Throw_Exception_For_Erroneous_Case()
        { }

        [TestMethod]
        public void SortMoviesBy_Should_Return_OK_Result_For_Successfull_Query()
        { }

        [TestMethod]
        public void SortMoviesBy_Should_Return_NotFound_Result_For_Empty_Return_Data()
        { }

        [TestMethod]
        public void SortMoviesBy_Should_Return_BadRequest_Empty_QueryString()
        { }

        [TestMethod]
        public void SortMoviesBy_Should_Return_Sorted_By_Column_For_Successfull_Query()
        { }

        [TestMethod]
        public void SearchMovies_Should_Return_Searched_Entity_For_Successfull_Query()
        { }

        [TestMethod]
        public void SearchMovies_Should_Return_OKResult_For_Successfull_Query()
        { }

        [TestMethod]
        public void SearchMovies_Should_Return_NotFound_For_EmptyResult()
        { }

        [TestMethod]
        public void SearchMovies_Should_Return_BadRequest_For_Invalid_SearchQuery()
        { }

    }
}
