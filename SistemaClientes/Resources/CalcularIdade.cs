namespace SistemaClientes.Api.Resources
{
    public class CalcularIdade
    {
        public int ObterIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
                idade--;

            return idade;
        }
    }
}
