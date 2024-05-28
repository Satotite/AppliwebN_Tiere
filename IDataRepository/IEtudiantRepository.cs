using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataRepository
{
    public interface IEtudiantRepository 
    {
        // Méthode pour obtenir la liste des élèves
        IQueryable<Etudiant> GetEleves();

        // Méthode pour créer un élève
        Task<Etudiant> CreateEleve(Etudiant stu);

        // Méthode pour obtenir les détails d'un élève
        Task<Etudiant> GetById(int id);

        // Méthode pour mettre à jour un élève
        Task<Etudiant> Update(Etudiant stu);

        // Méthode pour supprimer un élève
        Task<bool> Delete(int id);
        void Dispose();
    }

}
