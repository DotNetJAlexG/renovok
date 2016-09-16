using System;
using System.Collections.Generic;

namespace CheckoutKata.Repository
{
    public interface IOnlineStoreRepository
    {
        IEnumerable<GetCartByCartId_Result> GetCartByCartId(Guid id);

        IEnumerable<GetInventory_Result> GetInventory();

        IEnumerable<GetOffers_Result> GetOffers();

        IEnumerable<GetCartItemBySku_Result> GetCartItemBySku(Guid id, string sku);

        int UpsertCartItem(Guid id, string sku, int quantity, decimal lineitemtotal);

        int DeleteCartItem(Guid id, string sku);

    }
}