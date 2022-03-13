using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CarteiraPet.Domain.Enums;
using CarteiraPet.WebApp.Attributes;
using Microsoft.AspNetCore.Http;

namespace CarteiraPet.WebApp.Models
{
    public class PetCreateViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Data de Nascimento é obrigatória")]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Sexo do pet é obrigatório")]
        public Sex? Sex { get; set; }

        [DisplayName("Foto de Perfil (max 500kb)")]
        [Required(ErrorMessage = "Foto é obrigatória")]
        [MaxFileSizeAttribute(500000)]
        public IFormFile Photo { get; set; }
    }
}
