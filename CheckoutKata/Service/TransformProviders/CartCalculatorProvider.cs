using CheckoutKata.Models;
using CheckoutKata.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutKata.Service
{
    public class CartCalculatorProvider : ITransformProvider
    {
        public Guid CartId { get; set; }

        public GetCartItemBySku_Result Transform(GetCartItemBySku_Result item)
        {
            item.LineItemTotal = item.Quantity * item.Price;
            return item;
        }
    }
}