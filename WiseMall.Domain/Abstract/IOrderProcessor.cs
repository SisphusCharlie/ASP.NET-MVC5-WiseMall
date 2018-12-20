using WiseMall.Domain.Entities;

namespace WiseMall.Domain.Abstract
{
    public interface IOrderProcessor
    {

        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
