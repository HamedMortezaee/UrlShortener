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
    internal class UrlShortenerMapping : IEntityTypeConfiguration<UrlShortenerEnity>
    {
        public void Configure(EntityTypeBuilder<UrlShortenerEnity> builder)
        {
            builder.ToTable("UrlShortener");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.UrlShortenerGUID).HasMaxLength(128).IsRequired();
            builder.Property(a => a.MainUrl).IsRequired();
            builder.Property(a => a.ShortestUrl).IsRequired();
            builder.Property(a => a.RegisterDate).IsRequired();
            builder.Property(a => a.RegisterUserId).HasMaxLength(128).IsRequired();
            builder.Property(a => a.UpdateDate);
            builder.Property(a => a.UpdateUserId).HasMaxLength(128);
            builder.Property(a => a.DeleteUserId).HasMaxLength(128);
            builder.Property(a => a.IsDelete).IsRequired();
        }
    }
}
