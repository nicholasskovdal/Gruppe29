namespace Dive_Deep.Models
{
    public class DivingSuit : Product
    {
        public string Model { get; set; }
        public string Sizes { get; set; } = "XS, S, M, L, XL";
        public string Type { get; set; }
        public string Gender { get; set; } = "Herre/Dame";
        public float? Thickness { get; set; }


    }
}
