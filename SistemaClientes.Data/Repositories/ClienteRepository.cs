using Dapper;
using SistemaClientes.Data.Configurations;
using SistemaClientes.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes.Data.Repositories
{
    public class ClienteRepository
    {
        public void Inserir(Cliente cliente)
        {
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute("SP_INSERIR_CLIENTE",
                    new
                    {
                        @NOME = cliente.Nome,
                        @CPF = cliente.Cpf,
                        @TELEFONE = cliente.Telefone,
                        @EMAIL = cliente.Email,
                        @DATANASCIMENTO = cliente.DataNascimento
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Atualizar(Cliente cliente)
        {
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute("SP_ALTERAR_CLIENTE",
                    new
                    {
                        @IDCLIENTE = cliente.IdCliente,
                        @NOME = cliente.Nome,
                        @CPF = cliente.Cpf,
                        @TELEFONE = cliente.Telefone,
                        @EMAIL = cliente.Email,
                        @DATANASCIMENTO = cliente.DataNascimento
                    },
                    commandType: CommandType.StoredProcedure);

            }
        }

        public void Excluir(Guid idcliente)
        {
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                connection.Execute("SP_EXCLUIR_CLIENTE",
                    new
                    {
                        @IDCLIENTE = idcliente
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Cliente> Consultar()
        {
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Cliente>("SP_CONSULTAR_CLIENTES",
                        commandType: CommandType.StoredProcedure)
                        .ToList();
            }
        }

        public Cliente? ObterPorId(Guid idCliente)
        {
            using (var connection = new SqlConnection(SqlServerConfiguration.GetConnectionString()))
            {
                return connection.Query<Cliente>("SP_OBTER_CLIENTE",
                            new { @IDCLIENTE = idCliente },
                            commandType: CommandType.StoredProcedure)
                        .FirstOrDefault();
            }
        }
    }
}
