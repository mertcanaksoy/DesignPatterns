using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Elimizdeki nesneyi farklı koşullarda, farklı anlamlar yükleyerek kullanmak için bu desen tercih edilir.
            var personelCar = new PersonalCar {Make = "BMW", Model = "3.20", HirePrice = 3000};
            var commercialCar = new CommercialCar { Make = "Ford", Model = "Transit", HirePrice = 2000 };

            SpecialOffer specialOfferPersonal = new SpecialOffer(personelCar);
            specialOfferPersonal.DiscountPercentage = 10;

            SpecialOffer specialOfferCommercial = new SpecialOffer(commercialCar);
            specialOfferCommercial.DiscountPercentage = 20;

            Console.WriteLine("Gerçek Fiyat ({1} {2}): {0}", personelCar.HirePrice,personelCar.Make,personelCar.Model);
            Console.WriteLine("İndirimli Fiyat ({1} {2}): {0}", specialOfferPersonal.HirePrice, personelCar.Make, personelCar.Model);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Gerçek Fiyat ({1} {2}): {0}", commercialCar.HirePrice, commercialCar.Make, commercialCar.Model);
            Console.WriteLine("İndirimli Fiyat ({1} {2}): {0}", specialOfferCommercial.HirePrice, commercialCar.Make, commercialCar.Model);
            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        private readonly CarBase _carBase;
        public int DiscountPercentage { get; set; }

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get
            {
                return _carBase.HirePrice -_carBase.HirePrice*DiscountPercentage/100; //İndirimli fiyat
            }
            set
            {

            }
        }
    }
}
