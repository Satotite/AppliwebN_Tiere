using BusinessLayer;
using Castle.Windsor;
using DataRepository;
using IBusinessLayer;
using IDataRepository;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace WebCDA.Controllers
{
    public class EtudiantsController : Controller
    {


        private static WindsorContainer InitDependency()
        {
            var container = new WindsorContainer();
            container.Register(Castle.MicroKernel.Registration.Component.For<IEtudiantRepository>().ImplementedBy<EtudiantRepository>());
            container.Register(Castle.MicroKernel.Registration.Component.For<IEtudiantBL>().ImplementedBy<EtudiantBL>());
            return container;
        }

        IEtudiantBL context = InitDependency().Resolve<IEtudiantBL>();




        //-------------------------------------------------------------------------


        // GET: StudentsController
        public ActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var etudiants = context.GetEleves().ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                etudiants = etudiants.Where(e => e.Nom.Contains(searchString)).ToList();
            }

            return View(etudiants);
        }

        //// GET: EtudiantsController/Details/5
        // GET: EtudiantsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var etudiants = await context.GetEleveById(id);
            if (etudiants == null)
            {
                return NotFound();
            }
            return View(etudiants);
        }

        // GET: EtudiantsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtudiantsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Etudiant stu)
        {
            try
            {
                await context.CreateEleve(stu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: EtudiantsController/Edit
        public async Task<ActionResult> Edit(int id)
        {
            var etudiants = await context.GetEleveById(id);
            if (etudiants == null)
            {
                return NotFound();
            }
            return View(etudiants);
        }

        // POST: EtudiantsController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Edit(int id, Etudiant stu)
        {
            try
            {
                await context.UpdateEleve(stu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: EtudiantsController/Delete
        public async Task<ActionResult> Delete(int id)
        {
            var etudiants = await context.GetEleveById(id);
            if (etudiants == null)
            {
                return NotFound();
            }
            return View(etudiants);
        }

        // POST: EtudiantsController/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await context.DeleteEleve(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

}
