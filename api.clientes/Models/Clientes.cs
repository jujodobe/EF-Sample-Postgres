

using System.ComponentModel.DataAnnotations;

namespace api.clientes.Models
{
    public class Clientes 
    {
        public int Id { get; set; }
        [Required]
        [Range(3, 10)]
        public string? Nombre { get; set; }
        [Required]
        [Range(3, 10)]
        public string? Apellido { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string? NroDocumeno { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int? Edad { get; set; }

    }
}
