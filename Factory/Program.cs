using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Add();
            Console.ReadLine();
        }
    }

    public interface ILogger
    {
        void Log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new MyLogger();
        }
    }

    public class MyLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with MyLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Add()
        {
            Console.WriteLine("Added");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }


}
