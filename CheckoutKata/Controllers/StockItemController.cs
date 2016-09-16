using CheckoutKata.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutKata.Controllers
{
    public class StockItemController : ApiController
    {
        IOnlineStoreRepository _repo;

        public StockItemController() : this(new OnlineStoreRepository())
        {
            // this constructor wouldn't normally be needed; 
            // an IOC container like Ninject would handle this.
        }

        public StockItemController(IOnlineStoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("api/inventory")]
        public IHttpActionResult Get()
        {
            var results = _repo.GetInventory();
            return Ok(results);
        }
    }
}
