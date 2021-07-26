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
            AdicionarUsuarios(modelBuilder);

            AdicionarEstados(modelBuilder);

            AdicionarCidades(modelBuilder);

            AdicionarEnderecos(modelBuilder);

            AdicionarArmazenamentos(modelBuilder);

            AdicionarMercadorias(modelBuilder);

            AdicionarAtendimentos(modelBuilder);

            AdicionarHistoricoMercadorias(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void AdicionarUsuarios(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasData(new { Id = 1L, Nome = "Usuario Administrador", Login = "usuario1", Senha = "PUCMINAS", DataCriacao = DateTime.Now, Habilitado = true, Tipo = TipoUsuario.Administrador });

            modelBuilder.Entity<Usuario>()
                .HasData(new { Id = 2L, Nome = "Usuario Cliente", Login = "usuario2", Senha = "PUCMINAS", DataCriacao = DateTime.Now, Habilitado = true, Tipo = TipoUsuario.Cliente });

            modelBuilder.Entity<Usuario>()
                .HasData(new { Id = 3L, Nome = "Usuario Colaborador", Login = "usuario3", Senha = "PUCMINAS", DataCriacao = DateTime.Now, Habilitado = true, Tipo = TipoUsuario.Colaborador });
        }

        private static void AdicionarEstados(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 1L, Nome = "Amazonas", Sigla = "AM" });

            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 2L, Nome = "Bahia", Sigla = "BA" });

            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 3L, Nome = "Espírito Santo", Sigla = "ES" });

            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 4L, Nome = "Goiás", Sigla = "GO" });

            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 5L, Nome = "Mato Grosso", Sigla = "MT" });

            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 6L, Nome = "Minas Gerais", Sigla = "MG" });

            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 7L, Nome = "Rio de Janeiro", Sigla = "RJ" });

            modelBuilder.Entity<Estado>()
                .HasData(new { Id = 8L, Nome = "São Paulo", Sigla = "SP" });
        }

        private static void AdicionarCidades(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 1L, Nome = "Manaus", EstadoId = 1L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 2L, Nome = "Salvador", EstadoId = 2L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 3L, Nome = "Serra", EstadoId = 3L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 4L, Nome = "Vitória", EstadoId = 3L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 5L, Nome = "Goiânia", EstadoId = 4L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 6L, Nome = "Cuiabá", EstadoId = 5L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 7L, Nome = "Belo Horizonte", EstadoId = 6L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 8L, Nome = "Uberlândia", EstadoId = 6L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 9L, Nome = "Rio de Janeiro", EstadoId = 7L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 10L, Nome = "São Gonçalo", EstadoId = 7L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 11L, Nome = "São Paulo", EstadoId = 8L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 12L, Nome = "Guarulhos", EstadoId = 8L });

            modelBuilder.Entity<Cidade>()
                .HasData(new { Id = 13L, Nome = "Campinas", EstadoId = 8L });
        }

        private static void AdicionarEnderecos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 1L, Rua = "Avenida Coronel Sávio Belota", Numero = 10, Bairro = "Novo Aleixo", CEP = "69098-270", CidadeId = 1L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 2L, Rua = "Travessa Laudelino", Numero = 20, Bairro = "Cosme de Farias", CEP = "40251-860", CidadeId = 2L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 3L, Rua = "Rua Iconha", Numero = 30, Bairro = "Reis Magos", CEP = "29182-405", CidadeId = 3L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 4L, Rua = "Rua dos Navegantes", Numero = 40, Bairro = "São Pedro", CEP = "29030-270", CidadeId = 4L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 5L, Rua = "Rua dos Girassóis", Numero = 50, Bairro = "São Francisco", CEP = "78088-688", CidadeId = 5L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 6L, Rua = "Rua Senhora das Mercês", Numero = 60, Bairro = "Graça", CEP = "31140-080", CidadeId = 6L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 7L, Rua = "Rua Engenheiro Caetano Lopes", Numero = 70, Bairro = "Comiteco", CEP = "30315-350", CidadeId = 7L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 8L, Rua = "Praça Canto Maior dos Palmares", Numero = 80, Bairro = "Patrimônio", CEP = "38411-054", CidadeId = 8L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 9L, Rua = "Rua Honório Pimentel", Numero = 90, Bairro = "Vila da Penha", CEP = "21220-440", CidadeId = 9L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 10L, Rua = "Rua da Divisa", Numero = 100, Bairro = "Amendoeira", CEP = "24730-440", CidadeId = 10L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 11L, Rua = "Rua Benedito Jacinto Mendes", Numero = 110, Bairro = "Jardim Grimaldi", CEP = "03922-000", CidadeId = 11L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 12L, Rua = "Rua Floro de Oliveira", Numero = 120, Bairro = "Jardim Adriana", CEP = "07135-313", CidadeId = 12L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 13L, Rua = "Rua Fernando Costa", Numero = 130, Bairro = "Jardim Primavera", CEP = "13026-400", CidadeId = 13L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 14L, Rua = "Rua Exemplo1", Numero = 15, Bairro = "Bairro 1", CEP = "04567-000", CidadeId = 11L });

            modelBuilder.Entity<Endereco>()
                .HasData(new { Id = 15L, Rua = "Rua Exemplo2", Numero = 30, Bairro = "Bairro 2", CEP = "07890-000", CidadeId = 11L });
        }

        private static void AdicionarArmazenamentos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armazenamento>()
                .HasData(new { Id = 1L, Nome = "Centro de distribuição de SP - Boa Entrega", CapacidadeM2 = 60000f, EnderecoId = 11L });

            modelBuilder.Entity<Armazenamento>()
                .HasData(new { Id = 2L, Nome = "Estoque de Vitória - Boa Entrega", CapacidadeM2 = 20000f, EnderecoId = 4L });
        }

        private static void AdicionarMercadorias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mercadoria>()
                .HasData(new { Id = "ME000001", Descricao = "Camiseta Esportiva", Valor = 149.99f, Frete = 13.99f, RemetenteId = 14L, DestinatarioId = 15L, Entregue = false, DataEntrada = new DateTime(2021, 07, 25, 14, 30, 0), ClienteId = 2L });
        }

        private static void AdicionarAtendimentos(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendimento>()
                .HasData(new { Id = 1L, Titulo = "Demora Entrega", Mensagem = "Boa tarde! Preciso de ajuda. Minha mercadoria está parada há muito tempo.", Chamado = "AT000001", MercadoriaId = "ME000001" });

            modelBuilder.Entity<Atendimento>()
                .HasData(new { Id = 2L, Titulo = "Demora Entrega", Mensagem = "Obrigado pelo contato! Verifiquei que ela chegará nos próximos dias.", Chamado = "AT000001", MercadoriaId = "ME000001" });
        }

        private static void AdicionarHistoricoMercadorias(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoMercadoria>()
                .HasData(new { Id = 1L, Descricao = "Chegou no estoque de Vitória", ArmazenamentoId = 2L, DataHora = new DateTime(2021, 07, 28, 08, 45, 0), MercadoriaId = "ME000001" });

            modelBuilder.Entity<HistoricoMercadoria>()
                .HasData(new { Id = 2L, Descricao = "Chegou no centro de distribuição de São Paulo", ArmazenamentoId = 1L, DataHora = new DateTime(2021, 08, 03, 16, 0, 0), MercadoriaId = "ME000001" });
        }
    }
}