using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Day33_new2
{
    public class InformationAboutTourists
    {
        public int Id_tourist { get; set; }
        public string Passport_series { get; set; }
        public string City { get; set; }
        public string Cointry { get; set; }
        public string Telephone { get; set; }
        public int Index { get; set; }
    }

    public class Payment
    {
        public int Id_payment { get; set; }
        public int Id_travel_package { get; set; }
        public DateTime Payment_data { get; set; }
        public decimal Amount { get; set; }
    }

    public class Season
    {
        public int Id_season { get; set; }
        public int Id_tour { get; set; }
        public DateTime Data_start { get; set; }
        public DateTime Data_end { get; set; }
        public DateTime Season_is_closed { get; set; }
        public int Amount_of_places { get; set; }
    }

    public class Tour
    {
        public int Id_tour { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Information { get; set; }
    }

    public class Tourist
    {
        public int Id_tourist { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }

        public string Middle_name { get; set; }
    }

    public class TravelPackage
    {
        public int Id_travel_package { get; set; }
        public int Id_tourist { get; set; }
        public int Id_season { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<InformationAboutTourists> InformationAboutTourists { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=bdtur_firm;user=root;password=");
        }
    }
}
