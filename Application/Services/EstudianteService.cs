using LP3.BlazorServer.Data;
using LP3.BlazorServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LP3.BlazorServer.Application.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly ApplicationDbContext _context;

        public EstudianteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estudiante>> GetAllAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task AddAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var est = await _context.Estudiantes.FindAsync(id);
            if (est != null)
            {
                _context.Estudiantes.Remove(est);
                await _context.SaveChangesAsync();
            }
        }
    }
}