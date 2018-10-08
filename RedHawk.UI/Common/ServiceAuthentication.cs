using RedHawk.Model.AccountModel;
using RedHawk.Model.Common;

namespace RedHawk.UI.Common
{
    public class ServiceAuthentication
    {
        public RedHawkToken GetRedHawkServiceToken(LoginModel loginModel)
        {
            EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
            RedHawkToken redHawkToken = new RedHawkToken();
            if (!string.IsNullOrEmpty(loginModel.UserName))
                if (!string.IsNullOrEmpty(loginModel.Password))
                {
                    string encryptPassword = encryptDecrypt.Encrypt(loginModel.Password);
                    redHawkToken.Password = encryptPassword;
                    redHawkToken.IsAuthenticated = true;
                    redHawkToken.UserName = loginModel.UserName;
                }
                else
                    redHawkToken.IsAuthenticated = false;
            else
                redHawkToken.IsAuthenticated = false;
            return redHawkToken;
        }
      

    }
}