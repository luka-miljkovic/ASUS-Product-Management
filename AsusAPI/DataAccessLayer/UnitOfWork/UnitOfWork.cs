using DataAccessLayer.Implementation.Interfaces;
using DataAccessLayer.Implementations;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AsusContext context;

        public UnitOfWork(AsusContext context)
        {
            this.context = context;
            OdgovornoLiceRepository = new RepositoryOdgovornoLice(context);
            TrzisteRepository = new RepositoryTrziste(context);
            DrzavaRepository = new RepositoryDrzava(context);
            GradRepository = new RepositoryGrad(context);
            KupacRepository = new RepositoryKupac(context);
            ProizvodRepository = new RepositoryProizvod(context);
            KarakteristikaRepository = new RepositoryKarakteristika(context);

        }
        public IRepositoryOdgovornoLice OdgovornoLiceRepository { get ; set ; }
        public IRepositoryTrziste TrzisteRepository { get ; set ; }
        public IRepositoryDrzava DrzavaRepository { get ; set ; }
        public IRepositoryGrad GradRepository { get ; set ; }
        public IRepositoryKupac KupacRepository { get ; set; }
        public IRepositoryProizvod ProizvodRepository { get ; set ; }
        public IRepositoryKarakteristika KarakteristikaRepository { get ; set ; }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
