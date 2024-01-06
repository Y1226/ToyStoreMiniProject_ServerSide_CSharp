using AutoMapper;
using DAL.Actions;
using DAL.Models;
using Entities_DTO.Mapping;
using Entities_DTO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    public class CartBLL
    {
        //Mapper
        static IMapper _mapper;

        //DataBase
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        public static SalesDTO Checkout(string user, List<CartDTO> cart)
        {
            double finalPrice = 0;
            foreach (CartDTO item in cart)
            {
                finalPrice += item.FinalPrice;
            }
            SalesDTO sale = new SalesDTO();
            sale.UserId = user;
            sale.SaleDate = DateTime.UtcNow.ToString("d");
            sale.FinalPrice = finalPrice;
            SalesTbl s = _mapper.Map<SalesDTO, SalesTbl>(sale);
           
            SalesActions.AddSale(s);

            foreach (CartDTO item in cart)
            {
                SaleDetailsDTO sd = new SaleDetailsDTO();
                sd.SaleId = s.SaleId;
                sd.ProductId = item.ProductId;
                sd.ProductCount = item.AmountToBuy;
                SaleDetailsBLL.AddSaleDetails(sd);
            }

            return sale;
        }

        //-----------------------------------------------------------------------------
        //------------------------------------ctor-------------------------------------
        //-----------------------------------------------------------------------------
        static CartBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapped>();

            });
            _mapper = config.CreateMapper();
        }
    }
}
