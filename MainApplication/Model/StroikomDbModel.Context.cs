﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainApplication.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Db_StroikomEntities : DbContext
    {
        public Db_StroikomEntities()        
        {
            Database.Connection.ConnectionString = Parameters.Instance.ConnectionDb;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DbCash> Cash { get; set; }
        public virtual DbSet<DbGoods> Goods { get; set; }
        public virtual DbSet<DbModules> Modules { get; set; }
        public virtual DbSet<DbOperations> Operations { get; set; }
        public virtual DbSet<DbOrdersOrSales> OrdersOrSales { get; set; }
        public virtual DbSet<DbOrderStorageSaleGoods> OrderStorageSaleGoods { get; set; }
        public virtual DbSet<DbPartners> Partners { get; set; }
        public virtual DbSet<DbPersonnels> Personnels { get; set; }
        public virtual DbSet<DbPosts> Post { get; set; }
        public virtual DbSet<DbRelationships> Relationships { get; set; }
        public virtual DbSet<DbStatus> Status { get; set; }
        public virtual DbSet<DbStorages> Storages { get; set; }
        public virtual DbSet<DbTask> Tasks { get; set; }
    }
}
