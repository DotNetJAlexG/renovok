using CheckoutKata.Repository;
using CheckoutKata.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutKata.Controllers
{
    public class CartItemController : ApiController
    {
        IOnlineStoreRepository _repo;
        ICartTotaller _totaller;

        public CartItemController() : this(new OnlineStoreRepository(), new CartTotaller())
        {
            // this constructor wouldn't normally be needed; 
            // an IOC container like Ninject would handle this.
        }

        public CartItemController(IOnlineStoreRepository repo, ICartTotaller totaller)
        {
            _repo = repo;
            _totaller = totaller;
        }

        [HttpGet]
        [Route("api/cart/{cartId}/item/{sku}")]
        public IHttpActionResult Get(string cartId, string sku)
        {
            Guid result;
            if (Guid.TryParse(cartId, out result))
            {
                if (!String.IsNullOrEmpty(sku))
                {
                    return Ok(_repo.GetCartItemBySku(result, sku));
                }
            }
            return Content(HttpStatusCode.BadRequest, "Bad Request");
        }

        [HttpPost]
        [Route("api/cart/{cartId}/item")]
        public IHttpActionResult Post(string cartId, string sku, string price, int stockItemId)
        {
            Guid result;
            if (Guid.TryParse(cartId, out result))
            {
                if (!String.IsNullOrEmpty(sku))
                {
                    var itemQ = _repo.GetCartItemBySku(result, sku);
                    var item = new GetCartItemBySku_Result();
                    if (!itemQ.Any())
                    {
                        item.CartId = result;
                        item.SKU = sku;
                        item.StockItemId = stockItemId;
                        item.Quantity = 1;
                    }
                    else
                    {
                        item = itemQ.First();
                    }
                    
                    // total this line item + consider offers
                    item = _totaller.DoWork(item);
                    return Ok(_repo.UpsertCartItem(item.CartId, item.SKU, item.Quantity, item.LineItemTotal));
                }
            }
            return Content(HttpStatusCode.BadRequest, "Bad Request");
        }

        [HttpPut]
        [Route("api/cart/{cartId}/item/{sku}")]
        public IHttpActionResult Put(string cartId, string sku, [FromBody]int quantity)
        {
            Guid result;
            if (Guid.TryParse(cartId, out result))
            {
                if (!String.IsNullOrEmpty(sku))
                {
                    var item = _repo.GetCartItemBySku(result, sku).First();
                    // total this line item + consider offers
                    item = _totaller.DoWork(item);
                    return Ok(_repo.UpsertCartItem(result, sku, quantity, item.LineItemTotal));
                }
            }
            return Content(HttpStatusCode.BadRequest, "Bad Request");
        }

        [HttpDelete]
        [Route("api/cart/{cartId}/item/{sku}")]
        public IHttpActionResult Delete(string cartId, string sku)
        {
            Guid result;
            if (Guid.TryParse(cartId, out result))
            {
                if (!String.IsNullOrEmpty(sku))
                {
                    return Ok(_repo.DeleteCartItem(result, sku));
                }
            }
            return Content(HttpStatusCode.BadRequest, "Bad Request");
        }
    }
}
