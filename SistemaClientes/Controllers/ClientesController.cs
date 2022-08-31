using Microsoft.AspNetCore.Mvc;
using SistemaClientes.Api.Models;
using SistemaClientes.Api.Resources;
using SistemaClientes.Data.Entities;
using SistemaClientes.Data.Repositories;
using SistemaClientes.Models;

namespace SistemaClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        [HttpPost]
        public IActionResult Post(ClientesPostModel model)
        {
            try
            {
                var cliente = new Cliente();

                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Cpf = model.Cpf;
                cliente.Telefone = model.Telefone;
                cliente.DataNascimento = model.DataNascimento;

                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                return StatusCode(201, new { mensagem = $"Cliente {cliente.Nome}, cadastrado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }

        }

        [HttpPut]
        public IActionResult Put(ClientesPutModel model)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(model.IdCliente);

                if (cliente != null)
                {
                    cliente.Nome = model.Nome;
                    cliente.Telefone = model.Telefone;
                    cliente.Cpf = model.Cpf;
                    cliente.Email = model.Email;
                    cliente.DataNascimento = model.DataNascimento;

                    clienteRepository.Atualizar(cliente);

                    return StatusCode(201, new { mensagem = $"Cliente {cliente.Nome}, atualizado com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { mensagem = $"Cliente {cliente.Nome}, não encontrado, por favor verifique o ID." });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        [HttpDelete("{idcliente}")]
        public IActionResult Delete(Guid idCliente)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(idCliente);

                if (cliente != null)
                {
                    clienteRepository.Excluir(cliente.IdCliente);

                    return StatusCode(200, new { mensagem = $"Cliente {cliente.Nome}, excluído com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { mensagem = $"Cliente {cliente.Nome}, não encontrado, por favor verifique o ID." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClientesGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<ClientesGetModel>();

                var clienteRepository = new ClienteRepository();
                foreach (var item in clienteRepository.Consultar())
                {
                    var calcularIdade = new CalcularIdade();
                    var model = new ClientesGetModel();

                    model.IdCliente = item.IdCliente;
                    model.Nome = item.Nome;
                    model.Telefone = item.Telefone;
                    model.Email = item.Email;
                    model.Cpf = item.Cpf;
                    model.DataNascimento = item.DataNascimento;
                    model.Idade = calcularIdade.ObterIdade(item.DataNascimento);

                    lista.Add(model);
                }

                return StatusCode(200, lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }

        [HttpGet("{idcliente}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientesGetModel))]
        public IActionResult GetById(Guid idcliente)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(idcliente);

                if (cliente != null)
                {
                    var calcularIdade = new CalcularIdade();
                    var model = new ClientesGetModel();

                    model.IdCliente = cliente.IdCliente;
                    model.Nome = cliente.Nome;
                    model.Telefone = cliente.Telefone;
                    model.Cpf = cliente.Cpf;
                    model.Email = cliente.Email;
                    model.DataNascimento = cliente.DataNascimento;
                    model.Idade = calcularIdade.ObterIdade(cliente.DataNascimento);

                    return StatusCode(200, model);
                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
            return Ok();
        }
    }
}
