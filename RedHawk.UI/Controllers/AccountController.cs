using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using RedHawk.Model.AccountModel;
using System.IO;

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
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true

                var result = await ValidateLogin(model);
                switch (result)
                {
                    case SignInStatus.Success:
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        ViewBag.ErrorMessage = "The user name or password provided is incorrect";
                        return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public async Task<SignInStatus> ValidateLogin(LoginModel model)
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

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {

            return Redirect("/");
        }

        //
        //// GET: /Account/Register

        //[AllowAnonymous]
        //public ActionResult Register()
        //{
        //    return View();
        //}


    }
}