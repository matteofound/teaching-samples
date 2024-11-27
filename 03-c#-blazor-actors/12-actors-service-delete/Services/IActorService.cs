using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using project.Models;

namespace project.Services
{
    public interface IActorService
    {
        Task<List<Actor>> GetActorsAsync(bool reload = false);

        Task<List<Actor>> AddAsync(string firstName, string lastName, string country);

        Task<List<Actor>> DeleteAsync(Actor actor);
    }
}
