using System;
using System.ComponentModel;
using System.Drawing;
using CarteiraPet.Domain.Enums;

namespace CarteiraPet.WebApp.Models
{
    public class PetViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        [DisplayName("Foto de Perfil")]
        public string Photo { get; set; }
    }
}
