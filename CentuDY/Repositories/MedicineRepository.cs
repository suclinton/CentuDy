using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CentuDY.Models;
namespace CentuDY.Repositories
{
    public static class MedicineRepository
    {
        private static CentuDYDBEntities db = Repositories.CentuDYDBSingleton.getDBInstance();

        public static Medicine getMedicineByID(String medicineID)
        {
            return (from medicine in db.Medicines where medicine.MedicineId.Equals(medicineID) select medicine).ToList().FirstOrDefault();
        }
        public static Medicine getLastMedicine()
        {
            return (from medicine in db.Medicines select medicine).ToList().LastOrDefault();
        }
        public static List<Medicine> GetMedicines()
        {
            return (from med in db.Medicines select med).ToList();
        }

        public static void insertMedicine(Medicine medicine)
        {
            db.Medicines.Add(medicine);
            db.SaveChanges();
        }

        public static List<Medicine> getMedicineByName(String medicineName)
        {
            return (from med in db.Medicines
                    where med.Name.Contains(medicineName)
                    select med).ToList();
        }

        public static void deleteMedicineById(string id)
        {
            Medicine medicine = getMedicineByID(id);
            db.Medicines.Remove(medicine);
            db.SaveChanges();
        }

        public static void updatedMeds(string medicineName, string medicineDescription, int medicinePriceInt, int medicineStockInt, Medicine medicine)
        {
            medicine.Name = medicineName;
            medicine.Description = medicineDescription;
            medicine.Stock = medicineStockInt;
            medicine.Price = medicinePriceInt;
            db.SaveChanges();
        }

        public static void updateQuantity(Medicine medicine, int quantity)
        {
            Medicine med = medicine;
            med.Stock -= quantity;
            db.SaveChanges();
        }
    }
}