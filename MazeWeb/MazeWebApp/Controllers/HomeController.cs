using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dal.Helper;
using Dal.Interfases;
using Dal.Interfases.Repository;
using Dal.Model;
using Microsoft.AspNetCore.Mvc;
using MazeWebApp.Models;

namespace MazeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customeRepository;

        public HomeController(ICustomerRepository customeRepository)
        {
            _customeRepository = customeRepository;
        }
        public IActionResult Index(CustomerSortEnum sortOrder = CustomerSortEnum.IdAsc)
        {
            ViewData["NameSort"] = sortOrder == CustomerSortEnum.NameAsc ? CustomerSortEnum.NameDesc : CustomerSortEnum.NameAsc;
            ViewData["ScoreSort"] = sortOrder == CustomerSortEnum.ScoreAsc ? CustomerSortEnum.ScoreDesc : CustomerSortEnum.ScoreAsc;
            ViewData["IdSort"] = sortOrder == CustomerSortEnum.IdAsc ? CustomerSortEnum.IdDesc : CustomerSortEnum.IdAsc;
            return View(_customeRepository.GetSortedCustomers(sortOrder).ToList());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
