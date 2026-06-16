using System.ComponentModel.DataAnnotations;

namespace LP3.BlazorServer.Shared.DTOs
{
    public class ProfesorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido del profesor es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad o área es obligatoria.")]
        public string Especialidad { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}
