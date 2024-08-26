using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPICoreTask_3.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Rapper> Rappers { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3O6RHJJ;Database=APITASK3;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rapper>(entity =>
        {
            entity.HasKey(e => e.RapperId).HasName("PK__Rapper__594117F33CF3C50A");

            entity.ToTable("Rapper");

            entity.Property(e => e.RapperId).HasColumnName("RapperID");
            entity.Property(e => e.RapperImage)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.RapperName)
                .HasMaxLength(225)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId).HasName("PK__Track__7A74F8C0A7A16D2E");

            entity.ToTable("Track");

            entity.Property(e => e.TrackId).HasColumnName("TrackID");
            entity.Property(e => e.Description)
                .HasMaxLength(225)
                .IsUnicode(false);
            entity.Property(e => e.Duration)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.RapperId).HasColumnName("RapperID");
            entity.Property(e => e.TrackImage).IsUnicode(false);
            entity.Property(e => e.TrackName)
                .HasMaxLength(225)
                .IsUnicode(false);

            entity.HasOne(d => d.Rapper).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.RapperId)
                .HasConstraintName("FK__Track__RapperID__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
