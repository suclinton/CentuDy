using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Factories
{
    public static class medicineFactory
    {
        public static Medicine createMedicine(String medicineID, string medicineName, string medicineDescription, int medicinePriceInt, int medicineStockInt)
        {
            Medicine medicine = new Medicine();
            medicine.MedicineId = medicineID;
            medicine.Name = medicineName;
            medicine.Description = medicineDescription;
            medicine.Price = medicinePriceInt;
            medicine.Stock = medicineStockInt;
            return medicine;
        }
    }
}