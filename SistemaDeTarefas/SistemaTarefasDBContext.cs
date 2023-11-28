using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsuariosTarefasDAL.Data.Map;
using UsuariosTarefasDAL.Models;

namespace UsuariosTarefasDAL.Data
{
    public class SistemaTarefasDBContext : DbContext
    {

        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options)
        {




        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        
        }

    }
}
