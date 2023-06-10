using System.ComponentModel;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;
using Microsoft.Practices.Unity.Configuration;

namespace D03_IOC_Container
{
    class UnitycontainerProgram
    {
        static void Main(string[] args)
        {
            // Intialization for the concrete classes
            //var card1 = new MasterCard();
            //var card2 = new VisaCard();
            //Shopper client = new Shopper();

            // A. Using Code for registration
            // 1. Create object form the unity container
            var unityContainer = new UnityContainer();

            // B. Using Code for registration
            // To load configuration from App.config File
            unityContainer.LoadConfiguration();

            // 2. Registeration for all types used for Shopping module
            // Default lifetime is "Transient"
            // Note: when try to override registeration the last registeration will be applied
            //unityContainer.RegisterType<Shopper, Shopper>();

            //unityContainer.RegisterType<ICreditCard, MasterCard>("MCard");

            ////register using "REgisterType" for singleton
            //unityContainer.RegisterType<ICreditCard, VisaCard>("VCard", TypeLifetime.Transient);

            //var card1 = unityContainer.Resolve<ICreditCard>("VCard");


            ////register using "RegisterInstance" for singleton
            //var instance = new MasterCard();
            //unityContainer.RegisterInstance<ICreditCard>(instance, InstanceLifetime.Singleton);


            //// 3. Resolution for the objects
            var client = unityContainer.Resolve<Shopper>();
            //var card1 = unityContainer.Resolve<ICreditCard>("VCard");
            var card2 = unityContainer.Resolve<ICreditCard>();

            client.Checkout(card2);
        }
    }
}
