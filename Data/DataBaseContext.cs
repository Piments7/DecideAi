using Microsoft.EntityFrameworkCore;
using DecideAi.Models;
using Microsoft.AspNetCore.Http;

namespace DecideAi.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UsuarioModel> Usuario { get; set; }

        public virtual DbSet<StatusModel> Status { get; set; }

        public virtual DbSet<MotivoModel> Motivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("ID");

                entity.Property(e => e.Nome)
                      .HasColumnName("NOME")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.CPF)
                      .HasColumnName("CPF")
                      .HasMaxLength(11)
                      .IsRequired();

                entity.Property(e => e.Endereco)
                      .HasColumnName("ENDERECO")
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(e => e.NumeroEndereco)
                      .HasColumnName("NUMERO_ENDERECO")
                      .IsRequired();

                entity.Property(e => e.CEP)
                      .HasColumnName("CEP")
                      .HasMaxLength(8)
                      .IsRequired();

                entity.Property(e => e.Complemento)
                      .HasColumnName("COMPLEMENTO");

                entity.Property(e => e.Telefone)
                      .HasColumnName("TELEFONE")
                      .HasMaxLength(15)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasColumnName("EMAIL")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Senha)
                      .HasColumnName("SENHA")
                      .HasMaxLength(100)
                      .IsRequired();
            });

                modelBuilder.Entity<MotivoModel>(entity =>
                {
                    entity.ToTable("Motivo");
                    entity.HasKey(e => e.MotivoId);
                    entity.HasIndex(e => e.Buraco).IsUnique();
                    entity.HasIndex(e => e.ILuminacaoPublica).IsUnique();
                    entity.HasIndex(e => e.LixoNaoColetado).IsUnique();
                    entity.HasIndex(e => e.Outros).IsUnique();

                });

                modelBuilder.Entity<StatusModel>(entity =>
                {
                    entity.ToTable("Solicitacao");
                    entity.HasKey(e => e.StatusId);

                    entity.HasOne(e => e.Usuario)
                        .WithMany()
                        .HasForeignKey(e => e.UsuarioId)
                        .IsRequired();

                    entity.Property(e => e.EnderecoLocal).IsRequired();
                    entity.Property(e => e.Numero).IsRequired();
                    entity.Property(e => e.Cep).IsRequired();
                    entity.Property(e => e.Bairro).IsRequired();
                    entity.Property(e => e.Descricao).IsRequired();

                    entity.HasOne(e => e.Motivo)
                        .WithMany()
                        .HasForeignKey(e => e.MotivoId)
                        .IsRequired();
                
                });

                base.OnModelCreating(modelBuilder);
        }
    }
}


