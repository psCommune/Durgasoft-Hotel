using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hotelProject.Models;

public partial class DurgasofthotelContext : DbContext
{
    public DurgasofthotelContext()
    {
    }

    public DurgasofthotelContext(DbContextOptions<DurgasofthotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = durgasofthotel; Integrated Security = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.DateBeginning).HasColumnType("datetime");
            entity.Property(e => e.DateExpiration).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Client");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Room");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Fullname).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber).HasMaxLength(500);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.FloorNumber).HasMaxLength(50);

            entity.HasOne(d => d.RoomTypeNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Room_RoomType");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.TypeRoomId);

            entity.ToTable("RoomType");

            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.RoomType1)
                .HasMaxLength(150)
                .HasColumnName("RoomType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
