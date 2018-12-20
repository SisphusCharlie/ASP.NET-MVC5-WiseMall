using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WiseMall.Domain.Abstract;
using WiseMall.Domain.Entities;
using WiseMall.WebUI.Models;

namespace WiseMall.WebUI.Controllers
{

    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 2;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        [OutputCache(Duration = 30)]
        public ViewResult List(string category, int page = 1)
        {

            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(viewModel);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
