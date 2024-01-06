//using DAL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class SaleDetailsActions
    {
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SaleDetailsTbl> GetAllSaleDetails()
        {
            return DataBase.SaleDetailsTbls.ToList();
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SaleDetailsTbl> AddSaleDetails(SaleDetailsTbl s)
        {
            ProductTbl productToBuy = DataBase.ProductTbls.FirstOrDefault(x => x.ProductId == s.ProductId);
            //Checking that there is enough of the wanted product in stock.
            if (s.ProductCount <= productToBuy.AmountInStock)
                DataBase.SaleDetailsTbls.Add(s);
            else
            {
                s.ProductCount = productToBuy.AmountInStock;
                DataBase.SaleDetailsTbls.Add(s);
            }
            productToBuy.AmountInStock = productToBuy.AmountInStock - s.ProductCount;
            DataBase.SaveChanges();

            return GetAllSaleDetails();
        }
    }
}
