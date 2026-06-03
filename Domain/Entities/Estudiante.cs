using System.ComponentModel.DataAnnotations;

namespace LP3.BlazorServer.Domain.Entities;

public class Estudiante
{
    [Key]
    [Required(ErrorMessage = "La matrícula es obligatoria.")]
    [StringLength(20, ErrorMessage = "La matrícula no puede tener más de 20 caracteres.")]
    public string Matricula { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    public string Email { get; set; } = string.Empty;
}
