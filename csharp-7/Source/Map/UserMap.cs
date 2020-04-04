using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestauranteCodenation.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.FullName)
                   .HasColumnName("full_name")
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(x => x.Nickname)
                   .HasColumnName("nickname")
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(x => x.Password)
                   .HasColumnName("password")
                   .HasColumnType("varchar(255)")
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("created_at")
                   .HasColumnType("timestamp")
                   .IsRequired();

            builder.HasMany<Candidate>(u => u.Candidates)
                   .WithOne(c => c.User)
                   .HasForeignKey(u => u.UserId);

            builder.HasMany<Submission>(u => u.Submissions)
                   .WithOne(s => s.User)
                   .HasForeignKey(s => s.UserId);
        }
    }
}
