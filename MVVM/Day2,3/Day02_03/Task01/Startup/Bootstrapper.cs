using Autofac;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BLL.Managers;
using Task01.DAL;
using Task01.DAL.Repos;
using Task01.ViewModels;
using Task01.Views;

namespace Task01.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<StudentsWindow>().AsSelf();
            builder.RegisterType<StudentViewModel>().AsSelf();
            builder.RegisterType<StudentManager>().As<IStudentManager>();
            builder.RegisterType<StudentRepo>().As<IStudentRepo>();
            builder.RegisterType<MyDbContext>();


            return builder.Build();
        }
    }
}
