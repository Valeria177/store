using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Data.EF
{
    public class StoreDbContext : DbContext
    {
        public DbSet<DetailDTO> Details { get; set; }
        public DbSet<OrderDTO> Orders { get; set; }
        public DbSet<OrderItemDTO> OrderItems { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildDetails(modelBuilder);

            BuildOrders(modelBuilder);

            BuildOrderItems(modelBuilder);

        }

        private void BuildOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDTO>(action =>
            {
                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasOne(dto => dto.Order)
                      .WithMany(dto => dto.Items)
                      .IsRequired();
            });
        }

        private static void BuildOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDTO>(action =>
            {
                action.Property(dto => dto.CellPhone)
                      .HasMaxLength(20);

                action.Property(dto => dto.DeliveryUniqueCode)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryPrice)
                      .HasColumnType("money");

                action.Property(dto => dto.PaymentServiceName)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);

                action.Property(dto => dto.PaymentParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);
            });
        }

        private static readonly ValueComparer DictionaryComparer =
           new ValueComparer<Dictionary<string, string>>(
               (dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
               dictionary => dictionary.Aggregate(
                   0,
                   (a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode()), p.Value.GetHashCode())
               )
           );

        private static void BuildDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailDTO>(action =>
            {
                action.Property(dto => dto.Part_number)
                      .HasMaxLength(17)
                      .IsRequired();

                action.Property(dto => dto.Title)
                      .IsRequired();

                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasData(
                                    new DetailDTO
                                    {
                                        Id = 1,
                                        Part_number = "123456987",
                                        Company = "Япония",
                                        Title = "Комплект проводов зажигания",
                                        Description = "Высоковольтные провода (зажигания) для Audi 80 B3 89,89Q,8A,B3 Седан 1.6 75 л.с.",
                                        Price = 3040,

                                    },

                                     new DetailDTO
                                     {
                                         Id = 2,
                                         Part_number = "167845621",
                                         Company = "Германия",
                                         Title = "Вилка, свеча зажигания",
                                         Description = "Материал:силикон, эпоксидная смола; Сопротивление[Ом]:5000. Ширина зева гаечного ключа:21 mm",
                                         Price = 570,

                                     },

                                      new DetailDTO
                                      {
                                          Id = 3,
                                          Part_number = "456456871",
                                          Company = "JP GROUP Дания",
                                          Title = "Комплект пылника, приводной вал",
                                          Description = "Сторона установки:передний мост. Сторона установки:со стороны коробки передач",
                                          Price = 1130,

                                      }
                    );

            });
        }

    }
}
