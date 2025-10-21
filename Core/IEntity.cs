using System;

namespace IPG_OOP_Project.Core
{
    public interface IEntity
    {
        string ProductIdentifier { get; }
        string NameOfProduct { get; }
        decimal CurrentPrice { get; }
        string BriefDescription { get; }
        void ShowProductDetails();
    }
}
