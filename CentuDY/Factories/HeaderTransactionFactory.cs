using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factories
{
    public static class HeaderTransactionFactory
    {
        public static HeaderTransaction createHeaderTransaction(String transactionID, String userID , DateTime transactionDate)
        {
            HeaderTransaction transaction = new HeaderTransaction();
            transaction.TransactionId = transactionID;
            transaction.UserId = userID;
            transaction.TransactionDate = transactionDate;
            return transaction;
        }

    }
}