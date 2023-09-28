using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBetDW.Models.Entities;
using static System.Collections.Specialized.BitVector32;

namespace WebBetDW.Context.Context
{
    public partial class WebBetDWContext : DbContext
    {
        //Se inicia el Scaffold donde vamos a traer las tablas de SQL a código.

        public WebBetDWContext()
        {
        }

        public WebBetDWContext(DbContextOptions<WebBetDWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apuesta> Apuesta { get; set; }
        public virtual DbSet<Campeonato> Campeonatos { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<Partido> Partidos { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Sesion> Sesion { get; set; }
        public virtual DbSet<Torneo> Torneos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=WebBetDW;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apuesta>(entity =>
            {
                entity.HasKey(e => e.Idapuesta).HasName("PK__Apuesta__8F5650CE5DEF090E");

                entity.Property(e => e.Idapuesta)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDApuesta");
                entity.Property(e => e.Marcador)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.SesionNavigation).WithMany(p => p.Apuesta)
                    .HasForeignKey(d => d.Sesion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SesionApuesta");
            });

            modelBuilder.Entity<Campeonato>(entity =>
            {
                entity.HasKey(e => e.Idcampeonato).HasName("PK__Campeona__55104CF7AD2308F2");

                entity.ToTable("Campeonato");

                entity.Property(e => e.Idcampeonato)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDCampeonato");

                entity.HasOne(d => d.EquipoNavigation).WithMany(p => p.Campeonatos)
                    .HasForeignKey(d => d.Equipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EquipoCampeonato");

                entity.HasOne(d => d.TorneoNavigation).WithMany(p => p.Campeonatos)
                    .HasForeignKey(d => d.Torneo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TorneoCampeonato");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.Idcuenta).HasName("PK__Cuenta__F016C5A13F5859CF");

                entity.Property(e => e.Idcuenta)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDCuenta");
                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.RolNavigation).WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RolCuenta");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.Idequipo).HasName("PK__Equipo__034DC40FE933646D");

                entity.ToTable("Equipo");

                entity.Property(e => e.Idequipo)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDEquipo");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.Idgrupo).HasName("PK__Grupo__C5DE7CB1B0C6D5C0");

                entity.ToTable("Grupo");

                entity.Property(e => e.Idgrupo)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDGrupo");
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(e => e.Idpartido).HasName("PK__Partido__C8A49DDD8FFD56DF");

                entity.ToTable("Partido");

                entity.Property(e => e.Idpartido)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDPartido");
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.MarcadorLocal)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.MarcadorVisitante)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.EquipoLocalNavigation).WithMany(p => p.PartidoEquipoLocalNavigations)
                    .HasForeignKey(d => d.EquipoLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EquipoLocalPartido");

                entity.HasOne(d => d.EquipoVisitanteNavigation).WithMany(p => p.PartidoEquipoVisitanteNavigations)
                    .HasForeignKey(d => d.EquipoVisitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EquipoVisitantePartido");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Idrol).HasName("PK__Rol__A681ACB6CD57B870");

                entity.ToTable("Rol");

                entity.Property(e => e.Idrol)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDRol");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sesion>(entity =>
            {
                entity.HasKey(e => e.Idsesion).HasName("PK__Sesion__53DAC7C0A363E615");

                entity.ToTable("Sesion");

                entity.Property(e => e.Idsesion)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDSesion");
                entity.Property(e => e.Code)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.NombreGrupo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CuentaNavigation).WithMany(p => p.Sesions)
                    .HasForeignKey(d => d.Cuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CuentaSesion");

                entity.HasOne(d => d.PartidoNavigation).WithMany(p => p.Sesions)
                    .HasForeignKey(d => d.Partido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PartidoSesion");
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
                entity.HasKey(e => e.Idtorneo).HasName("PK__Torneo__17920A86D828F190");

                entity.ToTable("Torneo");

                entity.Property(e => e.Idtorneo)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("IDTorneo");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
