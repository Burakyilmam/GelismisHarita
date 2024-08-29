using Microsoft.Spatial;

namespace WebApplication1.Models.Entity
{
    public class Drawing
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Statu { get; set; }
        public string Type { get; set; }
        public string Coordinates { get; set; }
        public Geometry Shape { get; set; }
    }
}
