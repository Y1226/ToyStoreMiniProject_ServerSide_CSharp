using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_DTO.Mapping;
using Entities_DTO.Repository;
using DAL.Models;
using DAL.Actions;

namespace BLL.Classes
{
    public class ProductBLL
    {
        //Mapper
        static IMapper _mapper;

        //DataBase
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductDTO> GetAllProducts()
        {
            List<ProductTbl> allData = ProductActions.GetAllProducts();
            List<ProductDTO> dataToReturn = new List<ProductDTO>();

            //Go through the list of Products in the table and convert each product to DTO.
            foreach (ProductTbl item in allData)
            {
                ProductDTO p = _mapper.Map<ProductTbl, ProductDTO>(item);
                dataToReturn.Add(p);
            }
            return dataToReturn;
        }

        public static ProductDTO GetProductByID(int id)
        {
            ProductTbl product = ProductActions.GetProductByID(id);
            ProductDTO p = _mapper.Map<ProductTbl, ProductDTO>(product);
            return p;

        }

        public static List<ProductDTO> GetProductByCategoryId(int id)
        {
            List<ProductTbl> product = ProductActions.GetProductByCategoryId(id);
            List<ProductDTO> list = new List<ProductDTO>();
            foreach (ProductTbl item in product)
            {
                ProductDTO p = _mapper.Map<ProductTbl, ProductDTO>(item);
                list.Add(p);
            }
            return list;

        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductDTO> AddProduct(ProductDTO p)
        {
            ProductTbl product = _mapper.Map<ProductDTO, ProductTbl>(p);
            ProductActions.AddProduct(product);
            return GetAllProducts();
        }

        //-----------------------------------------------------------------------------
        //------------------------------------Delete-----------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductDTO> DeleteProductById(int id)
        {
            ProductActions.DeleteProductById(id);
            return GetAllProducts();
        }

        //-----------------------------------------------------------------------------
        //------------------------------------Post-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<ProductDTO> UpdateProduct(int id, ProductDTO p)
        {
            ProductTbl product = _mapper.Map<ProductDTO, ProductTbl>(p);
            ProductActions.UpdateProduct(id, product);
            return GetAllProducts();
        }


        //-----------------------------------------------------------------------------
        //------------------------------------ctor-------------------------------------
        //-----------------------------------------------------------------------------
        static ProductBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapped>();

            });
            _mapper = config.CreateMapper();
        }
    }
}
