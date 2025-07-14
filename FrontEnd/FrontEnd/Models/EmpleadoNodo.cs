namespace FrontEnd.Models
{
    public class EmpleadoNodo
    {
        public int Codigo { get; set; }
        public string Puesto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public List<EmpleadoNodo> Subordinados { get; set; } = new();
    }
}
