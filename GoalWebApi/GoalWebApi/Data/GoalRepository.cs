using GoalWebApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GoalWebApi.Data
{
    public class GoalRepository<T> : IUnitOfWork, IDisposable where T : Entity
    {
        private readonly GoalContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public GoalRepository(GoalContext context)
        {
            _context = context;
        }
        public void Add(T objeto)
        {
            _context.Set<T>().Add(objeto);
        }

        public void Update(T objeto)
        {
            _context.Set<T>().Update(objeto);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<bool> Commit()
        {
            return await _context?.Commit();
        }
    }
}
