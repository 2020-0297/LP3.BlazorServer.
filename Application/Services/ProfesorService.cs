using LP3.BlazorServer.Data.Repositories;
using LP3.BlazorServer.Domain.Entities;
using LP3.BlazorServer.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LP3.BlazorServer.Application.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly IRepository<Profesor> _repository;

        public ProfesorService(IRepository<Profesor> repository)
        {
            _repository = repository;
        }

        public async Task<List<ProfesorDto>> GetAllAsync()
        {
            // Usamos ListAsync() que es el método real de tu repositorio
            var profesores = await _repository.ListAsync();
            return profesores.Select(p => new ProfesorDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Correo = p.Correo,
                Especialidad = p.Especialidad,
                Activo = p.Activo
            }).ToList();
        }

        public async Task<ProfesorDto?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id) is { } p ? new ProfesorDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Correo = p.Correo,
                Especialidad = p.Especialidad,
                Activo = p.Activo
            } : null;
        }

        public async Task<ProfesorDto> CreateAsync(ProfesorDto dto)
        {
            var p = new Profesor
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Especialidad = dto.Especialidad,
                Activo = true
            };

            await _repository.AddAsync(p);
            dto.Id = p.Id; // El Id se llena automáticamente al guardar
            return dto;
        }

        public async Task UpdateAsync(int id, ProfesorDto dto)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p != null)
            {
                p.Nombre = dto.Nombre;
                p.Apellido = dto.Apellido;
                p.Correo = dto.Correo;
                p.Especialidad = dto.Especialidad;
                p.Activo = dto.Activo;

                // Usamos Update síncrono como dicta tu interfaz
                await Task.Run(() => _repository.Update(p));
            }
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p != null)
            {
                // Usamos Remove síncrono como dicta tu interfaz
                await Task.Run(() => _repository.Remove(p));
            }
        }
    }
}