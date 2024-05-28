
using IBusinessLayer;
using IDataRepository;
using Models;


namespace BusinessLayer
{
    public class EtudiantBL : IEtudiantBL

    {
        private readonly IEtudiantRepository _EtudiantRepository;

        public EtudiantBL(IEtudiantRepository EtudiantRepository)
        {
            _EtudiantRepository = EtudiantRepository;
        }

        public async Task<Etudiant> CreateEleve(Etudiant stu)
        {
            return await _EtudiantRepository.CreateEleve(stu);
        }

        public async Task<bool> DeleteEleve(int id)
        {
            return await _EtudiantRepository.Delete(id);
        }

        public async Task<Etudiant> GetEleveById(int id)
        {
            return await _EtudiantRepository.GetById(id);
        }

        public IQueryable<Etudiant> GetEleves()
        {
            return _EtudiantRepository.GetEleves();
        }

        public async Task<Etudiant> UpdateEleve(Etudiant stu)
        {
            return await _EtudiantRepository.Update(stu);
        }

        public void Dispose()
        {
            _EtudiantRepository.Dispose();
        }
    }
}
