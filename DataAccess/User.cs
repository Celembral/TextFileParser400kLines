using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Adress { get; set; }
        public string Period { get; set; }
        public double Sum { get; set; }
        public string? IdGasMeter { get; set; }
        public double? GasMeterReadings { get; set; }
    }
}
