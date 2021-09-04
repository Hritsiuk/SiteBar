using Sitedyplom.Data.Repositories.EntityFrameworks;
using Sitedyplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Data.Repositories.Abstract
{
    public interface IClothesItemsRepository
    {

        IQueryable<Clothes> GetClothesItems();
        Clothes GetClothesItemById(Guid id);
        void SaveClothesItem(Clothes entity);
        void DeleteClothesItem(string id);
        public EFClothesRepository GetClothesbySize(string size);
        public EFClothesRepository GetClothesbyColor(string color);

    }
}
