using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // CustomerManager customerManager = new CustomerManager();
            // Singleton patterni, yukarıdaki gibi doğrudan instance almamızı engeller bunun yerine;

            CustomerManager customerManager = CustomerManager.CreateAsSingleton(); //
            customerManager.Add(); //Pattern ile oluşturulan bir methodu çağırmak
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
            return _customerManager;
        }

        public void Add()
        {
            Console.WriteLine("Customer Added");
            Console.ReadKey();
        }
    }
}
