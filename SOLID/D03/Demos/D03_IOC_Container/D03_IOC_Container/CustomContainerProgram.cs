using System;
using System.Collections.Generic;

namespace D03_IOC_Container
{
    class CustomContainerProgram
    {

        static void Main1(string[] args)
        {
            // Intialization for the concrete classes
            //var card1 = new MasterCard();
            //var card2 = new VisaCard();
            //Shopper client = new Shopper();

            // 1. create container instance
            CustomContainer container = new CustomContainer();
            
            //D03_IOC_Container, D03_IOC_Container.ICreditCard
            // 2. registeration for types
            container.Register<ICreditCard, VisaCard>();
            container.Register<Shopper, Shopper>();

            // 3. resolution for types to return concrete types
            var card1 = container.Resolve<ICreditCard>();
            var client1 = container.Resolve<Shopper>();

            client1.Checkout(card1);
            // override for registeration
            // any resolution after this registeration will return "MasterCard"
            container.Register<ICreditCard, MasterCard>();

            //if non generic
            //container.Register(typeof(ICreditCard), typeof(VisaCard));
           
            // 3. resolution for types to return concrete types
            var card2 = container.Resolve<ICreditCard>();
            var client2 = container.Resolve<Shopper>();

            client2.Checkout(card2);

        }
    }

    internal class CustomContainer
    {
        private readonly Dictionary<Type, Type> _iocContainer = new Dictionary<Type, Type>();
        
        internal void Register<TFrom, TTo>()
        {
            Register(typeof(TFrom), typeof(TTo));
        }

        private void Register(Type TFrom, Type TTo) //(ICreditCard, MasterCard)
        {
            if (!_iocContainer.ContainsKey(TFrom))
            {
                // Allow only adding unique type with no override
                _iocContainer.Add(TFrom, TTo);
            }
            else
            {
                // Allow overriding the types on registeration 
                _iocContainer[TFrom] = TTo;


                // If override not allowed will always use first registration
                _iocContainer[TTo] = _iocContainer[TFrom]; /// or we can ignore else block
            }
        }

        internal T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            var objType = _iocContainer[type];
            
            return Activator.CreateInstance(objType);
        }
    }
}
