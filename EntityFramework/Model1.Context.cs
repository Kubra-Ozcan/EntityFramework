﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbSirketEntities : DbContext
    {
        public dbSirketEntities()
            : base("name=dbSirketEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblMusteriler> tblMusteriler { get; set; }
        public virtual DbSet<tblUrunler> tblUrunler { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblSatisler> tblSatisler { get; set; }
    
        public virtual ObjectResult<SatisListesi_Result> SatisListesi()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SatisListesi_Result>("SatisListesi");
        }
    
        public virtual ObjectResult<SatisListesi2_Result> SatisListesi2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SatisListesi2_Result>("SatisListesi2");
        }
    }
}
