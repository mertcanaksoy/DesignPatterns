using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);

            Console.ReadLine();
        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }

    }

    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void GetProductData()
        {
            productViewModel.Id = 1;
            productViewModel.ProductName = "Kola";
            productViewModel.CategoryName = "İçecek";
            productViewModel.UnitPrice = 10;
        }

        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice * (decimal) 0.90;
            productViewModel.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return productViewModel;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productViewModel = new ProductViewModel();
        public override void GetProductData()
        {
            productViewModel.Id = 1;
            productViewModel.ProductName = "Kola";
            productViewModel.CategoryName = "İçecek";
            productViewModel.UnitPrice = 10;
        }

        public override void ApplyDiscount()
        {
            productViewModel.DiscountedPrice = productViewModel.UnitPrice;
            productViewModel.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return productViewModel;
        }
    }

    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
