using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class FullLineUser
    {
        [Key]
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Adress { get; set; }
        public string Period { get; set; }
        public double Sum { get; set; }
        public string? GasId { get; set; }
        public double? GasMeterReads { get; set; }
    }
}
