﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalPropietaria.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RRHH_PropietariaEntities : DbContext
    {
        public RRHH_PropietariaEntities()
            : base("name=RRHH_PropietariaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Candidatos> Candidatos { get; set; }
        public virtual DbSet<Capacitaciones> Capacitaciones { get; set; }
        public virtual DbSet<Competencias> Competencias { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Experiencia> Experiencia { get; set; }
        public virtual DbSet<Idiomas> Idiomas { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
    }
}