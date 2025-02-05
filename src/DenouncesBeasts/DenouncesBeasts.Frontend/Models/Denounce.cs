using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DenouncesBeasts.Frontend.Models
{
    public class Denounce
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3,ErrorMessage = "Debe poner un titulo de al menos 3 caracteres") ]
        [StringLength(50, ErrorMessage ="Debe acortar el texto" )]
        [DisplayName("Titulo")] 
        public string Tittle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(50)]
        public string PictureUrl { get; set; }
        [StringLength(25)]
        public string Status { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; } 
    }
}
