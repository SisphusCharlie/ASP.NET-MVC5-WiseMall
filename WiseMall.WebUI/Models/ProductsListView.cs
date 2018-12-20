using System.Collections.Generic;
using WiseMall.Domain.Entities;

namespace WiseMall.WebUI.Models
{
    public class ProductsListViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}