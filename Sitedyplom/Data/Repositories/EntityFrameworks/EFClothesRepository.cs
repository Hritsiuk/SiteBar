using Microsoft.EntityFrameworkCore;
using Sitedyplom.Data.Repositories.Abstract;
using Sitedyplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Data.Repositories.EntityFrameworks
{
    public class EFClothesRepository : IClothesItemsRepository
    {
        private readonly ApplicationDbContext context;
        private IQueryable<Clothes> clothes;
        public EFClothesRepository(ApplicationDbContext context)
        {
            this.context = context;
            clothes = context.Clothes;
        }

        public IQueryable<Clothes> GetClothesItems()
        {
            return context.Clothes;
        }

        public Clothes GetClothesItemById(Guid id)
        {
            return context.Clothes.FirstOrDefault(x => x.Id == id);
        }

        public void SaveClothesItem(Clothes entity)
        {/*
            context.Entry(entity).State = EntityState.Added;// объект будет добавлен как новый*/
            if (context.Clothes.Where(p =>p.Id==entity.Id).First()==null)
            context.Clothes.Add(entity);

            context.SaveChanges();
        }

        public void DeleteClothesItem(string id)
        {
            context.Clothes.Remove(new Clothes() { Id = Guid.Parse(id) });
            context.SaveChanges();
        }

        public EFClothesRepository GetClothesbyColor(string color)
        {
            clothes = clothes.Where(p => p.color == color);
            return this;
        }
        public EFClothesRepository GetClothesbySize(string size)
        {
            clothes = clothes.Where(p => p.size == size);
            return this;
        }
        public EFClothesRepository GetClothesbyBrand(string brand)
        {

            clothes = clothes.Where(p => p.brand == brand);
            return this;
        }
        
        public IQueryable<Clothes> Get()
        {
            IQueryable<Clothes> p = clothes;
            clothes = context.Clothes;
            return p;
        }

    }
}
