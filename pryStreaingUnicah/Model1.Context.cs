﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pryStreaingUnicah
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StreamingUnicahIdentidades : DbContext
    {
        public StreamingUnicahIdentidades()
            : base("name=StreamingUnicahIdentidades")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Clasificaciones> Clasificaciones { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<TiposPeliculas> TiposPeliculas { get; set; }
    }
}