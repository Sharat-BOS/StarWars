using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWars.Models;
namespace StarWars.ViewModels
{
    public class PieViewModel
    {
        public string Title { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
