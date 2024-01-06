using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Actions
{
    public class ProductActions
    {
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductTbl> GetAllProducts()
        {
            return DataBase.ProductTbls.ToList();
        }

        public static ProductTbl GetProductByID(int id)
        {
            ProductTbl product = DataBase.ProductTbls.FirstOrDefault(x => x.ProductId.Equals(id));
            return product;
        }

        public static List<ProductTbl> GetProductByCategoryId(int id)
        {
            List<ProductTbl> product = DataBase.ProductTbls.Where(x => x.CategoryId.Equals(id)).ToList();
            return product;
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductTbl> AddProduct(ProductTbl p)
        {
            DataBase.ProductTbls.Add(p);
            DataBase.SaveChanges();
            return GetAllProducts();
        }

        //-----------------------------------------------------------------------------
        //-----------------------------------Delete------------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductTbl> DeleteProductById(int id)
        {
            ProductTbl productToDelete = DataBase.ProductTbls.FirstOrDefault(x => x.ProductId == id);
            if (productToDelete != null)
            {
                DataBase.ProductTbls.Remove(productToDelete);
                DataBase.SaveChanges();
            }
            return GetAllProducts();
        }

        //-----------------------------------------------------------------------------
        //------------------------------------Post-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductTbl> UpdateProduct(int id, ProductTbl p)
        {
            ProductTbl productToUpdate = DataBase.ProductTbls.FirstOrDefault(x => x.ProductId == id);
            if (productToUpdate != null)
            {
                //productToUpdate.ProductId = p.ProductId;
                productToUpdate.ProductName = p.ProductName;
                productToUpdate.ProductPicture = p.ProductPicture;
                productToUpdate.ProductPrice = p.ProductPrice;
                productToUpdate.AmountInStock = p.AmountInStock;
                productToUpdate.CategoryId = p.CategoryId;
                DataBase.SaveChanges();
            }
            return GetAllProducts();
        }
    }
}
