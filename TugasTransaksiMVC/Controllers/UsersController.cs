using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TugasTransaksiAPI.Models;

using Newtonsoft.Json;

namespace TugasTransaksiMVC.Controllers
{
    public class UsersController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44360/API/")
        };

        public ActionResult Login()
        {
            ViewBag.Warning = TempData["Warning"];
            ViewBag.Success = TempData["Success"];
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult UpdatePassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            TempData["Success"] = "You are now logged out";
            return RedirectToAction("Login", "Users");
        }

        [HttpPost]
        public ActionResult UpdatePassword(Account account)
        {
            if (Session["Id"] != null)
            {
                account.AccountId = Convert.ToInt32(Session["Id"]);
                HttpResponseMessage result = client.PutAsJsonAsync("Accounts/Put/" + account.AccountId, account).Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Password Updated";
                    return RedirectToAction("Details", "Users", new { id = account.AccountId });
                }
                else
                {
                    ViewBag.Warning = "Something's wrong";
                    return View();
                };
            }
            else
            {
                TempData["Warning"] = "Please login before proceeding";
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult Details(int id)
        {
            if (Session["Id"] != null)
            {
                var respondTask = client.GetAsync("Employees/Get/" + id);
                respondTask.Wait();
                var result = respondTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();
                    Employee employee = readTask.Result;
                    return View(employee);
                }
                else
                {
                    ViewBag.Warning = "Something's wrong while fetching data";
                    return View();
                }
            } 
            else
            {
                TempData["Warning"] = "Please login before proceeding";
                return RedirectToAction("Login", "Users");
            }

        }

        [HttpPost]
        public ActionResult Login(VM_EmployeeAccount vM_EmployeeAccount)
        {
            HttpResponseMessage respondTask = client.PostAsJsonAsync("UserActions/Login", vM_EmployeeAccount).Result;
            var readTask = respondTask.Content.ReadAsStringAsync();
            readTask.Wait();
            int result = Convert.ToInt32(readTask.Result);
            Session["Id"] = result;
            if (Guid.TryParse(vM_EmployeeAccount.AccountPassword, out Guid guidResult))
            {
                return RedirectToAction("UpdatePassword", "Users");
            } else
            {
                return RedirectToAction("Details", "Users", new { id = result });
            }
        }

        [HttpPost]
        public ActionResult ForgotPassword(Employee employee)
        {
            HttpResponseMessage result = client.PostAsJsonAsync("UserActions/ForgotPassword", employee).Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["Success"] = "Check your email for your new temporary password";
                return RedirectToAction("Login", "Users");
            } 
            else
            {
                ViewBag.Warning = "Email not found";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Register(VM_EmployeeAccount vM_EmployeeAccount )
        {
            HttpResponseMessage result = client.PostAsJsonAsync("UserActions/Register", vM_EmployeeAccount).Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["Success"] = "Profile created, please login to continue";
                return RedirectToAction("Login", "Users");
            }
            else
            {
                ViewBag.Warning = "Something's wrong";
                return View();
            }
        }


    }
}