
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
    
public partial class AsignacionRequisicion
{

    public int AsignacionRequisicionId { get; set; }

    public Nullable<int> CandidatoId { get; set; }

    public Nullable<int> RequisicionId { get; set; }

    public Nullable<int> AsignacionEstatus { get; set; }

    public Nullable<System.DateTime> AsignacionFecha { get; set; }



    public virtual Candidato Candidato { get; set; }

    public virtual Requisicion Requisicion { get; set; }

}

}
