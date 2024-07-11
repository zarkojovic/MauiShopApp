using Microsoft.EntityFrameworkCore;
using WebAPI.Constants;
using WebAPI.Data;
using WebAPI.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(DatabaseConstants.GroceryConnectionStringKey)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mastersGroup = app.MapGroup("/masters").AllowAnonymous();

mastersGroup.MapGet("/categories", async (DataContext dataContext) =>
    await dataContext.Categories.AsNoTracking().ToArrayAsync()
);

mastersGroup.MapGet("/offers", async (DataContext dataContext) =>
    await dataContext.Offers.AsNoTracking().ToArrayAsync()
);

app.MapGet("/popular-products", async (DataContext dataContext,int? count) =>
{
    if (!count.HasValue || count <= 0)
        count = 6;


    var random = await dataContext.Products
                        .AsNoTracking()
                        .OrderBy(p => Guid.NewGuid())
                        .Take(count.Value)
                        .Select(Product.DtoSelector)
                        .ToArrayAsync();

    return TypedResults.Ok(random);
}
);

app.MapGet("/categories/{categoryId}/products",async(DataContext dataContext, short categoryId) =>
{
    var products = await dataContext.Products
        .Include(p => p.Category)
        .AsNoTracking()
        .Where(p => p.CategoryId == categoryId || p.Category.ParentId == categoryId)
        .Select(Product.DtoSelector)
        .ToArrayAsync();

    return TypedResults.Ok(products);
}
);


app.Run("https://localhost:5001");