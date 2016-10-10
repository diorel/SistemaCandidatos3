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
        [Display(Name = "Nombre:", Description = "xxxxx")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Telefono es Requerido")]
        [Display(Name = "Telefono:", Description = "xxxxx")]
        public string Telefono { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no es valido")]
        [Required(ErrorMessage = "El Correo es Requerido")]
        [Display(Name = "Email:", Description = "xxxxx")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Elija una Entidad")]
        [Display(Name = "Estado", Description = "xxxxx")]
        public Nullable<int> LocalidadId { get; set; }
        [Required(ErrorMessage = "Elija un Salario")]
        public Nullable<int> SueldoId { get; set; }
        [Required(ErrorMessage = "Elija un garado de Estudios")]
        public Nullable<int> EscolaridadId { get; set; }
        [Required(ErrorMessage = "Elija una especialidad")]
        public Nullable<int> EspecialidadId { get; set; }
        public Nullable<bool> EstadoCandidato { get; set; }
        [Display(Name = "Capturista:", Description = "xxxxx")]
        public string Capturista { get; set; }
        [Display(Name = "Fecha de Captura:", Description = "xxxxx")]
        public Nullable<System.DateTime> FechaCaptura { get; set; }
        [Display(Name = "CV:", Description = "xxxxx")]
        [Required(ErrorMessage = "selecione un archivo")]
        public string Archivo { get; set; }
        [Required(ErrorMessage = "Es requerido este dato")]
        [Display(Name = "Delegacion/Municipio", Description = "xxxxx")]
        public string Municipio_colonia { get; set; }
        public Nullable<int> EstatusId { get; set; }
        [Display(Name = "Comentario Estatus:", Description = "xxxxx")]
        public string ComentarioEstatus { get; set; }
        [Display(Name = "Subespecialidad:", Description = "xxxxx")]
        public string Area { get; set; }
    
        public virtual Escolaridad Escolaridad { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Sueldo Sueldo { get; set; }
        public virtual Especialidad Especialidad { get; set; }
        public virtual Estatus Estatus { get; set; }
    }
}



////------------------------------------------------------------------------------
//// <auto-generated>
////     This code was generated from a template.
////
////     Manual changes to this file may cause unexpected behavior in your application.
////     Manual changes to this file will be overwritten if the code is regenerated.
//// </auto-generated>
////------------------------------------------------------------------------------

//namespace CandidatosSistema.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;

//    public partial class Candidato
//    {
//        public int CandidatoId { get; set; }
//        [Required(ErrorMessage = "El Nombre es requerido")]
//        [Display(Name = "Nombre:", Description = "xxxxx")]
//        public string Nombre { get; set; }
//        [Required(ErrorMessage = "El Telefono es Requerido")]
//        [Display(Name = "Tel�fono:", Description = "xxxxx")]
//        public string Telefono { get; set; }
//        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no es valido")]
//        [Required(ErrorMessage = "El Correo es Requerido")]
//        [Display(Name = "Email:", Description = "xxxxx")]
//        public string Correo { get; set; }

//        [Required(ErrorMessage = "Es campo es requerido")]
//        public List<string> SelectedItem { get; set; }
//        public Nullable<int> LocalidadId { get; set; }

//        public Nullable<int> SueldoId { get; set; }
//        public Nullable<int> EscolaridadId { get; set; }
//        public Nullable<int> EspecialidadId { get; set; }
//        public Nullable<bool> EstadoCandidato { get; set; }
//        [Display(Name = "Capturista:", Description = "xxxxx")]
//        public string Capturista { get; set; }
//        [Display(Name = "Fecha de Alta:", Description = "xxxxx")]
//        public Nullable<System.DateTime> FechaCaptura { get; set; }


//        [Display(Name = "CV:", Description = "xxxxx")]
//        public string Archivo { get; set; }
//        [Required(ErrorMessage = "Es requerido este dato")]
//        [Display(Name = "Delegacion/Municipio:", Description = "xxxxx")]
//        public string Municipio_colonia { get; set; }
//        public Nullable<int> EstatusId { get; set; }

//        public string ComentarioEstatus { get; set; }
//        [Display(Name = "Subespecialidad:", Description = "xxxxx")]
//        public string Area { get; set; }


//        public virtual Escolaridad Escolaridad { get; set; }

//        public virtual Localidad Localidad { get; set; }
//        public virtual Sueldo Sueldo { get; set; }
//        public virtual Especialidad Especialidad { get; set; }
//        public virtual Estatus Estatus { get; set; }
//    }
//}





