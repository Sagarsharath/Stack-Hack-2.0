using HRM.Rest.Services.DAL.Context;
using HRM.Rest.Services.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Rest.Services.DAL.CRUD
{
    public class UserInfoDBOperations
    {
        private readonly UserDbContext _context;

        public UserInfoDBOperations(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }

        public bool checkIfUserExists(UserInfo userInfo)
        {
            var user = _context.User_Info.Any(s => s.UserEmailId == userInfo.UserEmailId);
            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public UserInfo SaveUserInfo(UserInfo userInfo)
        {
           userInfo.Password = Util.Crypto.Encrypt(userInfo.Password);
            _context.User_Info.Add(userInfo);
            _context.SaveChanges();
            return userInfo;
        }
    }
}
