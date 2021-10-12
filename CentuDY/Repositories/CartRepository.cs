using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repositories
{
    public static class CartRepository
    {
        private static CentuDYDBEntities db = Repositories.CentuDYDBSingleton.getDBInstance();
        public static List<Cart> getMedicinesByID(String medicineID)
        {
            List<Cart> medicinesInCart = (from cart in db.Carts where cart.MedicineId.Equals(medicineID) select cart).ToList();
            return medicinesInCart;
        }

        public static List<Cart> getUserById(String userId)
        {
            List<Cart> userInCart = (from cart in db.Carts
                                     where cart.UserId.Equals(userId)
                                     select cart).ToList();
            return userInCart;
        }
        public static void insertToCart(String UserID, String medicineID, int Quantity)
        {
            Cart cart = Factories.CartFactory.newCart(UserID, medicineID, Quantity);
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public static void updateCart(String UserID, String MedicineID, int Quantity)
        {
            Cart cart = getCartByUserIDandMedicineID(UserID, MedicineID);
            cart.Quantity += Quantity;
            db.SaveChanges();
        }

        public static Cart getCartByUserIDandMedicineID(String UserID, String MedicineID)
        {
            return (from cart in db.Carts where cart.UserId.Equals(UserID) && cart.MedicineId.Equals(MedicineID) select cart).ToList().FirstOrDefault();
        }
        public static List<Cart> getCarts(String UserID)
        {
            return (from cart in db.Carts.Include("Medicine") where cart.UserId.Equals(UserID) select cart).ToList();
        }

        public static Cart findMedicineInCart(string medicineID)
        {
            return (from cart in db.Carts where medicineID.Equals(medicineID) select cart).FirstOrDefault();
        }

        public static void deleteItemFromCart(Cart item)
        {
            db.Carts.Remove(item);
            db.SaveChanges();
        }

        public static void checkoutCart(List<Cart> cart)
        {
            db.Carts.RemoveRange(cart);
            db.SaveChanges();
        }
    }
}