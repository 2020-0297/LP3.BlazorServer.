using LP3.BlazorServer.Shared.DTOs;

namespace LP3.BlazorServer.Application.Services
{
    public interface IProfesorService
    {
        Task<List<ProfesorDto>> GetAllAsync();
        Task<ProfesorDto?> GetByIdAsync(int id);
        Task<ProfesorDto> CreateAsync(ProfesorDto dto);
        Task UpdateAsync(int id, ProfesorDto dto);
        Task DeleteAsync(int id);
    }
}
