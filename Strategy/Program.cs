using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            TeacherManager teacherManager = new TeacherManager();
            teacherManager.AlgebraCalculatorBase = new SumCalculator();
            teacherManager.SaveCalculate();

            teacherManager.AlgebraCalculatorBase = new DivideCalculator();
            teacherManager.SaveCalculate();

            //Tek TeacherManager nesnesi ile 2 farklı hesaplama yöntemine arka arkaya erişmek mümkün oldu.
            Console.ReadLine();
        }
    }

    abstract class AlgebraCalculatorBase
    {
        public abstract void Calculate();
    }

    class SumCalculator : AlgebraCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Toplama işlemi ile hesaplama yapıldı");
        }
    }

    class DivideCalculator : AlgebraCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Bölme işlemi ile hesaplama yapıldı");
        }
    }

    class TeacherManager
    {
        public AlgebraCalculatorBase AlgebraCalculatorBase { get; set; }

        public void SaveCalculate()
        {
            Console.WriteLine("Teacher Manager İş Katmanı");
            AlgebraCalculatorBase.Calculate();
        }
    }
}
