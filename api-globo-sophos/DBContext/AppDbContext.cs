using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api_globo_sophos.Models;

namespace api_globo_sophos.DBContext;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fight> Fights { get; set; }

    public virtual DbSet<Hero> Heroes { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<Villain> Villains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ASUS_RAY\\SQLEXPRESS;Initial Catalog=Data-PF;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fight>(entity =>
        {
            entity.HasOne(d => d.Hero).WithMany(p => p.Fights)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HEROES_TO_FIGHTS");

            entity.HasOne(d => d.Villain).WithMany(p => p.Fights)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VILLAINS_TO_FIGHTS");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasOne(d => d.Hero).WithMany(p => p.Schedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HEROES_TO_SCHEDULE");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasOne(d => d.Hero).WithMany(p => p.Sponsors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HEROES_TO_SPONSORS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
