﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class SisCandidatosEntities : DbContext
{
    public SisCandidatosEntities()
        : base("name=SisCandidatosEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Candidato> Candidato { get; set; }

    public virtual DbSet<Escolaridad> Escolaridad { get; set; }

    public virtual DbSet<Localidad> Localidad { get; set; }

    public virtual DbSet<Sueldo> Sueldo { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Especialidad> Especialidad { get; set; }

    public virtual DbSet<Estatus> Estatus { get; set; }

    public virtual DbSet<Empresa> Empresa { get; set; }

}

}

