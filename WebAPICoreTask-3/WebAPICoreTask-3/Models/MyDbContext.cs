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

    public virtual DbSet<PlayList> PlayLists { get; set; }

    public virtual DbSet<PlayListTrack> PlayListTracks { get; set; }

    public virtual DbSet<Rapper> Rappers { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3O6RHJJ;Database=APITASK3;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayList>(entity =>
        {
            entity.HasKey(e => e.PlayListId).HasName("PK__PlayList__38709FBB2096550A");

            entity.ToTable("PlayList");

            entity.HasIndex(e => e.UserId, "UQ__PlayList__1788CCAD71EE2E57").IsUnique();

            entity.Property(e => e.PlayListId).HasColumnName("PlayListID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.PlayList)
                .HasForeignKey<PlayList>(d => d.UserId)
                .HasConstraintName("FK_UserCart");
        });

        modelBuilder.Entity<PlayListTrack>(entity =>
        {
            entity.HasKey(e => e.PlayListTracksId).HasName("PK__PlayList__068B987D37EF4056");

            entity.HasIndex(e => new { e.PlayListId, e.TrackId }, "UQ__PlayList__2FD7D0368AA58BA6").IsUnique();

            entity.Property(e => e.PlayListTracksId).HasColumnName("PlayListTracksID");
            entity.Property(e => e.PlayListId).HasColumnName("PlayListID");
            entity.Property(e => e.TrackId).HasColumnName("TrackID");

            entity.HasOne(d => d.PlayList).WithMany(p => p.PlayListTracks)
                .HasForeignKey(d => d.PlayListId)
                .HasConstraintName("FK_PlayList");

            entity.HasOne(d => d.Track).WithMany(p => p.PlayListTracks)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK_Track");
        });

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

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3DC38B3E");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RapperId).HasColumnName("RapperID");
            entity.Property(e => e.TrackId).HasColumnName("TrackID");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Rapper).WithMany(p => p.Users)
                .HasForeignKey(d => d.RapperId)
                .HasConstraintName("FK__Users__RapperID__3F466844");

            entity.HasOne(d => d.Track).WithMany(p => p.Users)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Users__TrackID__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
