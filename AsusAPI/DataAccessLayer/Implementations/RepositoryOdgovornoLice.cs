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
    public class RepositoryOdgovornoLice : IRepositoryOdgovornoLice
    {
        private readonly AsusContext context;

        public RepositoryOdgovornoLice(AsusContext context)
        {
            this.context = context;
        }
        public void Add(OdgovornoLice enthity)
        {
            context.Add(enthity);
        }

        public void Delete(OdgovornoLice enthity)
        {
            context.Remove(enthity);
        }

        public Task<OdgovornoLice> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OdgovornoLice>> GetAll()
        {
            return await context.OdgovornaLica.ToListAsync();
        }

        public Task<List<OdgovornoLice>> GetAllWithCondition(int condition)
        {
            throw new NotImplementedException();
        }

        public void Update(OdgovornoLice enthity)
        {
            context.Entry(enthity).State = EntityState.Modified;
        }
    }
}
