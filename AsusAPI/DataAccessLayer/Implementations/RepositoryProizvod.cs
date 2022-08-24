using DataAccessLayer.Implementation.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implementations
{
    public class RepositoryProizvod : IRepositoryProizvod
    {
        private readonly AsusContext context;

        public RepositoryProizvod(AsusContext context)
        {
            this.context = context;
        }
        public void Add(Proizvod enthity)
        {
            try
            {
                context.Proizvodi.Add(enthity);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void Delete(Proizvod enthity)
        {
            context.Proizvodi.Remove(enthity);
        }

        public Task<Proizvod> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Proizvod>> GetAll()
        {
            var result = await context.Proizvodi.ToListAsync();

            foreach(Proizvod p in result)
            {
                p.Karakteristike = await context.Karakteristike.Where(k => k.SifraProizvoda == p.SifraProizvoda).ToListAsync();
            }

            return result;
        }

        public Task<List<Proizvod>> GetAllWithCondition(int condition)
        {
            throw new NotImplementedException();
        }

        public void Update(Proizvod enthity)
        {
            AsusContext context1 = new AsusContext();
            //context.Set<Karakteristika>().AsNoTracking();
            var karakteristike = context1.Karakteristike;  
            //var karakteristike1 = context.Karakteristike;

            foreach (var k in karakteristike)
            {
                bool delete = true;
                foreach (Karakteristika karakteristika in enthity.Karakteristike)
                {
                    if (k.SifraProizvoda == karakteristika.SifraProizvoda && k.IDKarakteristike == karakteristika.IDKarakteristike)
                    {
                        delete = false;
                    }
                }
                if (delete)
                {
                    context.Karakteristike.Remove(k);
                    enthity.Karakteristike.Remove(k);
                }

            }
            context.SaveChanges();

            foreach (var k in enthity.Karakteristike)
            {
                if (!context.Karakteristike.Contains(k))
                {
                    k.SifraProizvoda = enthity.SifraProizvoda;
                    context.Karakteristike.Add(k);
                    context.SaveChanges();
                }
            }

            try
            {
                //context.Entry(enthity).State = EntityState.Detached;
                context.Proizvodi.Update(enthity);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
