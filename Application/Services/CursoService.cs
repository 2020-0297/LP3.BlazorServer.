using Microsoft.EntityFrameworkCore;
using LP3.BlazorServer.Data;
using LP3.BlazorServer.Domain.Entities;
using LP3.BlazorServer.Shared.DTOs;

namespace LP3.BlazorServer.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ApplicationDbContext _context;

        public CursoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CursoDto>> GetAllAsync()
        {
            try
            {
                return await _context.Cursos
                    .Select(c => new CursoDto
                    {
                        Id = c.Id,
                        Codigo = c.Codigo,
                        Nombre = c.Nombre,
                        Creditos = c.Creditos,
                        Activo = c.Activo
                    }).ToListAsync();
            }
            catch (Exception)
            {
                // El profesor exige try-catch para evitar caídas del sistema
                return new List<CursoDto>();
            }
        }

        public async Task<CursoDto?> GetByIdAsync(int id)
        {
            try
            {
                var c = await _context.Cursos.FindAsync(id);
                if (c == null) return null;

                return new CursoDto
                {
                    Id = c.Id,
                    Codigo = c.Codigo,
                    Nombre = c.Nombre,
                    Creditos = c.Creditos,
                    Activo = c.Activo
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CursoDto?> GetByCodigoAsync(string codigo)
        {
            try
            {
                var c = await _context.Cursos
                    .FirstOrDefaultAsync(x => x.Codigo.ToLower() == codigo.ToLower());
                
                if (c == null) return null;

                return new CursoDto
                {
                    Id = c.Id,
                    Codigo = c.Codigo,
                    Nombre = c.Nombre,
                    Creditos = c.Creditos,
                    Activo = c.Activo
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CreateAsync(CursoDto dto)
        {
            try
            {
                var nuevoCurso = new Curso
                {
                    Codigo = dto.Codigo,
                    Nombre = dto.Nombre,
                    Creditos = dto.Creditos,
                    Activo = dto.Activo
                };

                _context.Cursos.Add(nuevoCurso);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(int id, CursoDto dto)
        {
            try
            {
                var cursoExistente = await _context.Cursos.FindAsync(id);
                if (cursoExistente == null) return false;

                cursoExistente.Codigo = dto.Codigo;
                cursoExistente.Nombre = dto.Nombre;
                cursoExistente.Creditos = dto.Creditos;
                cursoExistente.Activo = dto.Activo;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var curso = await _context.Cursos.FindAsync(id);
                if (curso == null) return false;

                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
