using Autofac;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task03.BLL.Managers;
using Task03.ViewModels;
using Task03.Views;

namespace Task03.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<DevelopersWindow>().AsSelf();
            builder.RegisterType<DeveloperViewModel>().AsSelf();
            builder.RegisterType<DeveloperManager>().As<IDeveloperManager>();

            return builder.Build();
        }
    }
}
