using AutoMapper;
using System.Threading.Tasks;
using Entities_DTO.Mapping;
using Entities_DTO.Repository;
using DAL.Models;
using DAL.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
        public class CategoryBLL
        {
            //Mapper
            static IMapper _mapper;

            //DataBase
            static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

            //-----------------------------------------------------------------------------
            //-------------------------------------Get-------------------------------------
            //-----------------------------------------------------------------------------
            public static List<CategoryDTO> GetAllCategorys()
            {
                List<CategoryTbl> allData = CategoryActions.GetAllCategorys();
                List<CategoryDTO> dataToReturn = new List<CategoryDTO>();

                //Go through the list of Categorys in the table and convert each category to DTO.
                foreach (CategoryTbl item in allData)
                {
                    CategoryDTO c = _mapper.Map<CategoryTbl, CategoryDTO>(item);
                    dataToReturn.Add(c);
                }
                return dataToReturn;
            }

            //-----------------------------------------------------------------------------
            //-------------------------------------Put-------------------------------------
            //-----------------------------------------------------------------------------
            public static List<CategoryDTO> AddCategory(CategoryDTO c)
            {
                CategoryTbl category = _mapper.Map<CategoryDTO, CategoryTbl>(c);
                CategoryActions.AddCategory(category);
                return GetAllCategorys();

            }

            //-----------------------------------------------------------------------------
            //------------------------------------Delete-----------------------------------
            //-----------------------------------------------------------------------------
            public static List<CategoryDTO> DeleteCategoryById(int id)
            {
                CategoryActions.DeleteCategoryById(id);
                return GetAllCategorys();
            }

            //-----------------------------------------------------------------------------
            //------------------------------------Post-------------------------------------
            //-----------------------------------------------------------------------------
            public static List<CategoryDTO> UpdateCategory(int id, CategoryDTO c)
            {
                CategoryTbl category = _mapper.Map<CategoryDTO, CategoryTbl>(c);
                CategoryActions.UpdateCategory(id, category);
                return GetAllCategorys();
            }


            //-----------------------------------------------------------------------------
            //------------------------------------ctor-------------------------------------
            //-----------------------------------------------------------------------------
            static CategoryBLL()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<AutoMapped>();

                });
                _mapper = config.CreateMapper();
            }
        }
    }
