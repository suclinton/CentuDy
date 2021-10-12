using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handlers
{
    public static class TranscationDetailHandler
    {
        public static void insertTransactionDetail(String newId, String medicineId, int Quantity)
        {
            DetailTransaction detailTransaction = Factories.TransactionDetailFactory.createDetailTransaction(newId, medicineId, Quantity);
            Repositories.TransactionDetailRepository.addTransactionDetail(detailTransaction);
        }

        public static List<DetailTransaction> getTransactionDetails(string userId)
        {
            return Repositories.TransactionDetailRepository.GetTransactionDetails(userId);
        }

        public static int getGrandTotal(String UserID)
        {
            List<DetailTransaction> transactionDetails = Repositories.TransactionDetailRepository.GetTransactionDetails(UserID);
            int grandTotal = 0;
            for(int i = 0; i < transactionDetails.Count; i++)
            {
                Medicine medicine = Handlers.MedicineHandler.getMedicineByID(transactionDetails[i].MedicineId);
                grandTotal += transactionDetails[i].Quantity * medicine.Price;
            }
            return grandTotal;
            //return transactionDetails.Sum(dt => dt.Quantity * dt.Medicine.Price);
        }
    }
}