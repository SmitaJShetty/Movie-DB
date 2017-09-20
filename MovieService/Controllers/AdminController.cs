using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using com.Store;
using com.Cache;

namespace MovieService.Controllers
{
    public class AdminController : ApiController
    {
        IStore store= null;

        public AdminController(IStore Store)
        {
            store = Store ;
        }

        [Route("api/admin/Refreshcache")]
        [HttpPost]
        public void InvalidateAndReplenish()
        {
            store.InvalidateCache();
            store.ReplenishCacheFromSource();
        }
    }
}
