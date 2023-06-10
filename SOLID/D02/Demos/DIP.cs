    //Befor Using DIP:

    class Program
    {
        static void Main(string[] args)
        {
            Shoper shop = new Shoper();
            shop.Pay();
        }
    }

    internal class MasterCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using Master Card ......");
        }
    }

    internal class Shoper
    {
        internal void Pay()
        {
            MasterCard c1 = new MasterCard();
            c1.Charge();
        }

    }


#region After Using DIP (Lecture)

    class Program
    {
        static void Main(string[] args)
        {
            Shoper shop = new Shoper();
            
            ServiceLocator serviceLocator = new ServiceLocator();
            //ICard card = new MasterCard();
            // using service locator
            MasterCard card = serviceLocator.Get(ICard);
            
            //IStock stock = new ShoppingStock(); 
            //using factory method pattern
            IStock stock = (new StockFactory()).CreateStock();

            shop.UpdateCart(stock);
            shop.Pay(card);
        }
    }
    
    // Apply Interface inversion iOC of DIP, by using interface segregation
    interface ICard
    {
        void Charge();
    }    

    internal class MasterCard:ICard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using Master Card ......");
        }
    }

    internal class ServiceLocator
    {

        MasterCard Get(ICard)
        {
            if (t == typeof(ICard))
                return new MasterCard();
        }
    }

    interface IStock
    {
        bool ValidateStockItemAvailability(object item);
        bool UpdateStockItems(object item);
    }
    
    internal class StockFactory
    {
        internal IStock CreateStock()
        {
            // ----- logic for creation of object   
            return new ShoppingStock()
        }
    }

    internal class ShoppingStock: IStock
    {
        bool ValidateStockItemAvailability(object item)
        { }
        bool UpdateStockItems(object item)
        { }
    }
    
    internal class Shoper
    {
        List<object> CartItems { get; set; }

        internal void UpdateCart(IStock stock) // using method injection
        {
            foreach (var item in CartItems)
            {
                // code to update validate stock availabilty
                stock.ValidateStockItemAvailability(item);
                // code to update stock
                stock.UpdateStockItems(item);

            }
        }
        //internal void Pay(MasterCard c1) // using method injection

        internal void Pay(ICard c1) // using method injection
        {
            //MasterCard c1 = new MasterCard();
            c1.Charge();
        }
    }

#endregion

#region After DIP
//class Program
//{
//    // Using interface inversion + property inversion
//   static ICard _c1;

//    // using constructor injection
//    public Program(ICard c)
//    {
//        _c1 = c;
//    }
//    static void Main(string[] args)
//    {
//        // Using Concrete type
//        //MasterCard c1 = new MasterCard();

//        // Using interface inversion
//        //ICard c1 = new MasterCard();

//        Shoper shop = new Shoper();
//        shop.SelectPaymentOPtion();
//        // if using method injection in Shopper class
//        //shop.Pay(_c1);

//        // if using property injecytion in Shopper class
//        shop.Pay();
//    }
//}

//internal class MasterCard:ICard
//{
//    void ICard.Charge()
//    {
//        Console.WriteLine("Charging using Master Card ......");
//    }
//}

//internal class VisaCard : ICard
//{
//    void ICard.Charge()
//    {
//        Console.WriteLine("Charging using Visa Card ......");
//    }
//}
//internal class Shoper
//{
//    // using property injection option according to business instead of method injection
//    public ICard c1;
//    List<Obiect> CartItems { get; set; }

//    internal void UpdateCart()
//    {
//        foreach (var item in CartItems)
//        {
//            // code to update validate stock
//            // code to update stock
//        }
//    }
//    public Shoper()
//    {
//        if (new Random(2).Next() == 2)
//            c1 = new MasterCard();
//        else
//            c1 = new VisaCard();
//    }

//    public void SelectPaymentOPtion()
//    {
//        if (new Random(2).Next() == 2)
//            c1 = new MasterCard();
//        else
//            c1 = new VisaCard();
//    }
//    // in case using property injection
//    internal void Pay() // (2) Depending on concrete implementation and not using abstraction
//    {
//        c1.Charge();
//    }
//    // Using Method injection to avoid implicit dependency
//    internal void Pay(ICard c1) // (2) Depending on concrete implementation and not using abstraction
//    {
//        c1.Charge();
//    }
//}

//internal interface ICard
//{
//    void Charge();
//}

//internal class Shoper
//{
//    internal void Pay()
//    {
//        Card c1 = new Card(); // (1) Smell: Hidden/implicit dependency
//        c1.Charge();
//    }
//}

//internal class Shoper
//{
//    // Using Method injection to avoid implicit dependency
//    internal void Pay(Card c1) // (2) Depending on concrete implementation and not using abstraction
//    {  
//        c1.Charge();
//    }
//}
# endregion


