using AppServices.CustomerBankInfos;
using AppServices.CustomerBankInfos.Interface;
using AppServices.Customers;
using AppServices.Customers.Interface;
using AppServices.Orders;
using AppServices.Orders.Interface;
using AppServices.Portfolios;
using AppServices.Portfolios.Interface;
using AppServices.Products;
using AppServices.Products.Interface;
using DomainServices.CustomerBankInfos;
using DomainServices.CustomerBankInfos.Interface;
using DomainServices.Customers;
using DomainServices.Customers.Interface;
using DomainServices.Orders;
using DomainServices.Orders.Interface;
using DomainServices.Portfolios;
using DomainServices.Portfolios.Interface;
using DomainServices.Products;
using DomainServices.Products.Interface;
using EntityFrameworkCore.UnitOfWork.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FeatureContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddTransient<ICustomerBankInfoService, CustomerBankInfoService>();
builder.Services.AddTransient<ICustomerBankInfoAppService, CustomerBankInfoAppService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductAppService, ProductAppService>();
builder.Services.AddTransient<IPortfolioService, PortfolioService>();
builder.Services.AddTransient<IPortfolioAppService, PortfolioAppService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderAppService, OrderAppService>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("AppServices"));
builder.Services.AddAutoMapper(Assembly.Load("AppServices"));
builder.Services.AddUnitOfWork<FeatureContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
