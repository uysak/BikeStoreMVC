using System.Reflection;
using Autofac;
using System;
using BikeStore.Repository.Abstract;
using BikeStore.Repository.Concrete;
using Module = Autofac.Module;

namespace BikeStore.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<BrandRepository>().As<IBrandRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<OrderItemRepository>().As<IOrderItemRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<StaffRepository>().As<IStaffRepository>();
            builder.RegisterType<StockRepository>().As<IStockRepository>();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>();
        }
    }
}