﻿using FlowerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerShopDatabaseImplement
{
    public class FlowerShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UI0H4F9\SQLEXPRESS;Initial Catalog=FlowerShopDatabaseComplexTwo;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Flower> Flowers { set; get; }
        public virtual DbSet<FlowerComponent> FlowerComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Storehouse> Storehouses { set; get; }
        public virtual DbSet<StorehouseComponent> StorehouseComponents { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}