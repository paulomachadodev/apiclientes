namespace SistemaClientes.Api.Models
{
    public class ClientesGetModel
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
    }
}