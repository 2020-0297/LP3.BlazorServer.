using System.ComponentModel.DataAnnotations;

namespace LP3.BlazorServer.Shared.DTOs
{
    public class CursoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código del curso es obligatorio.")]
        [StringLength(10, ErrorMessage = "El código no puede tener más de 10 caracteres.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del curso es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los créditos son obligatorios.")]
        [Range(1, 6, ErrorMessage = "Los créditos deben estar entre 1 y 6.")]
        public int Creditos { get; set; }

        public bool Activo { get; set; } = true;
    }
}
