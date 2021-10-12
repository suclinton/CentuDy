using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repositories
{
    public static class HeaderTransactionRepository
    {
        private static CentuDYDBEntities db = CentuDYDBSingleton.getDBInstance();
        public static void addTransaction(HeaderTransaction transaction)
        {
            db.HeaderTransactions.Add(transaction);
            db.SaveChanges();
        }

        public static HeaderTransaction getLastTransaction()
        {
            return (from transaction in db.HeaderTransactions select transaction).ToList().LastOrDefault();
        }

        public static List<HeaderTransaction> getUserById(String userId)
        {
            List<HeaderTransaction> headerTransactions = (from dt in db.HeaderTransactions
                                                          where dt.UserId.Equals(userId)
                                                          select dt).ToList();
            return headerTransactions;
        }

        public static List<HeaderTransaction> getTransaction()
        {
            return (from transaction in db.HeaderTransactions.Include("DetailTransactions") select transaction).ToList();
        }        
        public static List<HeaderTransaction> getTransactionByUserID(String userID)
        {
            return (from transaction in db.HeaderTransactions.Include("DetailTransactions") where transaction.UserId.Equals(userID) select transaction).ToList();
        }
    }
}