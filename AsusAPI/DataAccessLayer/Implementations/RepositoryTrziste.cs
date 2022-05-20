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
    public class RepositoryTrziste : IRepositoryTrziste
    {
        private readonly AsusContext context;

        public RepositoryTrziste(AsusContext context)
        {
            this.context = context;
        }
        public void Add(Trziste enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Trziste enthity)
        {
            throw new NotImplementedException();
        }

        public Task<Trziste> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Trziste>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Trziste enthity)
        {
            throw new NotImplementedException();
        }
    }
}
