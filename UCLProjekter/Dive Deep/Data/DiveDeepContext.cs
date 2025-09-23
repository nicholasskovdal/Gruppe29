using Dive_Deep.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dive_Deep.Data
{
    public class DiveDeepContext : DbContext
    {

        public DiveDeepContext(DbContextOptions<DiveDeepContext> options) : base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<BCD> BCDs { get; set; }
        public DbSet<DivingSuit> DivingSuits { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<RegulatorSet> RegulatorSets { get; set; }
        public DbSet<MaskSnorkel> MaskSnorkels { get; set; }
        public DbSet<Finns> Finns { get; set; }

        public DbSet<ProductBooking> ProductBookings { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BCD>().ToTable("BCDs");
            modelBuilder.Entity<DivingSuit>().ToTable("DivingSuits");
            modelBuilder.Entity<Tank>().ToTable("Tanks");
            modelBuilder.Entity<Finns>().ToTable("Finns");
            modelBuilder.Entity<MaskSnorkel>().ToTable("MaskSnorkels");
            modelBuilder.Entity<RegulatorSet>().ToTable("RegulatorSets");

            modelBuilder.Entity<ProductBooking>().HasKey(pb => new { pb.ProductId, pb.BookingId });

            modelBuilder.Entity<ProductBooking>()
                .HasOne(pb => pb.Product)
                .WithMany(p => p.ProductBookings)
                .HasForeignKey(pb => pb.ProductId);

            modelBuilder.Entity<ProductBooking>()
                .HasOne(pb => pb.Booking)
                .WithMany(b => b.ProductBookings)
                .HasForeignKey(pb => pb.BookingId);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Cart)
                .HasForeignKey(i => i.CartId);
            
            modelBuilder.Entity<CartItem>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);
                

            modelBuilder.Entity<BCD>().HasData(
               new BCD { ProductId = 1, Brand = "Scubapro", Model = "Navigator Lite BCD", Sizes = "S", PricePerDay = 125 },
new BCD { ProductId = 2, Brand = "Scubapro", Model = "Navigator Lite BCD", Sizes = "M", PricePerDay = 125 },
new BCD { ProductId = 3, Brand = "Scubapro", Model = "Navigator Lite BCD", Sizes = "L", PricePerDay = 125 },
new BCD { ProductId = 4, Brand = "Scubapro", Model = "BCD Glide", Sizes = "S", PricePerDay = 140 },
new BCD { ProductId = 5, Brand = "Scubapro", Model = "BCD Glide", Sizes = "M", PricePerDay = 140 },
new BCD { ProductId = 6, Brand = "Scubapro", Model = "BCD Glide", Sizes = "L", PricePerDay = 140 },
new BCD { ProductId = 7, Brand = "Scubapro", Model = "BCD Hydros Pro", Sizes = "S", PricePerDay = 200 },
new BCD { ProductId = 8, Brand = "Scubapro", Model = "BCD Hydros Pro", Sizes = "M", PricePerDay = 200 },
new BCD { ProductId = 9, Brand = "Scubapro", Model = "BCD Hydros Pro", Sizes = "L", PricePerDay = 200 },
new BCD { ProductId = 10, Brand = "Seac", Model = "BCD Modular", Sizes = "S", PricePerDay = 145 },
new BCD { ProductId = 11, Brand = "Seac", Model = "BCD Modular", Sizes = "M", PricePerDay = 145 },
new BCD { ProductId = 12, Brand = "Seac", Model = "BCD Modular", Sizes = "L", PricePerDay = 145 }
);
            modelBuilder.Entity<DivingSuit>().HasData(
            new DivingSuit { ProductId = 13, Brand = "Scubapro", Model = "Definition", Sizes = "XS", Type = "Våddragt", Gender = "Herre", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 14, Brand = "Scubapro", Model = "Definition", Sizes = "XS", Type = "Våddragt", Gender = "Dame", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 15, Brand = "Scubapro", Model = "Definition", Sizes = "XS", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 16, Brand = "Scubapro", Model = "Definition", Sizes = "XS", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 17, Brand = "Scubapro", Model = "Definition", Sizes = "XS", Type = "Våddragt", Gender = "Herre", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 18, Brand = "Scubapro", Model = "Definition", Sizes = "XS", Type = "Våddragt", Gender = "Dame", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 19, Brand = "Scubapro", Model = "Definition", Sizes = "S", Type = "Våddragt", Gender = "Herre", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 20, Brand = "Scubapro", Model = "Definition", Sizes = "S", Type = "Våddragt", Gender = "Dame", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 21, Brand = "Scubapro", Model = "Definition", Sizes = "S", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 22, Brand = "Scubapro", Model = "Definition", Sizes = "S", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 23, Brand = "Scubapro", Model = "Definition", Sizes = "S", Type = "Våddragt", Gender = "Herre", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 24, Brand = "Scubapro", Model = "Definition", Sizes = "S", Type = "Våddragt", Gender = "Dame", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 25, Brand = "Scubapro", Model = "Definition", Sizes = "M", Type = "Våddragt", Gender = "Herre", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 26, Brand = "Scubapro", Model = "Definition", Sizes = "M", Type = "Våddragt", Gender = "Dame", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 27, Brand = "Scubapro", Model = "Definition", Sizes = "M", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 28, Brand = "Scubapro", Model = "Definition", Sizes = "M", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 29, Brand = "Scubapro", Model = "Definition", Sizes = "M", Type = "Våddragt", Gender = "Herre", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 30, Brand = "Scubapro", Model = "Definition", Sizes = "M", Type = "Våddragt", Gender = "Dame", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 31, Brand = "Scubapro", Model = "Definition", Sizes = "L", Type = "Våddragt", Gender = "Herre", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 32, Brand = "Scubapro", Model = "Definition", Sizes = "L", Type = "Våddragt", Gender = "Dame", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 33, Brand = "Scubapro", Model = "Definition", Sizes = "L", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 34, Brand = "Scubapro", Model = "Definition", Sizes = "L", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 35, Brand = "Scubapro", Model = "Definition", Sizes = "L", Type = "Våddragt", Gender = "Herre", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 36, Brand = "Scubapro", Model = "Definition", Sizes = "L", Type = "Våddragt", Gender = "Dame", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 37, Brand = "Scubapro", Model = "Definition", Sizes = "XL", Type = "Våddragt", Gender = "Herre", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 38, Brand = "Scubapro", Model = "Definition", Sizes = "XL", Type = "Våddragt", Gender = "Dame", Thickness = 3.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 39, Brand = "Scubapro", Model = "Definition", Sizes = "XL", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 40, Brand = "Scubapro", Model = "Definition", Sizes = "XL", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 41, Brand = "Scubapro", Model = "Definition", Sizes = "XL", Type = "Våddragt", Gender = "Herre", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 42, Brand = "Scubapro", Model = "Definition", Sizes = "XL", Type = "Våddragt", Gender = "Dame", Thickness = 7.0f, PricePerDay = 100 },
new DivingSuit { ProductId = 43, Brand = "Waterproof", Model = "W5", Sizes = "XS", Type = "Våddragt", Gender = "Herre", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 44, Brand = "Waterproof", Model = "W5", Sizes = "XS", Type = "Våddragt", Gender = "Dame", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 45, Brand = "Waterproof", Model = "W5", Sizes = "S", Type = "Våddragt", Gender = "Herre", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 46, Brand = "Waterproof", Model = "W5", Sizes = "S", Type = "Våddragt", Gender = "Dame", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 47, Brand = "Waterproof", Model = "W5", Sizes = "M", Type = "Våddragt", Gender = "Herre", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 48, Brand = "Waterproof", Model = "W5", Sizes = "M", Type = "Våddragt", Gender = "Dame", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 49, Brand = "Waterproof", Model = "W5", Sizes = "L", Type = "Våddragt", Gender = "Herre", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 50, Brand = "Waterproof", Model = "W5", Sizes = "L", Type = "Våddragt", Gender = "Dame", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 51, Brand = "Waterproof", Model = "W5", Sizes = "XL", Type = "Våddragt", Gender = "Herre", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 52, Brand = "Waterproof", Model = "W5", Sizes = "XL", Type = "Våddragt", Gender = "Dame", Thickness = 3.5f, PricePerDay = 100 },
new DivingSuit { ProductId = 53, Brand = "Fourth Element", Model = "Proteus", Sizes = "XS", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 54, Brand = "Fourth Element", Model = "Proteus", Sizes = "XS", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 55, Brand = "Fourth Element", Model = "Proteus", Sizes = "S", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 56, Brand = "Fourth Element", Model = "Proteus", Sizes = "S", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 57, Brand = "Fourth Element", Model = "Proteus", Sizes = "M", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 58, Brand = "Fourth Element", Model = "Proteus", Sizes = "M", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 59, Brand = "Fourth Element", Model = "Proteus", Sizes = "L", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 60, Brand = "Fourth Element", Model = "Proteus", Sizes = "L", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 61, Brand = "Fourth Element", Model = "Proteus", Sizes = "XL", Type = "Våddragt", Gender = "Herre", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 62, Brand = "Fourth Element", Model = "Proteus", Sizes = "XL", Type = "Våddragt", Gender = "Dame", Thickness = 5.0f, PricePerDay = 120 },
new DivingSuit { ProductId = 63, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "XS", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 64, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "XS", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 65, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "S", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 66, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "S", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 67, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "M", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 68, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "M", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 69, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "L", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 70, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "L", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 71, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "XL", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 72, Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "XL", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 300 },
new DivingSuit { ProductId = 73, Brand = "Waterproof", Model = "D7 Evo", Sizes = "XS", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 74, Brand = "Waterproof", Model = "D7 Evo", Sizes = "XS", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 75, Brand = "Waterproof", Model = "D7 Evo", Sizes = "S", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 76, Brand = "Waterproof", Model = "D7 Evo", Sizes = "S", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 77, Brand = "Waterproof", Model = "D7 Evo", Sizes = "M", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 78, Brand = "Waterproof", Model = "D7 Evo", Sizes = "M", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 79, Brand = "Waterproof", Model = "D7 Evo", Sizes = "L", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 80, Brand = "Waterproof", Model = "D7 Evo", Sizes = "L", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 81, Brand = "Waterproof", Model = "D7 Evo", Sizes = "XL", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 82, Brand = "Waterproof", Model = "D7 Evo", Sizes = "XL", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 320 },
new DivingSuit { ProductId = 83, Brand = "Santi", Model = "E.Lite Plus", Sizes = "XS", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 84, Brand = "Santi", Model = "E.Lite Plus", Sizes = "XS", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 85, Brand = "Santi", Model = "E.Lite Plus", Sizes = "S", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 86, Brand = "Santi", Model = "E.Lite Plus", Sizes = "S", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 87, Brand = "Santi", Model = "E.Lite Plus", Sizes = "M", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 88, Brand = "Santi", Model = "E.Lite Plus", Sizes = "M", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 89, Brand = "Santi", Model = "E.Lite Plus", Sizes = "L", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 90, Brand = "Santi", Model = "E.Lite Plus", Sizes = "L", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 91, Brand = "Santi", Model = "E.Lite Plus", Sizes = "XL", Type = "Tordragt", Gender = "Herre", Thickness = null, PricePerDay = 350 },
new DivingSuit { ProductId = 92, Brand = "Santi", Model = "E.Lite Plus", Sizes = "XL", Type = "Tordragt", Gender = "Dame", Thickness = null, PricePerDay = 350 }
);
            modelBuilder.Entity<Tank>().HasData(
new Tank { ProductId = 93, Brand = "Scubapro", Volume = 5, PricePerDay = 150 },
new Tank { ProductId = 94, Brand = "Scubapro", Volume = 10, PricePerDay = 160 },
new Tank { ProductId = 95, Brand = "Scubapro", Volume = 12, PricePerDay = 170 },
new Tank { ProductId = 96, Brand = "Scubapro", Volume = 15, PricePerDay = 180 }
);
            modelBuilder.Entity<RegulatorSet>().HasData(
new RegulatorSet { ProductId = 97, Brand = "Scubapro", FirstStep = "MK25EVO", SecondStep = "S600", Octopus = "R105", PricePerDay = 125 },
new RegulatorSet { ProductId = 98, Brand = "Scubapro", FirstStep = "MK17EVO", SecondStep = "C370", Octopus = "R095", PricePerDay = 100 },
new RegulatorSet { ProductId = 99, Brand = "Scubapro", FirstStep = "MK25EVO BT", SecondStep = "A700 Carbon BT", Octopus = "S270", PricePerDay = 150 }
);
            modelBuilder.Entity<MaskSnorkel>().HasData(
new MaskSnorkel { ProductId = 100, Brand = "Scubapro", Model = "Ghost", PricePerDay = 50 },
new MaskSnorkel { ProductId = 101, Brand = "Scubapro", Model = "D-Mask", PricePerDay = 60 },
new MaskSnorkel { ProductId = 102, Brand = "Scubapro", Model = "Spectra Mini", PricePerDay = 50 },
new MaskSnorkel { ProductId = 103, Brand = "Scubapro", Model = "Crystal VU", PricePerDay = 75 },
new MaskSnorkel { ProductId = 104, Brand = "Fourth Element", Model = "Scout Kontrast", PricePerDay = 75 },
new MaskSnorkel { ProductId = 105, Brand = "Fourth Element", Model = "Scout Enhance", PricePerDay = 75 },
new MaskSnorkel { ProductId = 106, Brand = "Tusa", Model = "Element", PricePerDay = 75 }
);
            modelBuilder.Entity<Finns>().HasData(
new Finns { ProductId = 107, Brand = "Scubapro", Model = "Jet Fin", Sizes = "XS", PricePerDay = 50 },
new Finns { ProductId = 108, Brand = "Scubapro", Model = "Jet Fin", Sizes = "S", PricePerDay = 50 },
new Finns { ProductId = 109, Brand = "Scubapro", Model = "Jet Fin", Sizes = "M", PricePerDay = 50 },
new Finns { ProductId = 110, Brand = "Scubapro", Model = "Jet Fin", Sizes = "L", PricePerDay = 50 },
new Finns { ProductId = 111, Brand = "Scubapro", Model = "Jet Fin", Sizes = "XL", PricePerDay = 50 },
new Finns { ProductId = 112, Brand = "Scubapro", Model = "GO Travel", Sizes = "XS", PricePerDay = 50 },
new Finns { ProductId = 113, Brand = "Scubapro", Model = "GO Travel", Sizes = "S", PricePerDay = 50 },
new Finns { ProductId = 114, Brand = "Scubapro", Model = "GO Travel", Sizes = "M", PricePerDay = 50 },
new Finns { ProductId = 115, Brand = "Scubapro", Model = "GO Travel", Sizes = "L", PricePerDay = 50 },
new Finns { ProductId = 116, Brand = "Scubapro", Model = "GO Travel", Sizes = "XL", PricePerDay = 50 },
new Finns { ProductId = 117, Brand = "Scubapro", Model = "Seawing Supernova", Sizes = "XS", PricePerDay = 60 },
new Finns { ProductId = 118, Brand = "Scubapro", Model = "Seawing Supernova", Sizes = "S", PricePerDay = 60 },
new Finns { ProductId = 119, Brand = "Scubapro", Model = "Seawing Supernova", Sizes = "M", PricePerDay = 60 },
new Finns { ProductId = 120, Brand = "Scubapro", Model = "Seawing Supernova", Sizes = "L", PricePerDay = 60 },
new Finns { ProductId = 121, Brand = "Scubapro", Model = "Seawing Supernova", Sizes = "XL", PricePerDay = 60 },
new Finns { ProductId = 122, Brand = "Seac", Model = "Propulsion", Sizes = "XS", PricePerDay = 50 },
new Finns { ProductId = 123, Brand = "Seac", Model = "Propulsion", Sizes = "S", PricePerDay = 50 },
new Finns { ProductId = 124, Brand = "Seac", Model = "Propulsion", Sizes = "M", PricePerDay = 50 },
new Finns { ProductId = 125, Brand = "Seac", Model = "Propulsion", Sizes = "L", PricePerDay = 50 },
new Finns { ProductId = 126, Brand = "Seac", Model = "Propulsion", Sizes = "XL", PricePerDay = 50 },
new Finns { ProductId = 127, Brand = "Seac", Model = "ALA", Sizes = "XS", PricePerDay = 50 },
new Finns { ProductId = 128, Brand = "Seac", Model = "ALA", Sizes = "S", PricePerDay = 50 },
new Finns { ProductId = 129, Brand = "Seac", Model = "ALA", Sizes = "M", PricePerDay = 50 },
new Finns { ProductId = 130, Brand = "Seac", Model = "ALA", Sizes = "L", PricePerDay = 50 },
new Finns { ProductId = 131, Brand = "Seac", Model = "ALA", Sizes = "XL", PricePerDay = 50 },
new Finns { ProductId = 132, Brand = "Fourth Element", Model = "Tech", Sizes = "XS", PricePerDay = 75 },
new Finns { ProductId = 133, Brand = "Fourth Element", Model = "Tech", Sizes = "S", PricePerDay = 75 },
new Finns { ProductId = 134, Brand = "Fourth Element", Model = "Tech", Sizes = "M", PricePerDay = 75 },
new Finns { ProductId = 135, Brand = "Fourth Element", Model = "Tech", Sizes = "L", PricePerDay = 75 },
new Finns { ProductId = 136, Brand = "Fourth Element", Model = "Tech", Sizes = "XL", PricePerDay = 75 },
new Finns { ProductId = 137, Brand = "Fourth Element", Model = "Rec Fin", Sizes = "XS", PricePerDay = 80 },
new Finns { ProductId = 138, Brand = "Fourth Element", Model = "Rec Fin", Sizes = "S", PricePerDay = 80 },
new Finns { ProductId = 139, Brand = "Fourth Element", Model = "Rec Fin", Sizes = "M", PricePerDay = 80 },
new Finns { ProductId = 140, Brand = "Fourth Element", Model = "Rec Fin", Sizes = "L", PricePerDay = 80 },
new Finns { ProductId = 141, Brand = "Fourth Element", Model = "Rec Fin", Sizes = "XL", PricePerDay = 80 }
);
                
        }
    }
}
