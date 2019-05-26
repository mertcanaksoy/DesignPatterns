using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerObserver customerObserver = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver); //müşteri için bir observer ekle
            productManager.Detach(customerObserver); //müşteri için eklenen observer'ı kaldır
            productManager.Attach(new EmployeeObserver());
            productManager.Update();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private List<Observer> _observers = new List<Observer>();
        public void Update()
        {
            Console.WriteLine("Ürün Fiyatı Güncellendi");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Müşteriye Mesaj: Ürün Fiyatı Güncellendi");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Çalışana Mesaj: Ürün Fiyatı Güncellendi");
        }
    }
}
