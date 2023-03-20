using Kamban.API.Context;
using Kamban.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamban.API.Services
{
    public class EquipesService : IEquipeService
    {
        private readonly AppDbContext _context;

        public EquipesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Equipe>> GetEquipes()
        {
            try
            {
                return await _context.Equipes.ToListAsync();
            }
            catch 
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<Equipe>> GetEquipesByNome(string nome)
        {
            IEnumerable<Equipe> equipes;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                equipes = await _context.Equipes.Where(n => n.EquipeNome.Contains(nome)).ToListAsync();
            }
            else
            {
                equipes = await GetEquipes();
            }

            return equipes;
        }
        public async Task<Equipe> GetEquipe(int id)
        {
            var equipe = await _context.Equipes.FindAsync(id);

            return equipe;
        }
        public async Task CreateEquipe(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipe(Equipe equipe)
        {
            _context.Entry(equipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateEquipe(Equipe equipe)
        {
            _context.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();
        }
    }
}
