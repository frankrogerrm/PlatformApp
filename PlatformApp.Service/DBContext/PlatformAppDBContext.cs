using Microsoft.EntityFrameworkCore;
using PlatformApp.Service.Entities;

namespace PlatformApp.Service.DBContext
{
    public class PlatformAppDBContext : DbContext
    {
        public PlatformAppDBContext( DbContextOptions<PlatformAppDBContext> options ) : base( options )
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Customer>().ToTable( "Customer" );
            modelBuilder.Entity<Product>().ToTable( "Product" );

            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Address = "Suite 405 352 Waelchi Mission, Bednarhaven, AK 15529",
                    FirstName = "Symone",
                    LastName = "Tobias",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = true,
                    CustomerId = 1
                },
                new Customer()
                {
                    Address = "17279 Herman Trail, Oberbrunnerland, VA 04806",
                    FirstName = "Josefina",
                    LastName = "Mayfield",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = true,
                    CustomerId = 2
                },
                new Customer()
                {
                    Address = "Suite 934 4384 Sean Trace, Port Carrolport, SC 53835",
                    FirstName = "Luke",
                    LastName = "Garrett",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = true,
                    CustomerId = 3
                },
                new Customer()
                {
                    Address = "Apt. 460 560 Powlowski Pike, New Shelaside, MN 74288-8673",
                    FirstName = "Santana",
                    LastName = "Bergeron",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = true,
                    CustomerId = 4
                },
                new Customer()
                {
                    Address = "169 McLaughlin Viaduct, Wisokyton, VA 74079",
                    FirstName = "Allen",
                    LastName = "Rollins",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = true,
                    CustomerId = 5
                } );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 1,
                    ProductName = "First Korg synthesizer",
                    ProductDescription = "synthesizer",
                    ProductId = 1,
                    ProductPrice = 10,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 1,
                    ProductName = "Full polyphonic preset synthesizers",
                    ProductDescription = "preset synthesizers",
                    ProductId = 2,
                    ProductPrice = 20,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 2,
                    ProductName = "Rhythm machine,",
                    ProductDescription = "First Product",
                    ProductId = 3,
                    ProductPrice = 30,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 2,
                    ProductName = "Motor Drive Duplicating Key Punch",
                    ProductDescription = "Key Punch",
                    ProductId = 4,
                    ProductPrice = 40,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 3,
                    ProductName = "First Korg synthesizer",
                    ProductDescription = "synthesizer",
                    ProductId = 5,
                    ProductPrice = 50,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 3,
                    ProductName = "Printing Card Proof Punch",
                    ProductDescription = "Proof punch",
                    ProductId = 6,
                    ProductPrice = 50,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 4,
                    ProductName = "Electric Accounting Machine",
                    ProductDescription = "Accounting Machine",
                    ProductId = 7,
                    ProductPrice = 10,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 4,
                    ProductName = "Alphabetic Tabulating model ",
                    ProductDescription = "Tabulating model ",
                    ProductId = 8,
                    ProductPrice = 40,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 5,
                    ProductName = "IBM 870 Non-transmitting Typewriter",
                    ProductDescription = "TypeWriter",
                    ProductId = 9,
                    ProductPrice = 30,
                    Status = true
                },
                new Product()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CustomerId = 5,
                    ProductName = "Aircraft and naval fire-control instruments",
                    ProductDescription = "fire-control instruments",
                    ProductId = 10,
                    ProductPrice = 20,
                    Status = true
                } );

        }
    }
}
