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

    public partial class Candidato
    {
        public int CandidatoId { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [Display(Name = "Nombre de Candidato", Description = "xxxxx")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Telefono es Requerido")]
        [Display(Name = "Telefono de Candidato", Description = "xxxxx")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Correo es Requerido")]
        [Display(Name = "email de Candidato", Description = "xxxxx")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Es campo es requerido")]
        [Display(Name = "Estado", Description = "Estado")]
        public Nullable<int> LocalidadId { get; set; }
        public Nullable<int> SueldoId { get; set; }
        public Nullable<int> EscolaridadId { get; set; }
        public Nullable<int> EspecialidadId { get; set; }
        public Nullable<bool> EstadoCandidato { get; set; }
        public string Capturista { get; set; }
        public Nullable<System.DateTime> FechaCaptura { get; set; }
        public string Archivo { get; set; }
        [Required(ErrorMessage = "Es requerido este dato")]
        [Display(Name = "Delegacion/Municipio", Description = "xxxxx")]
        public string Municipio_colonia { get; set; }
        public Nullable<int> EstatusId { get; set; }
        public string ComentarioEstatus { get; set; }
        public string Area { get; set; }
    
        public virtual Escolaridad Escolaridad { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Sueldo Sueldo { get; set; }
        public virtual Especialidad Especialidad { get; set; }
        public virtual Estatus Estatus { get; set; }
    }
}
