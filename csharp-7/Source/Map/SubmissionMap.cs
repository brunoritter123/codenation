using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestauranteCodenation.Data.Map
{
    public class SubmissionMap : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.ToTable("submission");

            builder.HasKey(x => new { x.UserId, x.ChallengeId });

            builder.Property(x => x.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.Property(x => x.ChallengeId)
                   .HasColumnName("challenge_id")
                   .IsRequired();

            builder.Property(x => x.Score)
                   .HasColumnName("score")
                   .HasColumnType("float")
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("created_at")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.HasOne(s => s.Challenges)
                   .WithMany(c => c.Submissions)
                   .HasForeignKey(c => c.ChallengeId);
        }
    }
}
