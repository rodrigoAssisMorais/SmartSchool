using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;

namespace SmartSchool.API.Data
{
    public class SmartContext : DbContext
    {

        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Carga inicial nas tabelas
            builder.Entity<Cliente>()
                .HasData(new List<Cliente>(){
                    new Cliente(Guid.NewGuid(), "Lauro", 36),
                    new Cliente(Guid.NewGuid(), "Roberto", 25),
                    new Cliente(Guid.NewGuid(), "Ronaldo", 32),
                    new Cliente(Guid.NewGuid(), "Rodrigo", 42),
                    new Cliente(Guid.NewGuid(), "Alexandre", 46),
                });
   
        }

    }
}
