using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.ComponentModel;
using System.Reflection.Emit;


namespace D03_IOC_Container
{
    class CastleWindsorProgram
    {
        static void Main2(string[] args)
        {
            // Intialization for the concrete classes
            //var card1 = new MasterCard();
            //var card2 = new VisaCard();
            //Shopper client = new Shopper();

            //// A. Using Code for registration
            //// 1. Create castle container
            //var castleContainer = new WindsorContainer();

            //// 2. Registration for the types
            //// Default lifetime is "Singletone"
            //// Note: when try to override registeration only first registeration type will be retrived
            //castleContainer.Register(Castle.MicroKernel.Registration.Component.For<Shopper>().ImplementedBy<Shopper>().LifeStyle.Transient);
            //castleContainer.Register(Castle.MicroKernel.Registration.Component.For<ICreditCard>().ImplementedBy<MasterCard>());
            ////castleContainer.Register(Castle.MicroKernel.Registration.Component.For<ICreditCard>().ImplementedBy<VisaCard>());// will retrive MasterCard

            ////force the later - registered component to become the default instance
            //castleContainer.Register(Castle.MicroKernel.Registration.Component.For<ICreditCard>().ImplementedBy<VisaCard>().IsDefault());
            ////using new registration
            ////castleContainer.Register(Castle.MicroKernel.Registration.Component.For<VisaCard>().ImplementedBy<VisaCard>());

            ////3. Resolution for the objects
            //var card = castleContainer.Resolve<ICreditCard>();
            //var card2 = castleContainer.Resolve<VisaCard>();
            //var client = castleContainer.Resolve<Shopper>();

            //client.Checkout(card);


            //B.Using Config file for registration

            //1.create config file in " ..\bin\Debug\net5.0\Castle.config"

            //2.create castel container using configuration file
            var castleContainer2 = new WindsorContainer("Castle.config");


            // 2. Registration
            // No need for the registeration will be read from the config file "Castle.config"


            //3. Resolution for the objects
            var card = castleContainer2.Resolve<ICreditCard>();
            var client = castleContainer2.Resolve<Shopper>();

            client.Checkout(card);
        }
    }  
}
