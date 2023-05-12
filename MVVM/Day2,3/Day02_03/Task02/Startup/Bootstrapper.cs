using Autofac;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.BLL.Managers;
using Task02.DAL;
using Task02.DAL.Models;
using Task02.DAL.Repos;
using Task02.ViewModels;
using Task02.Views;

namespace Task02.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<DevelopersWindow>().AsSelf();
            builder.RegisterType<DeveloperViewModel>().AsSelf();
            builder.RegisterType<DeveloperManager>().As<IDeveloperManager>();
            builder.RegisterType<DeveloperRepo>().As<IDeveloperRepo>();
            builder.RegisterType<APID02Context>();

            return builder.Build();
        }
    }
}
