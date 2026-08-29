using SoftwareSimulator;
using TransportSimulator;
using OrderSimulator;
using PaymentSimulatorStrategyPattern;
using WeatherForecastSimulatorObserverPatternPush;
using WeatherForecastObserverPullPattern;
using PizzaSimulatorDecoratorPattern;
using LogisticsServiceFactoryPattern;
using CheckoutServiceAbstractFactory.Classes;
using CheckoutServiceAbstractFactory.Service;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CompanySimulatorFunction();
            //TransportSimulatorFunction();
            //OrderSimulatorFunction();
            //ShoppingCardSimulatorFunctionUsingStrategyPattern();
            //WeatherForecastSimulatorFunctionUsingObserverPushPattern();
            WeatherForecastSimulatorFunctionUsingObserverPullPattern();
            //PizzaSimulatorFunction();
            //LogisticsFactoryFuction();
            //CheckoutServiceAbstractFactoryFunction();
        }

        private static void CheckoutServiceAbstractFactoryFunction()
        {
            CheckoutService service = new CheckoutService(new IndiaFactory(), "razorpay");
            service.CompleteOrder();
            service = new CheckoutService(new USFactory(), "stripe");
            service.CompleteOrder();
        }

        private static void LogisticsFactoryFuction()
        {
            LogisticsService service = new LogisticsService();
            service.Send("water");
        }

        private static void PizzaSimulatorFunction()
        {
            IBasePizza pizza = new PlainPizza();
            pizza = new Chicken(new Mushroom(pizza));
            IBasePizza pizza2 = new Farmhouse();
            pizza2 = new Mushroom(new Cheese(pizza2));
            GetPizzaOrderDetails(pizza);
            GetPizzaOrderDetails(pizza2);
        }

        private static void GetPizzaOrderDetails(IBasePizza pizza)
        {
            Console.WriteLine($"Pizza description: {pizza.GetDescription()}");
            Console.WriteLine($"Pizza price is {pizza.GetCost()} rs.");
        }

        private static void WeatherForecastSimulatorFunctionUsingObserverPullPattern()
        {
            WeatherForecastStation station = new WeatherForecastStation();
            var subscribers = new List<WeatherForecastObserverPullPattern.IWeatherSubscriber>()
            {
                new TempStatDisplay(station),
                new HumStatDisplay(station)
            };
            station.SetWeatherData(12.55, 52);
        }

        private static void WeatherForecastSimulatorFunctionUsingObserverPushPattern()
        {
            WeatherStation weatherStation = new WeatherStation();
            weatherStation.AddSubscriber(new StatisticsDisplay());
            weatherStation.AddSubscriber(new CurrentConditionDisplay());
            weatherStation.SetWeatherReading(14, 55);
        }

        private static void ShoppingCardSimulatorFunctionUsingStrategyPattern()
        {
            ShoppingCart shoppingCart = new ShoppingCart(new CashPayment());
            shoppingCart.Checkout(120);
            ShoppingCart shoppingCart2 = new ShoppingCart(new CreditCardPayment());
            shoppingCart2.Checkout(230);
        }

        private static void OrderSimulatorFunction()
        {
            var itemList = new List<Item>()
            {
                new Item("Controller", 1250, 0.3, 2),
                //new Item("Mouse", 3500, 0.65, 1),
                //new Item("LightBar", 3210, 0.2, 1),
                //new Item("Monitor", 19650, 10.5, 2)
            };

            Order order = new Order(itemList);
            Console.WriteLine($"Item shipped! Total item cost is {order.GetTotalCost()} with shipping charges {order.GetShippingCost()}");
            Console.WriteLine($"Estimated delivery on {order.GetShippingDate()}");
        }

        private static void TransportSimulatorFunction()
        {
            Transport transport = new Transport(new HumanDriver());
            transport.Deliver("Kenya");
        }

        private static void CompanySimulatorFunction()
        {
            List<Company> companies = new List<Company>()
            {
                new GameDevCompany(),
                new OutsourcingCompany(),
            };
            foreach (Company company in companies)
            {
                company.CreateSoftware();
                Console.WriteLine("---------");
            }
        }
    }
}
