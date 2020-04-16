using Microsoft.EntityFrameworkCore;
using Entidades;

namespace Dados
{
    public class DadosContext : DbContext
    {
        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitacao_Pagamento_Detalhe>()
                .HasOne(a => a.Solicitacao_Pagamento)
                .WithMany(f => f.Solicitacao_Pagamento_Detalhe)
                .HasForeignKey(a => a.id_solicitacao_pagamento);

            modelBuilder.Entity<Solicitacao_Pagamento>()
                .HasOne(a => a.ALD_ETL_Fornecedores)
                .WithMany(f => f.Solicitacao_Pagamento)
                .HasForeignKey(a => a.numero_fornecedor);

            modelBuilder.Entity<Solicitacao_Pagamento>()
                .HasOne(a => a.Fila_Solicitacao_Pagamento)
                .WithMany(f => f.Solicitacao_Pagamento)
                .HasForeignKey(a => a.id_fila_solicitacao_pagamento);

            modelBuilder.Entity<Solicitacao_Pagamento>()
                .HasOne(a => a.Tipo_Solicitacao_Pagamento)
                .WithMany(f => f.Solicitacao_Pagamento)
                .HasForeignKey(a => a.id_tipo_solicitacao_pagamento);

            modelBuilder.Entity<Solicitacao_Pagamento>()
                .HasOne(a => a.Forma_Pagamento)
                .WithMany(f => f.Solicitacao_Pagamento)
                .HasForeignKey(a => a.id_forma_pagamento);

            modelBuilder.Entity<Solicitacao_Pagamento>()
                .HasOne(a => a.Diretoria)
                .WithMany(f => f.Solicitacao_Pagamento)
                .HasForeignKey(a => a.id_diretoria);

            modelBuilder.Entity<Solicitacao_Pagamento_Detalhe>()
                .HasOne(a => a.Categoria_NF)
                .WithMany(f => f.Solicitacao_Pagamento_Detalhe)
                .HasForeignKey(a => a.categoria_nf);

            modelBuilder.Entity<Documento_Fiscal>()
                .HasOne(a => a.Solicitacao_Pagamento)
                .WithMany(f => f.Documento_Fiscal)
                .HasForeignKey(a => a.id_solicitacao_pagamento);

            modelBuilder.Entity<Documento_Fiscal>()
                .HasOne(a => a.Tipo_Arquivo)
                .WithMany(f => f.Documento_Fiscal)
                .HasForeignKey(a => a.id_tipo_arquivo);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Solicitacao_Pagamento> Solicitacao_Pagamento { get; set; }
        public virtual DbSet<Solicitacao_Pagamento_Detalhe> Solicitacao_Pagamento_Detalhe { get; set; }
        public virtual DbSet<Documento_Fiscal> Documento_Fiscal { get; set; }
        public virtual DbSet<Fila_Solicitacao_Pagamento> Fila_Solicitacao_Pagamento { get; set; }
        public virtual DbSet<Tipo_Solicitacao_Pagamento> Tipo_Solicitacao_Pagamento { get; set; }
        public virtual DbSet<Forma_Pagamento> Forma_Pagamento { get; set; }
        public virtual DbSet<Diretoria> Diretoria { get; set; }
        public virtual DbSet<Categoria_NF> Categoria_NF { get; set; }
        public virtual DbSet<ALD_ETL_Crep_Code> ALD_ETL_Crep_Code { get; set; }
        public virtual DbSet<ALD_ETL_Database> ALD_ETL_Database { get; set; }

        public virtual DbSet<ALD_ETL_Agreement> ALD_ETL_Agreement { get; set; }
        public virtual DbSet<ALD_ETL_Agreement_Item> ALD_ETL_Agreement_Item { get; set; }
        public virtual DbSet<ALD_ETL_Invoice> ALD_ETL_Invoice { get; set; }
        public virtual DbSet<Controle_NF> Controle_NF { get; set; }
        public virtual DbSet<ALD_ETL_Fornecedores> ALD_ETL_Fornecedores { get; set; }
        public virtual DbSet<Blacklist_Fornecedor> Blacklist_Fornecedor { get; set; }
        public virtual DbSet<Log_Import_GED> Log_Import_GED { get; set; }
        public virtual DbSet<Deletar_NF_GED> Deletar_NF_GED { get; set; }
        public virtual DbSet<Status_Importacao> Status_Importacao { get; set; }
    }
}
