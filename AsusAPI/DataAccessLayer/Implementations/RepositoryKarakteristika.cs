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
    public class RepositoryKarakteristika : IRepositoryKarakteristika
    {
        private readonly AsusContext context;

        public RepositoryKarakteristika(AsusContext context)
        {
            this.context = context;
        }
        public void Add(Karakteristika enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Karakteristika enthity)
        {
            throw new NotImplementedException();
        }

        public void Update(Karakteristika enthity)
        {
            throw new NotImplementedException();
        }

        public Task<Karakteristika> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Karakteristika>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
