//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoesShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Detail
    {
        public int OrderID { get; set; }
        public int ShoesID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Sho Sho { get; set; }
    }
}
