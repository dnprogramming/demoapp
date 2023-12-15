using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.DataContext;

public partial class SystemContext : DbContext
{
    public SystemContext()
    {
    }

    public SystemContext(DbContextOptions<SystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__countrie__3213E83F48F79548");

            entity.ToTable("countries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryExternalId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("country_external_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(200)
                .HasColumnName("country_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
