using Microsoft.EntityFrameworkCore;
using POC.LogisticaMicrosservico.Repository.Entidades;
using System;

namespace POC.LogisticaMicrosservico
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
            modelBuilder.Entity<Usuario>()
                .HasData(new { Id = 1L, Nome = "Usuario Exemplo", Login = "Admin", Senha = "PUCMINAS", DataCriacao = DateTime.Now, Habilitado = true, Tipo = TipoUsuario.Administrador });

            base.OnModelCreating(modelBuilder);
        }
    }
}