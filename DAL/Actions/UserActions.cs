using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Actions
{
    public class UserActions
    {
        static ToyStoreMiniProjectContext DataBase = new ToyStoreMiniProjectContext();

        //-----------------------------------------------------------------------------
        //-------------------------------------Get-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<UserTbl> GetAllUsers()
        {
            return DataBase.UserTbls.ToList();
        }

        public static UserTbl GetUserByEmailAndPassword(string email, string password)
        {
            UserTbl user = DataBase.UserTbls.FirstOrDefault(x => x.UserEmail.Equals(email) && x.UserPassword.Equals(password));
            if (user != null)
                return user;
            return null;
        }

        //-----------------------------------------------------------------------------
        //-------------------------------------Put-------------------------------------
        //-----------------------------------------------------------------------------
        public static bool AddUser(UserTbl u)
        {
            UserTbl nu = DataBase.UserTbls.FirstOrDefault(x => x.UserId == u.UserId);
            //if user does not exist.
            if (nu == null)
            {
                DataBase.UserTbls.Add(u);
                DataBase.SaveChanges();
                return true;
            }
            //if user already exists.
            return false;
        }

        //-----------------------------------------------------------------------------
        //------------------------------------Post-------------------------------------
        //-----------------------------------------------------------------------------
        public static List<UserTbl> UpdateUser(string id, UserTbl u)
        {

            UserTbl userToUpdate = DataBase.UserTbls.FirstOrDefault(x => x.UserId.Equals(id));
            userToUpdate.UserFirstName = u.UserFirstName;
            userToUpdate.UserLastName = u.UserLastName;
            userToUpdate.UserAddress = u.UserAddress;
            userToUpdate.UserEmail = u.UserEmail;
            userToUpdate.UserPhone = u.UserPhone;
            userToUpdate.UserPassword = u.UserPassword;
            DataBase.SaveChanges();

            return GetAllUsers();
        }
    }
}
