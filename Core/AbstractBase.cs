using System;

namespace IPG_OOP_Project.Core
{
    public abstract class AbstractBase : IEntity
    {
        public string ProductIdentifier { get; protected set; }
        public string NameOfProduct { get; protected set; }
        public decimal CurrentPrice { get; protected set; }

        protected AbstractBase(string id, string name, decimal price)
        {
            ProductIdentifier = id;
            NameOfProduct = name;
            CurrentPrice = price;
        }

        public abstract string BriefDescription { get; }

        public virtual void ShowProductDetails()
        {
            Console.WriteLine($"Product ID: {ProductIdentifier}");
            Console.WriteLine($"Product Name: {NameOfProduct}");
            Console.WriteLine($"Price Tag: {CurrentPrice:C}");
            Console.WriteLine($"Short Description: {BriefDescription}");
        }
    }
}
