using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class SalesActions
    {
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SalesTbl> GetAllSales()
        {
            return DataBase.SalesTbls.ToList();
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SalesTbl> AddSale(SalesTbl s)
        {
            DataBase.SalesTbls.Add(s);
            DataBase.SaveChanges();

            return GetAllSales();
        }
    }
}
