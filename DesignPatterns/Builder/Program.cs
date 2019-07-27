using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            //arka arkaya işlemler sonucunda bir nesne üretmek.
            ProductDirector director = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);

            Console.ReadLine();
            
        }
    }
    public class ProductVieWModel
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
        //abstract olması farklı builderlar oluşturmayı sağlıyor
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductVieWModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductVieWModel model = new ProductVieWModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice*(decimal)0.9;
            model.DiscountApplied = true;
        }

        public override ProductVieWModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductVieWModel model = new ProductVieWModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.9;
            model.DiscountApplied = false;
        }

        public override ProductVieWModel GetModel()
        {
            return model;
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
