
using System.Linq.Expressions;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool Delete(int entityId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == entityId);

            if (user == null)
                return false;
            else
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByBorrowedBooks(int UserId)
        {
            return await _context.Users.AsNoTracking()
            .Include(j => j.BorrowedBooks)
            .FirstOrDefaultAsync(x => x.Id == UserId);

        }

        public async Task<User> GetByIdAsync(int entityId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Id == entityId);
        }

        public void Save(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public async Task<IList<User>> SearchAll(Expression<Func<User, bool>> predicate)
        {
            return await _context.Users.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}