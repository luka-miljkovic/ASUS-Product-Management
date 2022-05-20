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

        public Proizvod FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Proizvod> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Proizvod enthity)
        {
            throw new NotImplementedException();
        }
    }
}
