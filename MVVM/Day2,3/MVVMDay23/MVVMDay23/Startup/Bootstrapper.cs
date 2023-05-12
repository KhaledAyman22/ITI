using Autofac;
using MVVMDay23.DataService;
using MVVMDay23.View;
using MVVMDay23.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.Startup
{
    internal class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder=new ContainerBuilder();

            builder.RegisterType<Window1>().AsSelf();
            builder.RegisterType<Window1ViewModel>().AsSelf();
            builder.RegisterType<StudentDataService>().As<IDataService>();

            return builder.Build();
        }
    }
}
