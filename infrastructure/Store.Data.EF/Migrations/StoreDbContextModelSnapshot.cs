﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Data.EF;

namespace Store.Data.EF.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class StoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Store.Data.DetailDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Part_number")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Company = "Япония",
                            Description = "Высоковольтные провода (зажигания) для Audi 80 B3 89,89Q,8A,B3 Седан 1.6 75 л.с.",
                            Part_number = "123456987",
                            Price = 3040m,
                            Title = "Комплект проводов зажигания"
                        },
                        new
                        {
                            Id = 2,
                            Company = "Германия",
                            Description = "Материал:силикон, эпоксидная смола; Сопротивление[Ом]:5000. Ширина зева гаечного ключа:21 mm",
                            Part_number = "167845621",
                            Price = 570m,
                            Title = "Вилка, свеча зажигания"
                        },
                        new
                        {
                            Id = 3,
                            Company = "JP GROUP Дания",
                            Description = "Сторона установки:передний мост. Сторона установки:со стороны коробки передач",
                            Part_number = "456456871",
                            Price = 1130m,
                            Title = "Комплект пылника, приводной вал"
                        });
                });

            modelBuilder.Entity("Store.Data.OrderDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CellPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("DeliveryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryParameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("money");

                    b.Property<string>("DeliveryUniqueCode")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PaymentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentParameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentServiceName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Store.Data.OrderItemDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("DetailId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Store.Data.OrderItemDTO", b =>
                {
                    b.HasOne("Store.Data.OrderDTO", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Store.Data.OrderDTO", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
