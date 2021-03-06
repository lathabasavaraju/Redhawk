using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;
using System.Net.Http.Headers;
using RedHawk.Model.AccountModel;
using RedHawk.UI.Common;
using RedHawk.Model.Common;

namespace RedHawk.UI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            TempData["IsValidLogin"] = false;
            MvcApplication.IsValidLogin = false;

            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            RedHawkToken redHawkToken = new RedHawkToken();
            EncryptDecrypt encryptDecrypt = new EncryptDecrypt();
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                if (loginModel != null)
                {
                    ServiceAuthentication serviceAuthentication = new ServiceAuthentication();
                    redHawkToken = serviceAuthentication.GetRedHawkServiceToken(loginModel);
                    Session["RedHawkToken"] = redHawkToken;
                    if (redHawkToken.IsAuthenticated)
                    {
                        var result = await ValidateLogin(loginModel);
                        switch (result)
                        {
                            case SignInStatus.Success:
                                {
                                    return RedirectToAction("Index", "Home");
                                }
                            case SignInStatus.LockedOut:
                                return View("Lockout");
                            case SignInStatus.RequiresVerification:
                                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = loginModel.RememberMe });
                            case SignInStatus.Failure:
                            default:
                                ViewBag.ErrorMessage = "The user name or password provided is incorrect";
                                return View(loginModel);
                        }
                    }
                    else
                        ViewBag.ErrorMessage = "The user name or password provided is incorrect";
                }
            }

            // If we got this far, something failed, redisplay form
            return View(loginModel);
        }

        private async Task<SignInStatus> ValidateLogin(LoginModel model)
        {

            SignInStatus res = SignInStatus.Failure;
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PostAsJsonAsync<LoginModel>("http://localhost:65023/api/Account/Validate", model);

                if (result.IsSuccessStatusCode)
                {
                   var msg = result.Content.ReadAsStringAsync().Result;
                    if (msg == "1")
                    {
                        TempData["IsValidLogin"] = true;
                        TempData["Username"] = model.UserName;
                        MvcApplication.Username = model.UserName;
                        MvcApplication.IsValidLogin = true;

                        res = SignInStatus.Success;
                    }
                    else
                    {
                        TempData["IsValidLogin"] = false;
                        MvcApplication.IsValidLogin = false;
                        res = SignInStatus.Failure;
                    }

                }
                else
                {
                    MvcApplication.IsValidLogin = false;
                    TempData["IsValidLogin"] = false;
                    res = SignInStatus.Failure;
                }


                return res;
            }
        }

     
        #region Logoff

        // GET: /Account/LogOff
        //
        public ActionResult LogOff()
        {

            return Redirect("/");
        }
        #endregion

        //
        //// GET: /Account/Register

        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    return View();
        //}


    }
}