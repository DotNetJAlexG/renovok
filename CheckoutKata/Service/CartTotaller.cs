using CheckoutKata.Models;
using CheckoutKata.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutKata.Service
{
    public class CartTotaller : ICartTotaller
    {
        List<ITransformProvider> _transformProviders = new List<ITransformProvider>();

        public CartTotaller()
        {
            // this constructor wouldn't normally be needed; 
            // an IOC container like Ninject would handle this.
            _transformProviders.Add(new CartCalculatorProvider());
            _transformProviders.Add(new SpecialOfferProvider());
        }

        public GetCartItemBySku_Result DoWork(GetCartItemBySku_Result lineItem)
        {
            foreach (var provider in _transformProviders)
            {
                lineItem = provider.Transform(lineItem);
            }
            return lineItem;
        }


    }
}