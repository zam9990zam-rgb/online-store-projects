using System;
namespace IPG_OOP_project.Events
{
    public class LowStockEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public int StockLevel { get; set; };
    }
    public delegate void LowStockHandler(object sender, LowStockEventArgs e);
} 
