using LP3.BlazorServer.Data.Repositories;
using LP3.BlazorServer.Domain.Entities;

namespace LP3.BlazorServer.Application.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repository;

        public EstudianteService(IEstudianteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Estudiante>> GetAllAsync()
        {
            var data = await _repository.ListAsync();
            return data.ToList();
        }

        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Estudiante estudiante)
        {
            await _repository.AddAsync(estudiante);
        }

        public async Task UpdateAsync(Estudiante estudiante)
        {
            await _repository.Update(estudiante);
        }

        public async Task DeleteAsync(int id)
        {
            var est = await _repository.GetByIdAsync(id);
            if (est != null)
            {
                await _repository.Remove(est);
            }
        }
    }
}