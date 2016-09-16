using CheckoutKata.Models;
using CheckoutKata.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutKata.Service
{
    public class SpecialOfferProvider : ITransformProvider
    {
        IOnlineStoreRepository _repo;

        public SpecialOfferProvider()
        {
            // this constructor wouldn't normally be needed; 
            // an IOC container like Ninject would handle this.
            _repo = new OnlineStoreRepository();
        }

        public GetCartItemBySku_Result Transform(GetCartItemBySku_Result item)
        {
            var offers = _repo.GetOffers();
            foreach (var offer in offers)
            {
                if (item.StockItemId == offer.StockId)
                {
                    item.LineItemTotal = 0m;
                    int q = item.Quantity;
                    while (q >= offer.OfferQuantity)
                    {
                        item.LineItemTotal += offer.OfferPrice;
                        q -= offer.OfferQuantity;
                    }
                    // get remainder
                    item.LineItemTotal += q * item.Price;
                }
            }
            return item;
        }
    }
}