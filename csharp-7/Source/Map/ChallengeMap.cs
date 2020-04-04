using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestauranteCodenation.Data.Map
{
    public class ChallengeMap : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder.ToTable("challenge");

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

            builder.HasMany<Acceleration>(c => c.Accelerations)
                   .WithOne(c => c.Challenge)
                   .HasForeignKey(a => a.ChallengeId);

            builder.HasMany<Submission>(c => c.Submissions)
                   .WithOne(c => c.Challenges)
                   .HasForeignKey(a => a.ChallengeId);
        }
    }
}
