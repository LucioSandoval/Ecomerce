using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecomerce.Models;

namespace Ecom.Controllers
{
    public class AdminController : Controller
    {
        private MyContext _eContext;

        public AdminController(MyContext context)
        {
            _eContext = context;    
        }
        private Customer ActiveUser 
        {
            get 
            {
                return _eContext.customers.Where(u => u.customer_id == HttpContext.Session.GetInt32("customer_id") && u.role == true).FirstOrDefault();
            }
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}