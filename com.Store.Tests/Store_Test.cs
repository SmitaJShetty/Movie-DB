using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesLibrary;
using System.Collections.Generic;
using com.Cache;
using com.Entities;
using Moq;

namespace com.Store.Tests
{
    [TestClass]
    public class Store_Test
    {
       [TestMethod]
        public void ReplenishCacheFromSource_Should_Invoke_CacheReplenish()
        {         
            Mock<ICache> mockCache = new Mock<ICache>();
            bool called = false;
            mockCache.Setup(m => m.ReplenishCacheFromSource(It.IsAny<List<Movie>>())).Callback(() =>
                {
                    called = true;
                }
            );

            Store store = new Store(mockCache.Object);
            store.ReplenishCacheFromSource();

            Assert.IsTrue(called);
        }     
    }
}
