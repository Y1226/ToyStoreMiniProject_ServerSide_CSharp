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
    public class UsersBLL
    {
        //Mapper
        static IMapper _mapper;

        //DataBase
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<UserDTO> GetAllUsers()
        {
            List<UserTbl> allData = UserActions.GetAllUsers();
            List<UserDTO> dataToReturn = new List<UserDTO>();

            //Go through the list of users in the table and convert each user to DTO.
            foreach (UserTbl item in allData)
            {
                UserDTO u = _mapper.Map<UserTbl, UserDTO>(item);
                dataToReturn.Add(u);
            }
            return dataToReturn;
        }

        public static UserTbl GetUserByEmailAndPassword(string email, string password)
        {
            return UserActions.GetUserByEmailAndPassword(email, password);
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static bool AddUser(UserDTO u)
        {
            UserTbl user = _mapper.Map<UserDTO, UserTbl>(u);
            return UserActions.AddUser(user);
        }

        //-----------------------------------------------------------------------------
        //------------------------------------Post-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<UserDTO> UpdateUser(string id, UserDTO u)
        {
            UserTbl user = _mapper.Map<UserDTO, UserTbl>(u);
            UserActions.UpdateUser(id, user);
            return GetAllUsers();
        }


        //-----------------------------------------------------------------------------
        //------------------------------------ctor-------------------------------------
        //-----------------------------------------------------------------------------
        static UsersBLL()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapped>();

            });
            _mapper = config.CreateMapper();
        }
    }
}
