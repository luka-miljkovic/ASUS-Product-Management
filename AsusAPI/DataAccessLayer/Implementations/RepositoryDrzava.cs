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
    public class RepositoryDrzava : IRepositoryDrzava
    {
        private readonly AsusContext context;

        public RepositoryDrzava(AsusContext context)
        {
            this.context = context;
        }
        public void Add(Drzava enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Drzava enthity)
        {
            throw new NotImplementedException();
        }

        public void Update(Drzava enthity)
        {
            throw new NotImplementedException();
        }

        public async Task<Drzava> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Drzava>> GetAll()
        {
            var result =  await context.Drzave.ToListAsync();
            foreach (var drzava in result)
            {
                drzava.Gradovi = await context.Gradovi.Where(x => x.IDDrzave == drzava.IDDrzave).ToListAsync();
            }
            return result;
        }
    }
}
