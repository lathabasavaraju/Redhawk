using RedHawk.Model.AccountModel;
using RedHawk.Model.Common;
using RedHawk.Service.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedHawk.API.Controllers
{
    public class AccountController : ApiController
    {
        // GET api/values
        public IEnumerable<User> Get()
        {
            AccountDAL accountDAL = new AccountDAL();
            return accountDAL.GetAllUsers();
        }

        [HttpPost]
        public int Validate([FromBody]LoginModel login)
        {
            EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
            IEnumerable<LoginModel> tempLogin;

            AccountDAL accountDAL = new AccountDAL();
            tempLogin = accountDAL.ValidateUser(login);
            if (tempLogin.Count() > 0)
            {
                return 1;
            }
            else
                return 0;
        }

        public bool ValidateRedHawkToken(string redHawkTokenUsername, string redHawkTokenPassword)
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

            AccountDAL accountDAL = new AccountDAL();
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
