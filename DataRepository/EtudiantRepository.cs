using IDataRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class EtudiantRepository : IEtudiantRepository
    {

        private TestCDAContext _context;

        public EtudiantRepository()
        {
            _context = TestCDAContext.Instance;
        }

        public async Task<Etudiant> CreateEleve(Etudiant stu)
        {
            _context.Etudiants.Add(stu);
            await _context.SaveChangesAsync();
            return stu;
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _context.Etudiants.FindAsync(id);
            if (student != null)
            {
                _context.Etudiants.Remove(student);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task<Etudiant> GetById(int id)
        {
            return await _context.Etudiants.FindAsync(id);
        }

        public IQueryable<Etudiant> GetEleves()
        {
            return _context.Etudiants;
        }

        public async Task<Etudiant> Update(Etudiant stu)
        {
            var existingEtudiant = await _context.Etudiants.FindAsync(stu.Id);
            if (existingEtudiant != null)
            {
                existingEtudiant.Prenom = stu.Prenom;
                existingEtudiant.Nom = stu.Nom;
                await _context.SaveChangesAsync();
            }
            return existingEtudiant;
        }

    }
}

         