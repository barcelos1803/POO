using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(i => i.Id).HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 0 : N => Usuário : Livros
            builder.HasMany(i => i.BorrowedBooks)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .IsRequired(false);                  
        }
    }
}