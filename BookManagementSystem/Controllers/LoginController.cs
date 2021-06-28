using BookManagementSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookManagementSystem.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginCheck(LoginDetails loginDetails)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:13591/BookManagementDetails/LoginCheck");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<LoginDetails>(client.BaseAddress, loginDetails);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Json("Login Succesully");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return Json("UserName or Password is Invalid !");
        }
    }
}
