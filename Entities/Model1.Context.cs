﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViruseSpreadApp.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VirusSpreadEntities : DbContext
    {
        public VirusSpreadEntities()
            : base("name=VirusSpreadEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BudgetAllocation> BudgetAllocations { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<PossibleStrategy> PossibleStrategies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
