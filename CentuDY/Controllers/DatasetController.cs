using CentuDY.Dataset;
using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CentuDY.Controllers
{
    public static class DatasetController
    {
        public static CentuDYDataset getDataset()
        {
            CentuDYDataset dataset = new CentuDYDataset();
            List<HeaderTransaction> transaction = Handlers.HeaderTransactionHandler.getTransaction();

            var headerTransaction = dataset.HeaderTransaction;
            var detailTransaction = dataset.DetailTransaction;
            foreach(HeaderTransaction tran in transaction)
            {
                DataRow headerTransactionRow = headerTransaction.NewRow();

                headerTransactionRow["TransactionID"] = tran.TransactionId;
                headerTransactionRow["Transaction Date"] = tran.TransactionDate.ToString("dd/MM/yyyy");
                headerTransactionRow["UserID"] = tran.UserId;
                headerTransactionRow["Grand Total"] = tran.DetailTransactions.Sum(dt => dt.Quantity * dt.Medicine.Price);

                headerTransaction.Rows.Add(headerTransactionRow);
                foreach(DetailTransaction dt in tran.DetailTransactions)
                {
                    DataRow detailTransactionRow = detailTransaction.NewRow();

                    detailTransactionRow["TransactionID"] = tran.TransactionId;
                    detailTransactionRow["MedicineID"] = dt.MedicineId;
                    detailTransactionRow["Quantity"] = dt.Quantity;
                    detailTransactionRow["Sub Total"] = dt.Quantity * dt.Medicine.Price;

                    detailTransaction.Rows.Add(detailTransactionRow);
                    
                }
            }

            return dataset;
        }
    }
}