using Kamban.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamban.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Equipe> Equipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipe>().HasData(
                    new Equipe
                    {
                        EquipeId = 1,
                        EquipeNome = "Equipe Paulo Henrique",
                        Abreviacao = "PH"
                    },
                    new Equipe
                    {
                        EquipeId = 2,
                        EquipeNome = "Equipe Antonio Silveira",
                        Abreviacao = "AS"
                    }
                );
        }
    }
}
