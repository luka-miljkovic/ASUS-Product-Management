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
    public class RepositoryGrad : IRepositoryGrad
    {
        private readonly AsusContext context;

        public RepositoryGrad(AsusContext context)
        {
            this.context = context;
        }
        public void Add(Grad enthity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Grad enthity)
        {
            throw new NotImplementedException();
        }

        public void Update(Grad enthity)
        {
            throw new NotImplementedException();
        }

        public Task<Grad> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Grad>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
