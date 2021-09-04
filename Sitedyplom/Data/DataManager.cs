using Sitedyplom.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sitedyplom.Data
{
    public class DataManager
    {
      
        public IClothesItemsRepository Clothes { get; set; }

        public DataManager(IClothesItemsRepository clothesRepository)
        {
            Clothes = clothesRepository;
        }
    }
}
