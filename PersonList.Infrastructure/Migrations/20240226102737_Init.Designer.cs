﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonList.Infrastructure.Persistance;

#nullable disable

namespace PersonList.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240226102737_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonList.Domain.Entities.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("PersonList.Domain.Entities.Person", b =>
                {
                    b.OwnsOne("PersonList.Domain.Entities.Contact", "contact", b1 =>
                        {
                            b1.Property<int>("Personid")
                                .HasColumnType("int");

                            b1.Property<string>("adress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("email")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("phoneNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Personid");

                            b1.ToTable("persons");

                            b1.WithOwner()
                                .HasForeignKey("Personid");
                        });

                    b.Navigation("contact")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
