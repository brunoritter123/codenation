using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestauranteCodenation.Data.Map
{
    public class CandidateMap : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("candidate");

            builder.HasKey(x => new { x.UserId, x.AccelerationId, x.CompanyId });

            builder.Property(x => x.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.Property(x => x.AccelerationId)
                   .HasColumnName("acceleration_id")
                   .IsRequired();

            builder.Property(x => x.CompanyId)
                   .HasColumnName("company_id")
                   .IsRequired();

            builder.Property(x => x.Status)
                   .HasColumnName("status")
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("created_at")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.HasOne(u => u.User)
                   .WithMany(c => c.Candidates)
                   .HasForeignKey(u => u.UserId);

            builder.HasOne(u => u.Acceleration)
                   .WithMany(c => c.Candidates)
                   .HasForeignKey(a => a.AccelerationId);

            builder.HasOne(u => u.Company)
                   .WithMany(c => c.Candidates)
                   .HasForeignKey(c => c.CompanyId);
        }
    }
}
