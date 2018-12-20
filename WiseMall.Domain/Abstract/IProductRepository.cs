using System.Collections.Generic;
using WiseMall.Domain.Entities;

namespace WiseMall.Domain.Abstract
{
    public interface IProductRepository
    {

        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}