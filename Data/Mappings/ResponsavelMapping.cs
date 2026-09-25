using HouseholdTasks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseholdTasks.Data.Mappings
{
    public class ResponsavelMapping : IEntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            builder.ToTable("Responsaveis");

            builder.HasKey(r => r.Id);

            builder
                .Property(r => r.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(r => r.Tarefas)
                .WithOne(t => t.Responsavel)
                .HasForeignKey(t => t.ResponsavelId);
        }
    }
}
