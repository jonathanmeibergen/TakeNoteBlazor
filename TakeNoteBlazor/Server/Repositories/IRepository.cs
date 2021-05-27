using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Repositories
{
    public interface IRepository<T>
    {
        public Task<T> GetAsync(int id);
        public Task<List<T>> TakeAsync(int index, int ammount);
        public Task<List<T>> GetAllAsync();
        public Task<int> GetTotalAsync();
        public Task<int> ChangeStateAndSaveAsync(T entity, EntityState state);
        public Task<int> AddAndSaveAsync(T entity);
        public Task<int> DeleteAndSaveAsync(int id);
    }
}
