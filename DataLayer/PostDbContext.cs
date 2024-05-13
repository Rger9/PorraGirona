using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PorraGirona.DataLayer;

public partial class PostDbContext : DbContext
{
    public PostDbContext()
    {
    }

    public PostDbContext(DbContextOptions<PostDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<equips> equips { get; set; }

    public virtual DbSet<jugadors> jugadors { get; set; }

    public virtual DbSet<partits> partits { get; set; }

    public virtual DbSet<penyes> penyes { get; set; }

    public virtual DbSet<penyistes> penyistes { get; set; }

    public virtual DbSet<porres> porres { get; set; }

    public virtual DbSet<puntuacions> puntuacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=porragirona;uid=root;convert zero datetime=True", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<equips>(entity =>
        {
            entity.HasKey(e => e.idequip).HasName("PRIMARY");

            entity.UseCollation("utf8_unicode_ci");

            entity.Property(e => e.idequip).HasColumnType("int(11)");
            entity.Property(e => e.imatge).HasColumnType("mediumblob");
            entity.Property(e => e.nom).HasMaxLength(50);
        });

        modelBuilder.Entity<jugadors>(entity =>
        {
            entity.HasKey(e => e.idjugador).HasName("PRIMARY");

            entity.UseCollation("utf8_unicode_ci");

            entity.HasIndex(e => e.idequip, "idequip");

            entity.Property(e => e.idjugador).HasColumnType("int(11)");
            entity.Property(e => e.idequip).HasColumnType("int(11)");
            entity.Property(e => e.nom).HasMaxLength(50);
            entity.Property(e => e.temporada).HasMaxLength(50);

            entity.HasOne(d => d.idequipNavigation).WithMany(p => p.jugadors)
                .HasForeignKey(d => d.idequip)
                .HasConstraintName("jugadors_ibfk_2");
        });

        modelBuilder.Entity<partits>(entity =>
        {
            entity.HasKey(e => e.idpartit).HasName("PRIMARY");

            entity.UseCollation("utf8_unicode_ci");

            entity.HasIndex(e => e.idequiplocal, "idlocal");

            entity.HasIndex(e => e.idequipvisitant, "idvisitant");

            entity.Property(e => e.idpartit).HasColumnType("int(11)");
            entity.Property(e => e.datainici).HasColumnType("datetime");
            entity.Property(e => e.finalitzat).HasMaxLength(10);
            entity.Property(e => e.golslocal).HasColumnType("int(11)");
            entity.Property(e => e.golsvisitant).HasColumnType("int(11)");
            entity.Property(e => e.idequiplocal).HasColumnType("int(11)");
            entity.Property(e => e.idequipvisitant).HasColumnType("int(11)");
            entity.Property(e => e.idsjugadorslocal).HasMaxLength(100);
            entity.Property(e => e.idsjugadorsvisitant).HasMaxLength(100);
            entity.Property(e => e.jornada).HasColumnType("int(11)");
            entity.Property(e => e.temporada).HasMaxLength(50);

            entity.HasOne(d => d.idequiplocalNavigation).WithMany(p => p.partitsidequiplocalNavigation)
                .HasForeignKey(d => d.idequiplocal)
                .HasConstraintName("partits_ibfk_4");

            entity.HasOne(d => d.idequipvisitantNavigation).WithMany(p => p.partitsidequipvisitantNavigation)
                .HasForeignKey(d => d.idequipvisitant)
                .HasConstraintName("partits_ibfk_5");
        });

        modelBuilder.Entity<penyes>(entity =>
        {
            entity.HasKey(e => e.idpenya).HasName("PRIMARY");

            entity.UseCollation("utf8_unicode_ci");

            entity.Property(e => e.idpenya).HasColumnType("int(11)");
            entity.Property(e => e.nom).HasMaxLength(20);
        });

        modelBuilder.Entity<penyistes>(entity =>
        {
            entity.HasKey(e => e.idpenyista).HasName("PRIMARY");

            entity.UseCollation("utf8_unicode_ci");

            entity.HasIndex(e => e.idpenya, "idpenya");

            entity.Property(e => e.idpenyista).HasColumnType("int(11)");
            entity.Property(e => e.alias).HasMaxLength(50);
            entity.Property(e => e.cognoms).HasMaxLength(50);
            entity.Property(e => e.dataalta).HasColumnType("datetime");
            entity.Property(e => e.idpenya).HasColumnType("int(11)");
            entity.Property(e => e.imatge).HasColumnType("mediumblob");
            entity.Property(e => e.nif).HasMaxLength(15);
            entity.Property(e => e.nom).HasMaxLength(50);
            entity.Property(e => e.numsoci).HasMaxLength(50);
            entity.Property(e => e.password).HasMaxLength(50);
            entity.Property(e => e.rol).HasMaxLength(15);

            entity.HasOne(d => d.idpenyaNavigation).WithMany(p => p.penyistes)
                .HasForeignKey(d => d.idpenya)
                .HasConstraintName("penyistes_ibfk_2");
        });

        modelBuilder.Entity<porres>(entity =>
        {
            entity.HasKey(e => e.idporra).HasName("PRIMARY");

            entity.UseCollation("utf8_unicode_ci");

            entity.HasIndex(e => e.idpartit, "idpartit");

            entity.HasIndex(e => e.idpenyista, "idpenyista");

            entity.Property(e => e.idporra).HasColumnType("int(11)");
            entity.Property(e => e.data).HasColumnType("datetime");
            entity.Property(e => e.golslocal).HasColumnType("int(11)");
            entity.Property(e => e.golsvisitant).HasColumnType("int(11)");
            entity.Property(e => e.idpartit).HasColumnType("int(11)");
            entity.Property(e => e.idpenyista).HasColumnType("int(11)");
            entity.Property(e => e.idsgolejadorslocal).HasMaxLength(100);
            entity.Property(e => e.idsgolejadorsvisitant).HasMaxLength(100);

            entity.HasOne(d => d.idpartitNavigation).WithMany(p => p.porres)
                .HasForeignKey(d => d.idpartit)
                .HasConstraintName("porres_ibfk_4");

            entity.HasOne(d => d.idpenyistaNavigation).WithMany(p => p.porres)
                .HasForeignKey(d => d.idpenyista)
                .HasConstraintName("porres_ibfk_3");
        });

        modelBuilder.Entity<puntuacions>(entity =>
        {
            entity.HasKey(e => e.idpuntuacio).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.idpuntuacio).HasColumnType("int(11)");
            entity.Property(e => e.alias).HasMaxLength(15);
            entity.Property(e => e.idpenyista).HasColumnType("int(11)");
            entity.Property(e => e.puntuacio).HasColumnType("int(11)");
            entity.Property(e => e.temporada).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
