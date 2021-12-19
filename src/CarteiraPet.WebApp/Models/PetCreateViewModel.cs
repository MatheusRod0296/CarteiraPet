using System;
using System.ComponentModel;
using CarteiraPet.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace CarteiraPet.WebApp.Models
{
    public class PetCreateViewModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        
        public Sex Sex { get; set; }

        [DisplayName("Foto de Perfil")]
        public IFormFile Photo { get; set; }
    }
}