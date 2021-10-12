using CentuDY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentuDY.Repositories
{
    public class CentuDYDBSingleton
    {
        private static CentuDYDBEntities db = null;

        public static CentuDYDBEntities getDBInstance()
        {
            if(db == null)
            {
                return new CentuDYDBEntities();
            }
            return db;
        }
    }
}