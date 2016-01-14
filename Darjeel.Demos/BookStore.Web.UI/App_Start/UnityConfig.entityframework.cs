﻿using Darjeel.Infrastructure.EntityFramework.Messaging;
using Darjeel.Infrastructure.EntityFramework.Processors;
using Darjeel.Infrastructure.Messaging;
using Darjeel.Infrastructure.Processors;
using Microsoft.Practices.Unity;
using System;

namespace BookStore.Web.UI
{
    public partial class UnityConfig
    {
        private static void RegisterEntityFrameworkCommandBusAndProcessor(IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            if (!container.IsRegistered<IBusContext>())
            {
                container.RegisterType<IBusContext, BusContext>();
            }
            container.RegisterType<IProcessor, CommandProcessor>("CommandProcessor");
            container.RegisterType<ICommandBus, CommandBus>();
        }

        private static void RegisterEntityFrameworkEventBusAndProcessor(IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            if (!container.IsRegistered<IBusContext>())
            {
                container.RegisterType<IBusContext, BusContext>();
            }
            container.RegisterType<IProcessor, EventProcessor>("EventProcessor");
            container.RegisterType<IEventBus, EventBus>();
        }
    }
}