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

        public OdgovornoLice FindById(int id)
        {
            return context.OdgovornaLica.Single(ol => ol.SifraRadnika == id);
        }

        public List<OdgovornoLice> GetAll()
        {
            return context.OdgovornaLica.ToList();
        }

        public void Update(OdgovornoLice enthity)
        {
            context.Entry(enthity).State = EntityState.Modified;
        }
    }
}
