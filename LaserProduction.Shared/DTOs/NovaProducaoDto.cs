namespace LaserProduction.Shared.DTOs
{
    public class NovaProducaoDto
    {
        public string Pedido { get; set; }
        public string Cliente { get; set; }
        public string? NumeroTag { get; set; }
        public string MaquinaAtual { get; set; }
        public int UsuarioId { get; set; } 
    }
}