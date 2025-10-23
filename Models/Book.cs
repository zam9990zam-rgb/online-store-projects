using System;
    using IPG_OOP_project.core;
    using IPG_OOP_project.Events;
namespace IPG_OOP_project.Models
{
    public class Book : AbstactBase
    {
        private string _author;
        private string _isbn;
        private int _quantityInStock;
        public event LowStockHandler LowStock;
        public string Author
        {
            get { return _author; }
            private set { _author = value; }
        }
        public string ISBN
        {
            get { return _isbn; }
            private set { _isbn = value; }
        }
        public int QuantityInStock { get { return _quantityInStock; }
            set { _quantityInStock = value;
                CheckStockLevel(); }
        }
        public Book(string id, string name, decimal price, string author, string isbn, int stock) : base(id, name, price)
        {
            Author = author;
            ISBN = isbn;
            QuantityInStock = stock;
        }
        public override string BriefDescription
        {
            get { return $"Book:{NameOfProduct}"; }
        }
        private void CheckStockLevel()
        {
            if (_quantityInStock<10)
            { if (LowStock != null)
                {
                    LowStock(this, new LowStockEventArgs
                    { ProductName = NameOfProduct, CheckStockLevel = _quantityInStock });
                }
            }
        }
    }
}
