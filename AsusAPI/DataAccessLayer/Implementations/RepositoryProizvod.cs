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
            throw new NotImplementedException();
        }

        public void Delete(Proizvod enthity)
        {
            throw new NotImplementedException();
        }

        public Task<Proizvod> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Proizvod>> GetAll()
        {
            return await context.Proizvodi.ToListAsync();
        }

        public void Update(Proizvod enthity)
        {
            throw new NotImplementedException();
        }
    }
}
