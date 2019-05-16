using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomManager customManager = new CustomManager();
            customManager.Save();
            Console.ReadLine();
        }

        interface ILogging
        {
            void Log();
        }

        interface ICaching
        {
            void Cache();
        }

        interface IAuthorize
        {
            void CheckUser();
        }

        class Caching : ICaching
        {
            public void Cache()
            {
                Console.WriteLine("Cached");
            }
        }

        class Logging : ILogging
        {
            public void Log()
            {
                Console.WriteLine("Logged");
            }
        }

        class Authorize : IAuthorize
        {
            public void CheckUser()
            {
                Console.WriteLine("User Checked");
            }
        }

        class CustomManager
        {
            private FacadeCrossCuttingConcerns _crossCuttingConcerns;

            public CustomManager()
            {
                _crossCuttingConcerns = new FacadeCrossCuttingConcerns();
            }

            public void Save()
            {
                _crossCuttingConcerns.Logging.Log();
                _crossCuttingConcerns.Authorize.CheckUser();
                _crossCuttingConcerns.Caching.Cache();
                Console.WriteLine("Saved");
            }
        }

        class FacadeCrossCuttingConcerns
        {
            public ILogging Logging { get; set; }
            public ICaching Caching { get; set; }
            public IAuthorize Authorize { get; set; }

            public FacadeCrossCuttingConcerns()
            {
                Logging = new Logging();
                Caching = new Caching();
                Authorize = new Authorize();
                /*Yeni özellikler ve metodlar bu kısma eklenir, CustomManager adlı ana sınıfta
                her yeni özellik için dependency injection yapma işlemine gerek kalmaz. Bu açıdan
                Facade deseni oldukça faydalıdır. Bir nevi sadeleştirme işi görür. */
            }
        }
    }
}
