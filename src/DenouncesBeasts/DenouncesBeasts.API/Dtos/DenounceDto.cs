using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenouncesBeasts.Frontend.Models
{ 
    public class DenounceDto
    { 
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

        public int DenounzerId { get; set; }
        public SelectList? DenounzersSelectList { get; set; }
    }
}
