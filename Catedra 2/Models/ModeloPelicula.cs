using System.ComponentModel.DataAnnotations;

namespace Catedra_2.Models
{
    public class ModeloPelicula
    {
        public int? ID_Pelicula { get; set; }
        [Required]
        public string? Poster { get; set; }
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Sinopsis { get; set; }
        [Required]
        public string? Director { get; set; }
        [Required]
        public string? Genero { get; set; }
        [Required]
        public string? Fecha_Estreno { get; set; }
    }
}
