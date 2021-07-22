using Microsoft.EntityFrameworkCore;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System;

namespace Vocalcom.Service.Database.Repository
{
    public class LogisticaDbContext : DbContext
    {
        public LogisticaDbContext(DbContextOptions<LogisticaDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Armazenamento> Armazenamento { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<HistoricoLogin> HistoricoLogin { get; set; }
        public DbSet<HistoricoMercadoria> HistoricoMercadoria { get; set; }
        public DbSet<Mercadoria> Mercadoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AdicionarDefinicoesDeEstrutura(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void AdicionarDefinicoesDeEstrutura(in ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoLogin>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Mercadoria>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Mercadoria>()
                .HasOne(p => p.Remetente)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Mercadoria>()
                .HasOne(p => p.Destinatario)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Atendimento>()
                .HasOne(p => p.Mercadoria)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<HistoricoMercadoria>()
                .HasOne(p => p.Mercadoria)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Endereco>()
                .HasOne(p => p.Cidade)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<Cidade>()
                .HasOne(p => p.Estado)
                .WithMany()
                .IsRequired();
        }
    }
}