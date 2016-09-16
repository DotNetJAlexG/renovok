using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutKata.Repository
{
    public class OnlineStoreRepository : IOnlineStoreRepository
    {
        OnlineStoreEntities3 _db;

        public OnlineStoreRepository() : this(new OnlineStoreEntities3())
        {
            // this constructor wouldn't normally be needed; 
            // an IOC container like Ninject would handle this.
        }

        public OnlineStoreRepository(OnlineStoreEntities3 dbContext)
        {
            _db = dbContext;
        }

        public IEnumerable<GetCartByCartId_Result> GetCartByCartId(Guid id)
        {
            return _db.GetCartByCartId(id);
        }

        public IEnumerable<GetInventory_Result> GetInventory()
        {
            return _db.GetInventory();
        }

        public IEnumerable<GetOffers_Result> GetOffers()
        {
            return _db.GetOffers();
        }

        public IEnumerable<GetCartItemBySku_Result> GetCartItemBySku(Guid id, string sku)
        {
            return _db.GetCartItemBySku(id, sku);
        }

        public int UpsertCartItem(Guid id, string sku, int quantity, decimal lineitemtotal)
        {
            if (_db.GetCartItemBySku(id, sku).Count() > 0)
            {
                return _db.UpdateCartItem(id, sku, quantity, lineitemtotal);
            }
            else
            {
                return _db.InsertCartItem(id, sku, quantity, lineitemtotal);
            }
        }

        public int DeleteCartItem(Guid id, string sku)
        {
            return _db.DeleteCartItem(id, sku);
        }

    }
}