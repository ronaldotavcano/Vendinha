using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Vendinha.Models;

namespace Vendinha.Contexts
{   
    public class VendinhaDbContext : DbContext
    {
        private string connectionString;

        public VendinhaDbContext(string connectionString = null)
        {
            this.connectionString = connectionString;
        }
        
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Divida> Dividas => Set<Divida>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityCliente = modelBuilder.Entity<Cliente>();
            entityCliente.ToTable("clientes");
            entityCliente.Property(c => c.Cpf).HasColumnName("cpf");
            entityCliente.Property(c => c.Nome).HasColumnName("nome");
            entityCliente.Property(c => c.Email).HasColumnName("email");
            entityCliente.Property(c => c.DataNascimento).HasColumnName("data_nascimento");
            entityCliente.HasKey(c => c.Cpf);

            var entityDivida = modelBuilder.Entity<Divida>();
            entityDivida.ToTable("dividas");
            entityDivida.Property(d => d.Id).HasColumnName("id");
            entityDivida.Property(d => d.ClienteCpf).HasColumnName("cliente_cpf");
            entityDivida.Property(d => d.Valor).HasColumnName("valor");
            entityDivida.Property(d => d.DividaPaga).HasColumnName("divida_paga"); 
            entityDivida.Property(d => d.DataCriacao).HasColumnName("data_criacao");
            entityDivida.Property(d => d.DataPagamento).HasColumnName("data_pagamento");
            entityDivida.HasKey(d => d.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}