namespace NexFinance.src.Application.DTOs {
    public class ContaDto {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }

    public class CreateContaDto {
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }

    public class UpdateContaDto {
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
    }
}
