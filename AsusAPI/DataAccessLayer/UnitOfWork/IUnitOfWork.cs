using DataAccessLayer.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryOdgovornoLice OdgovornoLiceRepository { get; set; }
        public IRepositoryTrziste TrzisteRepository { get; set; }
        public IRepositoryDrzava DrzavaRepository { get; set; }
        public IRepositoryGrad GradRepository { get; set; }
        public IRepositoryKupac KupacRepository { get; set; }
        public IRepositoryProizvod ProizvodRepository { get; set; }
        public IRepositoryKarakteristika KarakteristikaRepository  { get; set; }
        public void Commit();
    }
}
