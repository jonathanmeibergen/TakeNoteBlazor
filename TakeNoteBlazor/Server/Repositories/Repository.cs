using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeNoteBlazor.Server.Data;
using TakeNoteBlazor.Shared;

namespace TakeNoteBlazor.Server.Repositories
{
	public class Repository<T> : IRepository<T> where T : class, IEntity
	{
		private TakeNoteContext _dbContext;
		private DbSet<T> _set;

		public Repository(TakeNoteContext dbContext)
		{
			_dbContext = dbContext;
			_set = dbContext.Set<T>();
		}
		public async Task<T> GetAsync(int id)
		{
			return await new Task<T>(() => _set.FirstOrDefault(n => n.Id.Equals(id)));
		}
		public async Task<List<T>> TakeAsync(int index, int ammount)
		{
			return await new Task<List<T>>(() => _set.OrderByDescending(n => n.Id)
													 .Skip(index)
													 .Take(ammount)
													 .ToList());
		}
		public async Task<List<T>> GetAllAsync()
		{
			return await new Task<List<T>>(() => _set.OrderByDescending(n => n.Id)
													 .ToList());
		}
		public async Task<int> GetTotalAsync()
		{
			return await new Task<int>(() => _set.Count());
		}
		public async Task<int> ChangeStateAndSaveAsync(T entity, EntityState state)
		{
			_dbContext.Entry(entity).State = state;
			return await _dbContext.SaveChangesAsync();
		}
		public async Task<int> AddAndSaveAsync(T entity)
		{
			await _set.AddAsync(entity);
			return await _dbContext.SaveChangesAsync();
		}
		public async Task<int> DeleteAndSaveAsync(int id)
		{
			await new Task(() =>
			{
				var note = _set.Find(id);
				_set.Remove(note);
			});
			return await _dbContext.SaveChangesAsync();
		}
	}
}
