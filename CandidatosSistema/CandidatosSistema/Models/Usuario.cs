//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CandidatosSistema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Usuario es Requerido")]
        [Display(Name = "Nombre Completo", Description = "xxxxx")]
        public string Usuario1 { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Required(ErrorMessage = "La contraseņa es requerida")]
        [Display(Name = "Contraseņa", Description = "xxxxx")]
        public string Clave { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public Nullable<bool> Estado { get; set; }
    }
}
