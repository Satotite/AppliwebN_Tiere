using Models;


namespace IBusinessLayer
{
    public interface IEtudiantBL
    {
        IQueryable<Etudiant> GetEleves();

        // Méthode pour créer un élève
        Task<Etudiant> CreateEleve(Etudiant stu);

        // Méthode pour obtenir les détails d'un élève
        Task<Etudiant> GetEleveById(int id);

        // Méthode pour mettre à jour un élève
        Task<Etudiant> UpdateEleve(Etudiant stu);

        // Méthode pour supprimer un élève
        Task<bool> DeleteEleve(int id);
    }
}
