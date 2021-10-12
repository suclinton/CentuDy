using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factories
{
    public static class TransactionDetailFactory
    {
        public static DetailTransaction createDetailTransaction(String TransactionId, string medicineId, int quantity)
        {
            DetailTransaction detailTransaction = new DetailTransaction();
            detailTransaction.TransactionId = TransactionId;
            detailTransaction.MedicineId = medicineId;
            detailTransaction.Quantity = quantity;
            return detailTransaction;
        }
    }
}