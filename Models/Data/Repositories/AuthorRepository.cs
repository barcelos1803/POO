using System.Linq.Expressions;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int entityId)
        {
            var produto = _context.Authors.FirstOrDefault(x => x.Id == entityId);

            if (produto == null)
                return false;
            else
            {
                _context.Authors.Remove(produto);
                _context.SaveChanges();
                return true;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IList<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int entityId)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(Author entity)
        {
            _context.Authors.Add(entity);
            _context.SaveChanges();
        }

        public async Task<IList<Author>> SearchAll(Expression<Func<Author, bool>> predicate)
        {
            return await _context.Authors.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Update(Author entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}