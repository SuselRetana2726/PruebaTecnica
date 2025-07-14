namespace BackEnd.Models
{
    public class Empleado
    {
        public int Codigo { get; set; }
        public string Puesto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int? CodigoJefe { get; set; }
    }
}
