using Autofac;
using TTcms.BuildingBlocks.EventBus.Abstractions;
using TTcms.Services.Ordering.API.Application.Commands;
using TTcms.Services.Ordering.API.Application.Queries;
using TTcms.Services.Ordering.Domain.AggregatesModel.BuyerAggregate;
using TTcms.Services.Ordering.Domain.AggregatesModel.OrderAggregate;
using TTcms.Services.Ordering.Infrastructure.Idempotency;
using TTcms.Services.Ordering.Infrastructure.Repositories;
using System.Reflection;

namespace TTcms.Services.Ordering.API.Infrastructure.AutofacModules
{

    public class ApplicationModule
        : Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new OrderQueries(QueriesConnectionString))
                .As<IOrderQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BuyerRepository>()
                .As<IBuyerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
