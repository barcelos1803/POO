using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.Property(i => i.Id).HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Titulo)
                .HasColumnName("titulo")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(i => i.Descricao)
                .HasColumnName("descricao")
                .IsRequired()
                .HasColumnType("varchar(1000)");         
        }        
    }
}