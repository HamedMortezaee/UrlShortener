using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Model;

namespace UrlShortener.DataAccess.EFCore.Mapping
{
    internal class UrlShortenerHistoryMapping : IEntityTypeConfiguration<UrlShortenerHistoryEnity>
    {
        public void Configure(EntityTypeBuilder<UrlShortenerHistoryEnity> builder)
        {
            builder.ToTable("UrlShortenerHistory");
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.UrlShortener)
                    .WithMany()
                    .HasForeignKey(a => a.UrlShortenerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            builder.Property(a => a.RegisterDate).IsRequired();
            builder.Property(a => a.RegisterUserId).HasMaxLength(128).IsRequired();
            builder.Property(a => a.UpdateDate);
            builder.Property(a => a.UpdateUserId).HasMaxLength(128);
            builder.Property(a => a.DeleteUserId).HasMaxLength(128);
            builder.Property(a => a.IsDelete).IsRequired();
        }
    }
}
