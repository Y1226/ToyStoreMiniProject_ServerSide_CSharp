using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class CategoryActions
    {
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<CategoryTbl> GetAllCategorys()
        {
            return DataBase.CategoryTbls.ToList();
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<CategoryTbl> AddCategory(CategoryTbl c)
        {
            DataBase.CategoryTbls.Add(c);
            DataBase.SaveChanges();

            return GetAllCategorys();   
        }

        //-----------------------------------------------------------------------------
        //-----------------------------------Delete------------------------------------
        //-----------------------------------------------------------------------------
        public static List<CategoryTbl> DeleteCategoryById(int id)
        {
            CategoryTbl categoryToDelete = DataBase.CategoryTbls.FirstOrDefault(x => x.CategoryId == id);
            if (categoryToDelete != null)
            {
                DataBase.CategoryTbls.Remove(categoryToDelete);
                DataBase.SaveChanges();
            }
            return GetAllCategorys() ;
        }

        //-----------------------------------------------------------------------------
        //------------------------------------Post-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<CategoryTbl> UpdateCategory(int id, CategoryTbl c)
        {
            CategoryTbl categoryToUpdate = DataBase.CategoryTbls.FirstOrDefault(x => x.CategoryId == id);
            if(categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = c.CategoryName;
                DataBase.SaveChanges();
            }
            return GetAllCategorys();
        }
    }
}
