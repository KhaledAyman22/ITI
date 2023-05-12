using Autofac;
using MVVMDay23.DataService;
using MVVMDay23.Startup;
using MVVMDay23.View;
using MVVMDay23.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDay23
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //var Window = new Window1(new Window1ViewModel(new StudentDataService()));

            var bootstarpper = new Bootstrapper();
            var Container = bootstarpper.Bootstrap();
            var Window = Container.Resolve<Window1>();
            Window.Show();
        }
    }
}
