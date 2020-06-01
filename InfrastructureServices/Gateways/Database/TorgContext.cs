using Microsoft.EntityFrameworkCore;
using TorgObject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TorgObject.InfrastructureServices.Gateways.Database
{
    public class TorgContext : DbContext
    {
        public DbSet<PechatProduct> PechatProducts { get; set; }

        public TorgContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PechatProduct>().HasData(
                new
                {
                    Id = 1L,
                    District = "СЗАО",
                    Name = @"НТО ул. Авиационная, вл.68",
                    Area = "Щукино",
                    Address = "город Москва, Авиационная улица, дом 68",
                    Period = "с 1 января по 31 декабря",
                    Number = "НТО-09-02-002652",
                    FacilityArea = "9",
                    NameOfBusinessEntity = "Компания ФРЕГАТ"

                }
            );
        }
    }
}
