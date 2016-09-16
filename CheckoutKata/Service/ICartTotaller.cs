using CheckoutKata.Repository;

namespace CheckoutKata.Service
{
    public interface ICartTotaller
    {
        GetCartItemBySku_Result DoWork(GetCartItemBySku_Result lineItem);
    }
}