using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Cache'leme mantığı gibi düşünülebilir
             Bir işlem ilk kez yapıldıktan sonra tekrar çağırılacağı zaman önceden yapılmış işlemi hızlıca
             çağırma durumunda kullanılır.
             */

            CreditBase manager = new CreditManagerProxy();

            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            Console.ReadLine();
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 3;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager == null) //Eğer işlem ilk defa yapılıyorsa
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            //İlk defa yapılmıyorsa 
            return _cachedValue;
        }
    }
}
