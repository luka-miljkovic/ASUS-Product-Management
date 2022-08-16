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
    public class RepositoryKupac : IRepositoryKupac
    {
        private readonly AsusContext context;

        public RepositoryKupac(AsusContext context)
        {
            this.context = context;
        }
        public void Add(Kupac enthity)
        {
            enthity.Grad = context.Gradovi.Find(enthity.Grad.PostanskiBroj, enthity.Grad.IDDrzave);
            try
            {
                context.Add(enthity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Kupac enthity)
        {
            context.Kupci.Remove(enthity);
        }

        public Task<Kupac> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Kupac>> GetAll()
        {
            var result = await context.Kupci.ToListAsync();
            foreach(var kupac in result)
            {
                kupac.Grad = context.Gradovi.Find(kupac.PostanskiBroj, kupac.IDDrzave);
            }
            return result;
        }

        public Task<List<Kupac>> GetAllWithCondition(int condition)
        {
            throw new NotImplementedException();
        }

        public void Update(Kupac enthity)
        {
            enthity.Grad = context.Gradovi.Find(enthity.Grad.PostanskiBroj, enthity.Grad.IDDrzave);
            try
            {
                context.Update(enthity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
