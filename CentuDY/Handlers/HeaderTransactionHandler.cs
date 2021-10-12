using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handlers
{
    public static class HeaderTransactionHandler
    {
        public static void insertTransaction(String userID, List<Cart> cartItem)
        {
            HeaderTransaction lastTransaction = Repositories.HeaderTransactionRepository.getLastTransaction();
            DateTime transactionDate = DateTime.Now;
            HeaderTransaction newTransaction = null;
            String newId = lastTransaction == null ? "TR001" : generateTransactionID(lastTransaction.TransactionId);
            newTransaction = Factories.HeaderTransactionFactory.createHeaderTransaction(newId, userID, transactionDate);
            Repositories.HeaderTransactionRepository.addTransaction(newTransaction);
            for(int i = 0; i < cartItem.Count; i++)
            {
                Handlers.TranscationDetailHandler.insertTransactionDetail(newId, cartItem[i].MedicineId, cartItem[i].Quantity);
            }
        }
        public static String generateTransactionID(String lastTransactionID)
        {
            int Id = int.Parse(lastTransactionID.Substring(2));
            Id++;
            return String.Format("{0}{1:000}", "TR", Id);
        }
        public static List<HeaderTransaction> getTransaction()
        {
            return Repositories.HeaderTransactionRepository.getTransaction();
        }
    }
}