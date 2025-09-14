using Dive_Deep.Models;
using System.Threading.Tasks;

namespace Dive_Deep.Persistence
{
    public static class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
        };

        //Create
        public static void Add(Product product)
        {
            if (product == null) return;
            product.ProductId = _products.Any() ? _products.Max(x => x.ProductId) + 1 : 1;
            _products.Add(product);
        }

        //Read
        public static List<Product> GetAll()
        {
            return _products;
        }

        //Read
        public static Product? GetById(int id)
        {
            return _products.FirstOrDefault(x => x.ProductId == id);
        }

        //Update
        public static void Update(int productId, Product product) //Denne metode kræver, at det Product-object man passer som argument til parameteret allerede har fået sat alle sine values før metoden udføres
        {
            var productToUpdate = GetById(productId);

            productToUpdate.Brand = product.Brand; //disse to properties kommer fra parent class, som den kan jeg tage fat i med det samme uden at type checke og caste
            productToUpdate.PricePerDay = product.PricePerDay;

            if (productToUpdate != null)
            {
                if (productToUpdate is BCD bcd && product is BCD updatedBcd)
                {
                    bcd.Model = updatedBcd.Model;
                    bcd.Sizes = updatedBcd.Sizes;
                }
                else if (productToUpdate is DivingSuit divingSuit && product is DivingSuit updatedDivingSuit)
                {
                    divingSuit.Model = updatedDivingSuit.Model;
                    divingSuit.Sizes = updatedDivingSuit.Sizes;
                    divingSuit.Type = updatedDivingSuit.Type;
                    divingSuit.Gender = updatedDivingSuit.Gender;
                    divingSuit.Thickness = updatedDivingSuit.Thickness;
                }
                else if (productToUpdate is Finns finns && product is Finns updatedFinns)
                {
                    finns.Model = updatedFinns.Model;
                    finns.Sizes = updatedFinns.Sizes;
                }
                else if (productToUpdate is MaskSnorkel maskSnorkel && product is MaskSnorkel updatedMaskSnorkel)
                {
                    maskSnorkel.Model = updatedMaskSnorkel.Model;
                }
                else if (productToUpdate is RegulatorSet regulatorSet && product is RegulatorSet updatedRegulatorSet)
                {
                    regulatorSet.FirstStep = updatedRegulatorSet.FirstStep;
                    regulatorSet.SecondStep = updatedRegulatorSet.SecondStep;
                    regulatorSet.Octopus = updatedRegulatorSet.Octopus;
                }
                else if (productToUpdate is Tank tank && product is Tank updatedTank)
                {
                    tank.Volume = updatedTank.Volume;
                }

            }
        }

        static ProductRepository()
        {
            Add(new BCD { Brand = "Scubapro", Model = "Navigator Lite BCD", PricePerDay = 125 });
            Add(new BCD { Brand = "Scubapro", Model = "BCD Glide", PricePerDay = 140 });
            Add(new BCD { Brand = "Scubapro", Model = "BCD Hydros Pro", PricePerDay = 200 });
            Add(new BCD { Brand = "Seac", Model = "BCD Modular", PricePerDay = 145 });
            Add(new DivingSuit { Brand = "Scubapro", Model = "Definition", Sizes = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = 3f, PricePerDay = 100 });
            Add(new DivingSuit { Brand = "Scubapro", Model = "Definition", Sizes = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = 5f, PricePerDay = 100 });
            Add(new DivingSuit { Brand = "Scubapro", Model = "Definition", Sizes = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = 7f, PricePerDay = 100 });
            Add(new DivingSuit { Brand = "Waterproof", Model = "W5", Sizes = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = 3.5f, PricePerDay = 100 });
            Add(new DivingSuit { Brand = "Fourth Element", Model = "Proteus", Sizes = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = 5f, PricePerDay = 120 });
            Add(new DivingSuit { Brand = "Scubapro", Model = "Exodry 4.0", Sizes = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = null, PricePerDay = 300 });
            Add(new DivingSuit { Brand = "Waterproof", Model = "D7 Evo", Sizes = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = null, PricePerDay = 320 });
            Add(new DivingSuit { Brand = "Santi", Model = "E.Lite Plus", Sizes = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = null, PricePerDay = 350 });
        }
    }
}
