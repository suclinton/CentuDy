using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repositories
{
    public static class TransactionDetailRepository
    {
        private static CentuDYDBEntities db = CentuDYDBSingleton.getDBInstance();
        public static void addTransactionDetail(DetailTransaction detailTransaction)
        {
            db.DetailTransactions.Add(detailTransaction);
            db.SaveChanges();
        }

        public static List<DetailTransaction> GetMedicine(String medicineId)
        {
            List<DetailTransaction> detailTransactions = (from dt in db.DetailTransactions
                                                          where dt.MedicineId.Equals(medicineId)
                                                          select dt).ToList();
            return detailTransactions;
        }
        public static List<DetailTransaction> GetTransactionDetails(String userID)
        {
            return (from detailTransaction in db.DetailTransactions.Include("HeaderTransaction") 
                    where detailTransaction.HeaderTransaction.UserId.Equals(userID) select detailTransaction).ToList();
        }
        public static List<DetailTransaction> GetTransactionDetailsWithMedicine(String userID)
        {
            return (from detailTransaction in db.DetailTransactions.Include("Medicine")
                    where detailTransaction.HeaderTransaction.UserId.Equals(userID)
                    select detailTransaction).ToList();
        }
        public static DetailTransaction getQuantityByTransactionIDAndMedicineID(String transactionID, String medicineID)
        {
            return (from detailTransaction in db.DetailTransactions 
                    where transactionID.Equals(transactionID) && detailTransaction.Equals(medicineID) select detailTransaction).FirstOrDefault();
        }
    }
}