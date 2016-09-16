using CheckoutKata.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutKata.Controllers
{
    public class OfferController : ApiController
    {
        IOnlineStoreRepository _repo;

        public OfferController() : this(new OnlineStoreRepository())
        {
            // this constructor wouldn't normally be needed; 
            // an IOC container like Ninject would handle this.
        }

        public OfferController(IOnlineStoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("api/offers")]
        public IHttpActionResult Get()
        {
            var result = _repo.GetOffers();
            return Ok(result);
        }
    }
}
