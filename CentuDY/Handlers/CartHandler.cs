using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handlers
{
    public static class CartHandler
    {
        private static int getTotalMedicineInCart(String medicineID)
        {
            List<Cart> medicinesInCart = Repositories.CartRepository.getMedicinesByID(medicineID);
            if(medicinesInCart == null)
            {
                return 0;
            }
            return medicinesInCart.Sum(medicine => medicine.Quantity);
        }
        private static String lessThanOrEqualStock(int quantity, int stock)
        {
            if (quantity > stock)
            {
                return "Quantity must be less than or equal to current stock";
            }
            return "Success";
        }
        private static String quantityInputLessThanQuantityTotalInOtherCarts(int quantity, int stock, String medicineID)
        {
            int quantityInOtherCarts = Handlers.CartHandler.getTotalMedicineInCart(medicineID);
            if (quantity + quantityInOtherCarts > stock)
            {
                return "Sorry the quantity you entered has exceeded the stock";
            }
            return "Success";
        }

        public static String deleteItemFromCart(String userID, String medicineID)
        {
            Cart cartItem = Repositories.CartRepository.getCartByUserIDandMedicineID(userID, medicineID);
            if (cartItem == null)
            {
                return "";
            }
            else
            {
                String medicineName = cartItem.Medicine.Name;
                Repositories.CartRepository.deleteItemFromCart(cartItem);
                return medicineName + " has been removed from the cart";
            }
        }

        public static String checkoutCart(string userId)
        {
            List<Cart> cart = Repositories.CartRepository.getCarts(userId);
            if (cart.Count.Equals(0))
            {
                return "Currently there are no items in your cart";
            }
            else
            {
                Handlers.HeaderTransactionHandler.insertTransaction(userId, cart);
                for(int i = 0; i < cart.Count; i++)
                {
                    Medicine medicine = Handlers.MedicineHandler.getMedicineByID(cart[i].MedicineId);
                    Handlers.MedicineHandler.updateQuantity(medicine, cart[i].Quantity);
                }
                Repositories.CartRepository.checkoutCart(cart);
                return "Cart checkout successful";
            }
        }

        public static String validateInputQuantityWithStock(String medicineID, int quantity)
        {
            Medicine medicine = Repositories.MedicineRepository.getMedicineByID(medicineID);
            int medicineStock = medicine.Stock;
            String errorMsg = lessThanOrEqualStock(quantity, medicineStock);
            if (errorMsg.Equals("Success"))
            {
                errorMsg = quantityInputLessThanQuantityTotalInOtherCarts(quantity, medicineStock, medicineID);
            }
            return errorMsg;
        }
        public static int getSubTotal(String userID, String medicineID)
        {
            Cart cart = Repositories.CartRepository.getCartByUserIDandMedicineID(userID, medicineID);
            Medicine medicine = Repositories.MedicineRepository.getMedicineByID(medicineID);
            if(cart == null)
            {
                return 0;
            }
            return cart.Quantity * medicine.Price;
        }
        public static int getGrandTotal(String UserID)
        {
            List<Cart> Carts = Repositories.CartRepository.getCarts(UserID);
            int grandTotal = 0;
            for (int i = 0; i < Carts.Count; i++)
            {
                Cart cart = Repositories.CartRepository.getCartByUserIDandMedicineID(UserID, Carts[i].MedicineId);
                Medicine medicine = Repositories.MedicineRepository.getMedicineByID(Carts[i].MedicineId);
                grandTotal += cart.Quantity * medicine.Price;
            }
            return grandTotal;
        }

        public static void insertToCart(String UserID, String MedicineID, int Quantity)
        {
            Cart cart = Repositories.CartRepository.getCartByUserIDandMedicineID(UserID, MedicineID);
            if(cart == null)
            {
                Repositories.CartRepository.insertToCart(UserID, MedicineID, Quantity);
            }
            else
            {
                Repositories.CartRepository.updateCart(UserID, MedicineID, Quantity);
            }
        }

        public static List<Cart> getCarts(String UserID)
        {
            return Repositories.CartRepository.getCarts(UserID);
        }
    }
}