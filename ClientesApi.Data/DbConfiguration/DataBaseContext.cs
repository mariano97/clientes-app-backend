using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ClientesApi.Data.Models;

namespace ClientesApi.Data.DbConfiguration;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asesor> Asesors { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=prueba;uid=root;password=Mario12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asesor>(entity =>
        {
            entity.HasKey(e => e.Idasesor).HasName("PRIMARY");

            entity.ToTable("asesor");

            entity.HasIndex(e => e.ClienteId, "fk_cliente_idx");

            entity.Property(e => e.Idasesor).HasColumnName("idasesor");
            entity.Property(e => e.ClienteId).HasColumnName("clienteId");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(45)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Asesors)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cliente");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(45)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
