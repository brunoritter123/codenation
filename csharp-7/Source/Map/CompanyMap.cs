using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestauranteCodenation.Data.Map
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("name")
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(x => x.Slug)
                   .HasColumnName("slug")
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("created_at")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.HasMany<Candidate>(c => c.Candidates)
                   .WithOne(c => c.Company)
                   .HasForeignKey(c => c.CompanyId);
        }
    }
}
