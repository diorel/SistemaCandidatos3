
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
    
public partial class EmpresaUsuarioRequisicion
{

    public int IdEmpresaUsuarioRequisicion { get; set; }

    public Nullable<int> EmpresaId { get; set; }

    public Nullable<int> UsuarioRequisicionId { get; set; }

    public string Descripcion { get; set; }



    public virtual Empresa Empresa { get; set; }

    public virtual UsuarioRequisicion UsuarioRequisicion { get; set; }

}

}
