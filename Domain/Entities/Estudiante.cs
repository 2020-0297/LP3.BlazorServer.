using System.ComponentModel.DataAnnotations;
using LP3.BlazorServer.Domain.Enums;

namespace LP3.BlazorServer.Domain.Entities;

public class Estudiante
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "La matrícula es obligatoria")]
    public string Matricula { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
    public string Email { get; set; } = string.Empty;

    public DateTime FechaIngreso { get; set; } = DateTime.UtcNow;
    public EstadoEstudiante Estado { get; set; } = EstadoEstudiante.Activo;
    public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
    public DateTime? ActualizadoEn { get; set; }
}