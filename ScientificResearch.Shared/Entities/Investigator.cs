﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    public class Investigator//Clase de los investigadores
    {
        //Primary key
        public int Id { get; set; }

        //Campos de la clase

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Especialidad")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Specialty { get; set; }



        [Display(Name = "Afiliación")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Membership { get; set; }

        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "Digite un Email válido")]
        public string Email { get; set; }

        // Se le Coloca el ICollection 
        [JsonIgnore]
        public ICollection<ResearcherParticipation> ResearcherParticipations { get; set; }

    }
} 
