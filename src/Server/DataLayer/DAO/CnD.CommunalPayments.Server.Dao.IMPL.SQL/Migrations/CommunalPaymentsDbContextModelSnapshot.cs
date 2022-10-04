﻿// <auto-generated />
using System;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Migrations
{
    [DbContext(typeof(CommunalPaymentsDbContext))]
    partial class CommunalPaymentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsPaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false)
                        .HasColumnName("is_paid");

                    b.Property<int>("PeriodId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("period_id");

                    b.Property<int>("ProviderId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("provider_id");

                    b.Property<decimal>("Sum")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId")
                        .IsUnique();

                    b.HasIndex("ProviderId")
                        .IsUnique();

                    b.ToTable("Invoices", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceServicesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Amount");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("InvoiceId");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ServiceId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("InvoiceServices", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("FileName");

                    b.Property<byte[]>("OrderScreen")
                        .IsRequired()
                        .HasColumnType("BLOB")
                        .HasColumnName("OrderScreen");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.PaymentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("DatePayment")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DatePayment");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("InvoiceId");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("OrderId");

                    b.Property<bool>("Paid")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Paid");

                    b.Property<decimal>("PaymentSum")
                        .HasColumnType("TEXT")
                        .HasColumnName("PaymentSum");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.PeriodEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT")
                        .HasColumnName("month");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("Periods", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.ProviderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("NameProvider")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name_provider");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.Property<string>("WebSite")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("website");

                    b.HasKey("Id");

                    b.ToTable("Providers", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.ServiceCounterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("DateCount")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("DateCount");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ServiceId");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceCounters", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCounter")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsCounter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ServiceName");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceEntity", b =>
                {
                    b.HasOne("CnD.CommunalPayments.Server.Dao.Entities.Models.PeriodEntity", "Period")
                        .WithOne()
                        .HasForeignKey("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceEntity", "PeriodId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CnD.CommunalPayments.Server.Dao.Entities.Models.ProviderEntity", "Provider")
                        .WithOne()
                        .HasForeignKey("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceEntity", "ProviderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Period");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceServicesEntity", b =>
                {
                    b.HasOne("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceEntity", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CnD.CommunalPayments.Server.Dao.Entities.Models.ServiceEntity", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.PaymentEntity", b =>
                {
                    b.HasOne("CnD.CommunalPayments.Server.Dao.Entities.Models.InvoiceEntity", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CnD.CommunalPayments.Server.Dao.Entities.Models.OrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CnD.CommunalPayments.Server.Dao.Entities.Models.ServiceCounterEntity", b =>
                {
                    b.HasOne("CnD.CommunalPayments.Server.Dao.Entities.Models.ServiceEntity", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });
#pragma warning restore 612, 618
        }
    }
}