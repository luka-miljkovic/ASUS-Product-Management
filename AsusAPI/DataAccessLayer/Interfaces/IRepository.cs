using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<TEnthity> where TEnthity : class
    {
        public void Add(TEnthity enthity);
        public void Update(TEnthity enthity);
        public void Delete(TEnthity enthity);
        public List<TEnthity> GetAll();
        public TEnthity FindById(int id);
    }
}
