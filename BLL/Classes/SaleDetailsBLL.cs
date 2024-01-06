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
    public class SaleDetailsBLL
    {
        //Mapper
        static IMapper _mapper;

        //DataBase
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SaleDetailsDTO> GetAllSaleDetails()
        {
            List<SaleDetailsTbl> allData = SaleDetailsActions.GetAllSaleDetails();
            List<SaleDetailsDTO> dataToReturn = new List<SaleDetailsDTO>();

            //Go through the list of sale details in the table and convert each sale detail to DTO.
            foreach (SaleDetailsTbl item in allData)
            {
                SaleDetailsDTO s = _mapper.Map<SaleDetailsTbl, SaleDetailsDTO>(item);
                dataToReturn.Add(s);
            }
            return dataToReturn;
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<SaleDetailsDTO> AddSaleDetails(SaleDetailsDTO s)
        {
            SaleDetailsTbl saleDetail = _mapper.Map<SaleDetailsDTO, SaleDetailsTbl>(s);
            SaleDetailsActions.AddSaleDetails(saleDetail);

            return GetAllSaleDetails();
        }

        //-----------------------------------------------------------------------------
        //------------------------------------ctor-------------------------------------
        //-----------------------------------------------------------------------------
        static SaleDetailsBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapped>();

            });
            _mapper = config.CreateMapper();
        }
    }
}
