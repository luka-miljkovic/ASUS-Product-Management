using DataAccessLayer.Implementation.Interfaces;
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
            throw new NotImplementedException();
        }

        public void Delete(Kupac enthity)
        {
            throw new NotImplementedException();
        }

        public Task<Kupac> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Kupac>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Kupac enthity)
        {
            throw new NotImplementedException();
        }
    }
}
