using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
    //If i need to use MockPie repository from different parts of the application 
    //I need to register it using dependency injection. For that we need to go back to startup.cs class 
    public class MockPieRepository : IPieRepository
    {
        private List<Pie> _pies;

        public MockPieRepository() {
            if (_pies == null) {
                InitializePies();
            }
        }
        private void InitializePies() {
            _pies = new List<Pie>
            {
                new Pie { Id=1,Name="Apple Pie",Price=12.95,ShortDescription="",LongDescription="",   ImageUrl =""},
                new Pie { Id=1,Name="Blueberry Pie",Price=11.95,ShortDescription="",LongDescription="",  ImageUrl =""},
                new Pie { Id=1,Name="Cheese Cake",Price=15.95,ShortDescription="",LongDescription="",  ImageUrl =""},
                new Pie { Id=1,Name="Cherry Pie",Price=10.95,ShortDescription="",LongDescription="",  ImageUrl =""}
            };
        }
        IEnumerable<Pie> IPieRepository.GetAllPies()
        {
            return _pies;
        }

        Pie IPieRepository.GetPieByID(int pieId)
        {
            return _pies.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
