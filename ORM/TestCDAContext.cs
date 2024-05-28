using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;


namespace ORM
{
    public partial class TestCDAContext : DbContext
    {

        //------------------------------------------------------------------------------------------------------------------------------
        //pool de connexion avec le pattern singleton
        //patern singleton -- Pour disposer d'une seul instance et éviter des connexions inutiles qui dégradent les performances de la BDD
        private static readonly object _padlock = new object();
        private static TestCDAContext? _instance;
        //méthode statique qui renvoit une instance de ConDB
        public static TestCDAContext Instance
        {
            get
            {
                //check pour éviter l'accés multi-thread
                lock (_padlock)
                {
                    if (_instance == null) //si null on instancié
                        _instance = new TestCDAContext();
                    return _instance;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------


        public TestCDAContext()
        {
        }

        public TestCDAContext(DbContextOptions<TestCDAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Etudiant> Etudiants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-1BGEPCDA;Initial Catalog=TestCDA;Integrated Security=True;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.ToTable("Etudiant");

               // entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Prenom).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
