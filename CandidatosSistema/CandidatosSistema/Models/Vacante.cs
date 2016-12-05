
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

    public partial class Vacante
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Vacante()
    {

        this.AsignacionVacante = new HashSet<AsignacionVacante>();

    }


    public int VacanteId { get; set; }
        [Required(ErrorMessage = "El Titulo es requerido")]
        [Display(Name = "Titulo de la vacante:", Description = "xxxxx")]
        public string VacanteTitulo { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha:", Description = "xxxxx")]

        public Nullable<System.DateTime> VacanteFecha { get; set; }

        [Required(ErrorMessage = "Elija un Area Vacante")]
        [Display(Name = "Area Vacante:", Description = "xxxxx")]

        public Nullable<int> VacanteAreaId { get; set; }

        [Required(ErrorMessage = "Elija un Localida")]
        [Display(Name = "Localidad vacante:", Description = "xxxxx")]

        public Nullable<int> VacanteLocalidadId { get; set; }

        [Required(ErrorMessage = "Elija una Localida")]
        [Display(Name = "Localidad Vacante:", Description = "xxxxx")]

        public string Delegacion_Municipio { get; set; }

        [Required(ErrorMessage = "Elija un Sueldo ")]
        [Display(Name = "Sueldo Vacante:", Description = "xxxxx")]


        public Nullable<int> VacanteSueldoId { get; set; }

        [Required(ErrorMessage = "Es nesesario este Dato")]
        [Display(Name = "Descripcion Vacante:", Description = "xxxxx")]


        public string DescripcionVacante { get; set; }

    public Nullable<int> VacanteEstatusId { get; set; }

        [Required(ErrorMessage = "Es nesesario este Dato")]
        [Display(Name = "Comentario Vacante:", Description = "xxxxx")]



        public string CometarioVacante { get; set; }


        [Required(ErrorMessage = "Es nesesario este Dato")]
        [Display(Name = "Empresa:", Description = "xxxxx")]


        public Nullable<int> EmpresaId { get; set; }

        [Required(ErrorMessage = "Es nesesario este Dato")]
        [Display(Name = "Representante Empresa:", Description = "xxxxx")]


        public string RepresentanteEmpresa { get; set; }



    public virtual VacanteArea VacanteArea { get; set; }

    public virtual VacanteEstatus VacanteEstatus { get; set; }

    public virtual VacanteLocalidad VacanteLocalidad { get; set; }

    public virtual VacanteSueldo VacanteSueldo { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<AsignacionVacante> AsignacionVacante { get; set; }

    public virtual Empresa Empresa { get; set; }

}

}
