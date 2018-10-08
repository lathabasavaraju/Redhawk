using Microsoft.AspNetCore.Mvc;
using RedHawk.Model.AccountModel;
using RedHawk.Model.Common;
using RedHawk.Service.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace RedHawk.Service.Controllers
{
    public class AccountController : Controller
    {
        AccountDAL accountDAL = new AccountDAL();
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        public IEnumerable<User> GetAllUsers()
        {
            return accountDAL.GetAllUsers();
        }


        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.ActionName("ValidateUser")]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/Validate")]

        public int ValidateUser([Microsoft.AspNetCore.Mvc.FromBody]LoginModel login)
        {
            EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
            IEnumerable<LoginModel> tempLogin;
           
            tempLogin = accountDAL.ValidateUser(login);
            if (tempLogin.Count() > 0)
            {
                return 1;
            }
            else
                return 0;
        }
        public bool ValidateRedHawkToken(string redHawkTokenUsername,string redHawkTokenPassword)
        {
            EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
            LoginModel loginModel = new LoginModel();
            IEnumerable<LoginModel> tempLogin;
            if (!string.IsNullOrEmpty(redHawkTokenUsername))
            {
                loginModel.UserName = redHawkTokenUsername;
            }
            else
                return false;

            if (!string.IsNullOrEmpty(redHawkTokenPassword))
            {
                loginModel.Password = encryptDecrypt.Decrypt(redHawkTokenPassword);
            }
            else
                return false;

            tempLogin = accountDAL.ValidateUser(loginModel);
            if (tempLogin.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
