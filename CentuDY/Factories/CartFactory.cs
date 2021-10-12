using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factories
{
    public static class CartFactory
    {
        public static Cart newCart(String UserID, String MedicineId, int Quantity)
        {
            Cart c = new Cart();
            c.UserId = UserID;
            c.MedicineId = MedicineId;
            c.Quantity = Quantity;
            return c;
        }
    }
}