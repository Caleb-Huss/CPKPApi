using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using CPKPModels;

namespace CPKPDL;

public partial class CpkpDbContext : DbContext
{
    public CpkpDbContext()
    {
    }


    public CpkpDbContext(DbContextOptions<CpkpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Stat> Stats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
 
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Playerid).HasName("PK_Players_Playerid");

            entity.ToTable("players", tb => tb.HasTrigger("CreateStats"));

            entity.Property(e => e.Playerid).HasColumnName("playerid");
            entity.Property(e => e.Createdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Lastlogin)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("lastlogin");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Stat>(entity =>
        {
            entity.HasKey(e => e.Playerid).HasName("PK_Stats_Playerid");

            entity.ToTable("stats", tb => tb.HasTrigger("updateLoginDate"));

            entity.Property(e => e.Playerid)
                .ValueGeneratedNever()
                .HasColumnName("playerid");
            entity.Property(e => e.Correctguesses)
                .HasDefaultValueSql("((0))")
                .HasColumnName("correctguesses");
            entity.Property(e => e.Higheststreak)
                .HasDefaultValueSql("((0))")
                .HasColumnName("higheststreak");
            entity.Property(e => e.Shiniesseen)
                .HasDefaultValueSql("((0))")
                .HasColumnName("shiniesseen");
            entity.Property(e => e.Totalguesses)
                .HasDefaultValueSql("((0))")
                .HasColumnName("totalguesses");

            entity.HasOne(d => d.Player).WithOne(p => p.Stat)
                .HasForeignKey<Stat>(d => d.Playerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stats_Playerid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
