using HouseholdTasks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseholdTasks.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(t => t.Descricao)
                .IsRequired(false)
                .HasMaxLength(500);

            builder
                .Property(t => t.DataCriacao)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(t => t.DataConclusao)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(t => t.Status)
                .IsRequired();

            builder
                .Property(t => t.Observacoes)
                .IsRequired(false)
                .HasMaxLength(500);

            builder
                .Property(t => t.Importancia)
                .IsRequired();
        }
    }
}
