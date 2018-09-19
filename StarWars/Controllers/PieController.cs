using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWars.Models;
using StarWars.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWars.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository) {
            _pieRepository = pieRepository;
        }
        // GET: /<controller>/
        public IActionResult List()
        {         
            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);
            //Here we are using two different classes to populate all data required for the view. which is not ideal so we can create a view Model to populate all data required to populate the view.
            var pieViewModel = new PieViewModel() {
                Title = "Pie Shop",
                Pies = pies.ToList()
            };
            return View(pieViewModel);
        }

    }
}
