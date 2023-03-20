using Kamban.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kamban.API.Services
{
    public interface IEquipeService
    {
        Task<IEnumerable<Equipe>> GetEquipes();
        Task<IEnumerable<Equipe>> GetEquipesByNome(string nome);
        Task<Equipe> GetEquipe(int id);   
        Task CreateEquipe(Equipe equipe);
        Task UpdateEquipe(Equipe equipe);
        Task DeleteEquipe(Equipe equipe);

    }
}
