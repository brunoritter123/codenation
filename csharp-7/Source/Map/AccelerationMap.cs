using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestauranteCodenation.Data.Map
{
    public class AccelerationMap : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> builder)
        {
            builder.ToTable("acceleration");

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

            builder.Property(x => x.ChallengeId)
                   .HasColumnName("challenge_id")
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("created_at")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.HasMany<Candidate>(c => c.Candidates)
                   .WithOne(a => a.Acceleration)
                   .HasForeignKey(c => c.AccelerationId);
        }
    }
}
