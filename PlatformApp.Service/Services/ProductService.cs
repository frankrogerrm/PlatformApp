using Microsoft.EntityFrameworkCore;
using PlatformApp.Service.DBContext;
using PlatformApp.Service.Entities;
using System;

namespace PlatformApp.Service.Services
{
    public interface IProductService
    {
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetProductByCustomer( int customerId );
        Task<List<Product>> GetProducts( bool onlyActives = false);
        Task<Product> RemoveProduct( int productId );
        Task<Product> AddProduct( Product product );
        Task<Product> UpdateProduct( Product product );
    }
    public class ProductService : IProductService
    {
        private readonly PlatformAppDBContext dbContext;
        public ProductService( PlatformAppDBContext dbContext )
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> GetProductById( int productId )
        {
            return await dbContext.Products.Where( x => x.ProductId == productId ).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductByCustomer( int customerId )
        {
            var result = await (from p in dbContext.Products
                                join c in dbContext.Customers on p.CustomerId equals c.CustomerId
                                where p.Status && c.CustomerId.Equals(customerId)
                                select new Product
                                {
                                    CreatedDate = p.CreatedDate,
                                    UpdatedDate = p.UpdatedDate,
                                    ProductPrice = p.ProductPrice,
                                    ProductDescription = p.ProductDescription,
                                    ProductName = p.ProductName,
                                    CustomerId = p.CustomerId,
                                    Status = p.Status,
                                    Customer = c,
                                    ProductId = p.ProductId
                                }).ToListAsync();
            return result;
        }
        public async Task<List<Product>> GetProducts( bool onlyActives = false)
        {
            var result = await (from p in dbContext.Products
                                join c in dbContext.Customers on p.CustomerId equals c.CustomerId
                                where (!onlyActives && 1 == 1) || (onlyActives && p.Status)
                                select new Product
                                {
                                    CreatedDate = p.CreatedDate,
                                    UpdatedDate = p.UpdatedDate,
                                    ProductPrice = p.ProductPrice,
                                    ProductDescription = p.ProductDescription,
                                    ProductName = p.ProductName,
                                    CustomerId = p.CustomerId,
                                    Status = p.Status,
                                    Customer = c,
                                    ProductId = p.ProductId
                                }).ToListAsync();
            return result;
        }
        public async Task<Product> RemoveProduct(int productId )
        {
            var model = await dbContext.Products.FirstOrDefaultAsync( x => x.ProductId == productId );
            if( model != null )
            {
                model.Status = false;
                dbContext.Update( model );
                dbContext.SaveChanges();
            }
            return model;
        }

        public async Task<Product> AddProduct( Product product )
        {
            product.Status = true;
            product.CreatedDate= DateTime.Now;
            product.UpdatedDate= DateTime.Now;
            await dbContext.AddAsync( product );
            dbContext.SaveChanges();
            product.Customer = await dbContext.Customers.FirstOrDefaultAsync( x => x.CustomerId.Equals( product.CustomerId ) );
            return product;
        }

        public async Task<Product> UpdateProduct( Product product )
        {
            var model = await dbContext.Products.FirstOrDefaultAsync( x => x.ProductId == product.ProductId );
            model.ProductName = product.ProductName;
            model.ProductDescription = product.ProductDescription;
            model.ProductPrice = product.ProductPrice;
            model.UpdatedDate = DateTime.Now;

            dbContext.Update( model );
            dbContext.SaveChanges();
            product.Customer = await dbContext.Customers.FirstOrDefaultAsync( x => x.CustomerId.Equals( product.CustomerId ) );
            return product;
        }
    }
}
