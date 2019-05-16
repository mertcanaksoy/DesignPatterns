using System;

namespace Adapter
{
    /*
     * Farklı sistemlerin, kendi sistemimize entegre edilmesi durumunda kendi sistemimiz bozulmadan,
     * farklı sistemin sanki kendi sistemimiz gibi davranmasını sağlayan desendir.
     */
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            //ProductManager productManager = new ProductManager(new MyLogger());
            //farklı loglama çeşitleri eklenerek adapter deseniyle burada new'lenebilir
            productManager.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("Data Logged");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }

    class MyLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}",message);
        }
    }

    class Log4Net //Dışarıdan müdahale edilemez bir class olduğunu varsayalım
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net, {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
}
