using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EleveRepository : IEleveRepository
    {
        private List<Eleve> eleves = new List<Eleve>();
        private int _nextId = 1;


        public EleveRepository()
        {
            Add(new Eleve { Nom="BIRAM", Prenom="Steeve Ursil" , Matricule = "1145EYRU35", Classe = "3ième" });
            Add(new Eleve { Nom = "POUTONG", Prenom = "Thierry", Matricule = "1145KJDU45", Classe = "2nd" });
            Add(new Eleve { Nom = "KENTSA", Prenom = "Arthur", Matricule = "1145KJDU45", Classe = "Tle" });
        }
        public Eleve Add(Eleve item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            eleves.Add(item);
            return item;
        }

        public Eleve Get(int id)
        {
            return eleves.Find(p => p.Id == id);
        }

        public IEnumerable<Eleve> GetAll()
        {
            return eleves;
        }

        public void Remove(int id)
        {
            eleves.RemoveAll(p => p.Id == id);
        }

        public bool Update(Eleve item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = eleves.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            eleves.RemoveAt(index);
            eleves.Add(item);
            return true;
        }

        
    }

}