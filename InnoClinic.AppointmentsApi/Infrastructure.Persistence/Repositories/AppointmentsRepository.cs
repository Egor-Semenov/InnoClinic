using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class AppointmentsRepository : IBaseRepository<Appointment>
    {
        private readonly ApplicationDbContext _dbContext;

        public AppointmentsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Appointment entity)
        {
            _dbContext.Set<Appointment>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Appointment entity)
        {
            _dbContext.Set<Appointment>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Appointment> FindAll(bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Appointment>()
                .AsNoTracking() :
            _dbContext.Set<Appointment>();

        public IQueryable<Appointment> FindByCondition(Expression<Func<Appointment, bool>> expression, bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Appointment>()
                .Where(expression)
                .AsNoTracking() :
            _dbContext.Set<Appointment>()
            .Where(expression);

        public Task Update(Appointment entity)
        {
            _dbContext.Set<Appointment>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
