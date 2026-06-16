using LP3.BlazorServer.Domain.Entities;

namespace LP3.BlazorServer.Application.Services
{
    public interface IEstudianteService
    {
        Task<List<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
        Task AddAsync(Estudiante estudiante);
        Task UpdateAsync(Estudiante estudiante);
        Task DeleteAsync(int id);
    }
}