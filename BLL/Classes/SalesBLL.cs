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
    public class SalesBLL
    {
        //Mapper
        static IMapper _mapper;

        //DataBase
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SalesDTO> GetAllSales()
        {
            List<SalesTbl> allData = SalesActions.GetAllSales();
            List<SalesDTO> dataToReturn = new List<SalesDTO>();

            //Go through the list of sales in the table and convert each sale to DTO.
            foreach (SalesTbl item in allData)
            {
                SalesDTO s = _mapper.Map<SalesTbl, SalesDTO>(item);
                dataToReturn.Add(s);
            }
            return dataToReturn;
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SalesDTO> AddSale(SalesDTO s)
        {
            SalesTbl sale = _mapper.Map<SalesDTO, SalesTbl>(s);
            SalesActions.AddSale(sale);

            return GetAllSales();
        }

        //-----------------------------------------------------------------------------
        //------------------------------------ctor-------------------------------------
        //-----------------------------------------------------------------------------
        static SalesBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapped>();

            });
            _mapper = config.CreateMapper();
        }
    }
}
