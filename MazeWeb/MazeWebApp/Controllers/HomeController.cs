using MazeWebApp.Models;
using MazeWebCore.Helpers;
using MazeWebCore.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

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
