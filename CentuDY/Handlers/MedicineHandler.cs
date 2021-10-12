using CentuDY.Models;
using CentuDY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Handlers
{
    public static class MedicineHandler
    {
        public static List<Medicine> GetMedicines()
        {
            List<Medicine> med = Repositories.MedicineRepository.GetMedicines();
            return med;
        }

        public static Medicine getMedicineByID(String medicineID)
        {
            return Repositories.MedicineRepository.getMedicineByID(medicineID);
        }
        public static List<Medicine> getRecommendedMedicine()
        {
            List<Medicine> Medicines = Repositories.MedicineRepository.GetMedicines();
            List<int> indexAdded = new List<int>();
            List<Medicine> recomendedMedicine = new List<Medicine>();
            Random rand = new Random();
            while (indexAdded.Count != 5)
            {
                int idx = rand.Next(Medicines.Count);
                if (!indexAdded.Contains(idx))
                {
                    indexAdded.Add(idx);
                    recomendedMedicine.Add(Medicines[idx]);
                }
            }
            return recomendedMedicine;
        }

        public static List<Medicine> getMedicineByName(String medicineName)
        {
            List<Medicine> med = Repositories.MedicineRepository.getMedicineByName(medicineName);
            return med;
        }

        public static void insertMedicine(string medicineName, string medicineDescription, int medicinePriceInt, int medicineStockInt)
        {
            String lastMedicineID = Repositories.MedicineRepository.getLastMedicine().MedicineId;
            Medicine medicine = null;
            if (lastMedicineID == null)
            {
                medicine = Factories.medicineFactory.createMedicine("MD001", medicineName, medicineDescription, medicinePriceInt, medicineStockInt);
            }
            else
            {
                String newId = generateMedicineId(lastMedicineID);
                medicine = Factories.medicineFactory.createMedicine(newId, medicineName, medicineDescription, medicinePriceInt, medicineStockInt);
            }
            Repositories.MedicineRepository.insertMedicine(medicine);
        }

        public static void updateMedicine(string medicineName, string medicineDescription, int medicinePriceInt, int medicineStockInt, string medicineId)
        {
            Medicine medicine = Repositories.MedicineRepository.getMedicineByID(medicineId);
            Repositories.MedicineRepository.updatedMeds(medicineName, medicineDescription, medicinePriceInt, medicineStockInt, medicine);
        }

        public static void updateQuantity(Medicine medicine, int quantity)
        {
            if (quantity.Equals(0))
            {
                return;
            }
            Repositories.MedicineRepository.updateQuantity(medicine, quantity);
        }

        private static String generateMedicineId(String lastMedicineID)
        {
            int Id = int.Parse(lastMedicineID.Substring(2));
            Id++;
            return String.Format("{0}{1:000}", "MD", Id);
        }
        
        public static String deleteMedicineById(String medicineId)
        {
            Medicine meds = MedicineRepository.getMedicineByID(medicineId);
            
            if (meds == null)
            {
                return "Delete Failed";
            }
            if (inTheCart(medicineId))
            {
                return "This Medicine is on user's cart";
            }
            if (inDetailTrans(medicineId))
            {
                return "This Medicine is on Detail Transaction!";
               }
            else
            {
                Repositories.MedicineRepository.deleteMedicineById(medicineId);
                return "Success";
            }
        }

        public static bool inTheCart(String medicineId)
        {
            List<Cart> cart = CartRepository.getMedicinesByID(medicineId);
            for(int i=0; i<cart.Count(); i++)
            {
                if (cart[i].MedicineId.Equals(medicineId)) return true;
            }
            return false;
        }

        public static bool inDetailTrans(String medicineId)
        {
            List<DetailTransaction> detailTransactions = TransactionDetailRepository.GetMedicine(medicineId);
            for(int i=0; i<detailTransactions.Count(); i++)
            {
                if (detailTransactions[i].MedicineId.Equals(medicineId)) return true;
            }
            return false;
        }
    }
}