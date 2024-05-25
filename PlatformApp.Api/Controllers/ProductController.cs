using Microsoft.AspNetCore.Mvc;
using PlatformApp.Api.Models;
using PlatformApp.Service.Entities;
using PlatformApp.Service.Services;

namespace PlatformApp.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController( IProductService _productService )
        {
            this.productService = _productService;
        }
        [HttpGet]
        [Route( "" )]
        public async Task<IActionResult> Get()
        {
            return Ok( await productService.GetProducts( true ) );
        }
        [HttpGet]
        [Route( "{id}" )]
        public async Task<IActionResult> GetById( int id )
        {
            return Ok( await productService.GetProductById( id ) );
        }
        [HttpGet]
        [Route( "Customer/{customerId}" )]
        public async Task<IActionResult> GetCustomerId( int customerId )
        {
            return Ok( await productService.GetProductByCustomer( customerId ) );
        }
        [HttpPost]
        [Route( "Remove" )]
        public async Task<IActionResult> RemoveProduct( ProductModel model )
        {
            return Ok( await productService.RemoveProduct( model.ProductId.Value ) );
        }
        [HttpPost]
        [Route( "" )]
        public async Task<IActionResult> AddProduct( ProductModel model )
        {
            var product = new Product
            {
                CustomerId = model.CustomerId.Value,
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice.Value
            };
            return Ok( await productService.AddProduct( product ) );
        }

        [HttpPost]
        [Route( "Update" )]
        public async Task<IActionResult> UpdateProduct( ProductModel model )
        {
            var product = new Product
            {
                ProductId=model.ProductId.Value,
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice.Value
            };
            return Ok( await productService.UpdateProduct( product ) );
        }
    }
}
