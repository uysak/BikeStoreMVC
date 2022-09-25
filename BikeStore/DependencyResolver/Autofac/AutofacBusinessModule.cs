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

            builder.RegisterType<BrandRepository>().As<IBrandRepository>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<OrderItemRepository>().As<IOrderItemRepository>().SingleInstance();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<StaffRepository>().As<IStaffRepository>().SingleInstance();
            builder.RegisterType<StockRepository>().As<IStockRepository>().SingleInstance();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>().SingleInstance();
            builder.RegisterType<ImageRepository>().As<IImageRepository>().SingleInstance();

        }
    }
}