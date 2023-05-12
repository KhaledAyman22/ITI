using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Task01.Startup;
using Task01.Views;

namespace Task01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var Container = bootstrapper.Bootstrap();
            var studentsWindow = Container.Resolve<StudentsWindow>();
            studentsWindow.Show();
        }
    }
}
