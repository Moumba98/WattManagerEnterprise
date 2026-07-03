using System.Collections.Generic;
using System.Threading.Tasks;
using WattManager.Domain.Entities;
using WattManager.Application.Interfaces; 

namespace WattManager.Application.Interfaces
{
    public interface IIngenieurService
    {
        Task<IEnumerable<Ingenieur>> GetAllWithCentralesAsync();
        Task<Ingenieur> CreateAsync(Ingenieur ingenieur);
    }
}