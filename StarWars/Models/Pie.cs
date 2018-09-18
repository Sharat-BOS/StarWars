using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Models
{
       public class Pie 
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        //adding Virtual Key word to navigation property will make it a lazy loading property.
        //Means it will only be loaded the first time we access the category property.
        //Virtual or not depeands on situation 1.lazyloading makes sense if you think you are not going to acces this property often or 2.if loading related data in one go will cost a lot of processing(large data). Leave it out if you are going it access it anyway.
        //public virtual Category Category { get; set; }

    }
    
}
