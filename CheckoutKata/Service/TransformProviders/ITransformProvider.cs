using CheckoutKata.Models;
using CheckoutKata.Repository;
using System;
using System.Collections.Generic;

namespace CheckoutKata.Service
{
    public interface ITransformProvider
    {
        GetCartItemBySku_Result Transform(GetCartItemBySku_Result item);
    }
}