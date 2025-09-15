using System;
using System.Collections.Generic;
namespace DataSeedGenerator
{

    public class Seeder
    {
        private static int productId = 1;

        public static void Main()
        {
            GenerateBCDs();
            GenerateDivingSuits();
            GenerateTanks();
            GenerateRegulators();
            GenerateMasks();
            GenerateFins();
        }

        static void GenerateBCDs()
        {
            var bcds = new[]
            {
            new { Brand="Scubapro", Model="Navigator Lite BCD", Sizes=new[]{"S","M","L"}, Price=125 },
            new { Brand="Scubapro", Model="BCD Glide", Sizes=new[]{"S","M","L"}, Price=140 },
            new { Brand="Scubapro", Model="BCD Hydros Pro", Sizes=new[]{"S","M","L"}, Price=200 },
            new { Brand="Seac", Model="BCD Modular", Sizes=new[]{"S","M","L"}, Price=145 }
        };

            foreach (var bcd in bcds)
            {
                foreach (var size in bcd.Sizes)
                {
                    Console.WriteLine(
                        $"new BCD {{ ProductId = {productId++}, Brand = \"{bcd.Brand}\", Model = \"{bcd.Model}\", Sizes = \"{size}\", PricePerDay = {bcd.Price} }},");
                }
            }
        }

        static void GenerateDivingSuits()
        {
            var genders = new[] { "Herre", "Dame" };

            var suits = new[]
            {
        new { Brand="Scubapro", Model="Definition", Sizes=new[]{"XS","S","M","L","XL"}, Type="Våddragt", Thicknesses=new float?[]{3f, 5f, 7f}, Price=100 },
        new { Brand="Waterproof", Model="W5", Sizes=new[]{"XS","S","M","L","XL"}, Type="Våddragt", Thicknesses=new float?[]{3.5f}, Price=100 },
        new { Brand="Fourth Element", Model="Proteus", Sizes=new[]{"XS","S","M","L","XL"}, Type="Våddragt", Thicknesses=new float?[]{5f}, Price=120 },
        new { Brand="Scubapro", Model="Exodry 4.0", Sizes=new[]{"XS","S","M","L","XL"}, Type="Tørdragt", Thicknesses=new float?[]{null}, Price=300 },
        new { Brand="Waterproof", Model="D7 Evo", Sizes=new[]{"XS","S","M","L","XL"}, Type="Tørdragt", Thicknesses=new float?[]{null}, Price=320 },
        new { Brand="Santi", Model="E.Lite Plus", Sizes=new[]{"XS","S","M","L","XL"}, Type="Tørdragt", Thicknesses=new float?[]{null}, Price=350 },
    };

            foreach (var suit in suits)
            {
                foreach (var size in suit.Sizes)
                {
                    foreach (var thickness in suit.Thicknesses)
                    {
                        foreach (var gender in genders)
                        {
                            Console.WriteLine(
                                $"new DivingSuit {{ ProductId = {productId++}, Brand = \"{suit.Brand}\", Model = \"{suit.Model}\", Sizes = \"{size}\", Type = \"{suit.Type}\", Gender = \"{gender}\", Thickness = {(thickness.HasValue ? thickness.Value.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) : "null")}, PricePerDay = {suit.Price} }},");
                        }
                    }
                }
            }
        }

        static void GenerateTanks()
        {
            var tanks = new[]
            {
            new { Brand="Scubapro", Volume=5, Price=150 },
            new { Brand="Scubapro", Volume=10, Price=160 },
            new { Brand="Scubapro", Volume=12, Price=170 },
            new { Brand="Scubapro", Volume=15, Price=180 }
        };

            foreach (var t in tanks)
            {
                Console.WriteLine(
                    $"new Tank {{ ProductId = {productId++}, Brand = \"{t.Brand}\", Volume = {t.Volume}, PricePerDay = {t.Price} }},");
            }
        }

        static void GenerateRegulators()
        {
            var regs = new[]
            {
            new { Brand="Scubapro", First="MK25EVO", Second="S600", Octo="R105", Price=125 },
            new { Brand="Scubapro", First="MK17EVO", Second="C370", Octo="R095", Price=100 },
            new { Brand="Scubapro", First="MK25EVO BT", Second="A700 Carbon BT", Octo="S270", Price=150 }
        };

            foreach (var r in regs)
            {
                Console.WriteLine(
                    $"new RegulatorSet {{ ProductId = {productId++}, Brand = \"{r.Brand}\", FirstStep = \"{r.First}\", SecondStep = \"{r.Second}\", Octopus = \"{r.Octo}\", PricePerDay = {r.Price} }},");
            }
        }

        static void GenerateMasks()
        {
            var masks = new[]
            {
            new { Brand="Scubapro", Model="Ghost", Price=50 },
            new { Brand="Scubapro", Model="D-Mask", Price=60 },
            new { Brand="Scubapro", Model="Spectra Mini", Price=50 },
            new { Brand="Scubapro", Model="Crystal VU", Price=75 },
            new { Brand="Fourth Element", Model="Scout Kontrast", Price=75 },
            new { Brand="Fourth Element", Model="Scout Enhance", Price=75 },
            new { Brand="Tusa", Model="Element", Price=75 }
        };

            foreach (var m in masks)
            {
                Console.WriteLine(
                    $"new MaskSnorkel {{ ProductId = {productId++}, Brand = \"{m.Brand}\", Model = \"{m.Model}\", PricePerDay = {m.Price} }},");
            }
        }

        static void GenerateFins()
        {
            var fins = new[]
            {
            new { Brand="Scubapro", Model="Jet Fin", Price=50 },
            new { Brand="Scubapro", Model="GO Travel", Price=50 },
            new { Brand="Scubapro", Model="Seawing Supernova", Price=60 },
            new { Brand="Seac", Model="Propulsion", Price=50 },
            new { Brand="Seac", Model="ALA", Price=50 },
            new { Brand="Fourth Element", Model="Tech", Price=75 },
            new { Brand="Fourth Element", Model="Rec Fin", Price=80 }
        };

            var sizes = new[] { "XS", "S", "M", "L", "XL" };

            foreach (var f in fins)
            {
                foreach (var size in sizes)
                {
                    Console.WriteLine(
                        $"new Finns {{ ProductId = {productId++}, Brand = \"{f.Brand}\", Model = \"{f.Model}\", Sizes = \"{size}\", PricePerDay = {f.Price} }},");
                }
            }
        }
    }
}
