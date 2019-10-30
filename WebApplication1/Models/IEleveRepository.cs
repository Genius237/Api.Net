using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface IEleveRepository
    {
        IEnumerable<Eleve> GetAll();
        Eleve Get(int id);
        Eleve Add(Eleve item);
        void Remove(int id);
        bool Update(Eleve item);
    }
}
