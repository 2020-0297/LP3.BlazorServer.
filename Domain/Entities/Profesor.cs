using System.ComponentModel.DataAnnotations;

namespace LP3.BlazorServer.Domain.Entities
{
    public class Profesor
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        public string Apellido { get; set; } = string.Empty;
        
        [Required]
        public string Correo { get; set; } = string.Empty;
        
        [Required]
        public string Especialidad { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
