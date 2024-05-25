using Microsoft.EntityFrameworkCore;
using PlatformApp.Service.DBContext;
using PlatformApp.Service.Services;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlatformAppDBContext>( options => options.UseSqlServer( builder.Configuration.GetConnectionString( "PlatformAppDBConnection" ) ) );
var app = builder.Build();
app.UseCors(
    x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed( origin => true ).AllowCredentials()
);


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
