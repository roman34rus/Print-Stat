﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    internal partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Printer> PrinterSet { get; set; }
        public virtual DbSet<SupplyModel> SupplyModelSet { get; set; }
        public virtual DbSet<PrinterModel> PrinterModelSet { get; set; }
        public virtual DbSet<History> HistorySet { get; set; }
        public virtual DbSet<SupplySlot> SupplySlotSet { get; set; }
        public virtual DbSet<Supply> SupplySet { get; set; }
    }
}