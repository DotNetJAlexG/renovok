using CheckoutKata.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutKata.Controllers
{
    public class CartController : ApiController
    {
        IOnlineStoreRepository _repo;

        public CartController() : this(new OnlineStoreRepository())
        {
            // this constructor wouldn't normally be needed; 
            // an IOC container like Ninject would handle this.
        }

        public CartController(IOnlineStoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("api/cart/{cartId?}")]
        public IHttpActionResult Get(string cartId)
        {
            Guid result;
            if (Guid.TryParse(cartId, out result)) {
                return Ok(_repo.GetCartByCartId(result));
            }
            // return empty cart
            return Ok(new List<GetCartByCartId_Result>());
        }

        [HttpGet]
        [Route("api/cart/new")]
        public IHttpActionResult Get()
        {
            return Ok(Guid.NewGuid());
        }
    }
}
