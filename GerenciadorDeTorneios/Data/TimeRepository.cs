using Microsoft.Data.SqlClient;
using GerenciadorDeTorneios.Models;

namespace GerenciadorDeTorneios.Data
{
    public class TimeRepository
    {
        // guarda a string de conexão passada pelo App.Config
        private readonly string _connString;

        // construtor que recebe a connection string
        public TimeRepository(string connString)
        {
            _connString = connString;
        }

        // método para buscar todos os times no banco de dados
        public List<Time> GetAll()
        {
            // lista a ser preenchida com os times encontrados no banco
            var lista = new List<Time>();
            // using garante que a conexão será fechada e descartada corretamente
            using (var conn = new SqlConnection(_connString))
            {
                // abre a conexão com o SQL Server
                conn.Open();
                // criando o comando SQL que será enviado ao banco
                var cmd = new SqlCommand("SELECT Id, Nome FROM Time", conn);
                // executa o comando SQL e armazena o resultado em DataReader
                var reader = cmd.ExecuteReader();
                // faz um loop por cada linha retornada na consulta SQL
                while (reader.Read())
                {
                    // para cada linha do banco, criamos um novo objeto Time
                    lista.Add(new Time
                    {
                        // aloca em cada propriedade o valor vindo da coluna 
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1)
                    });
                }
            }
            return lista;
        }

        public int TimeRepositoryAdd(Time times)
        {
            // abrindo a conexão com SQL Server
            using (var conn = new SqlConnection(_connString))
            {
                // abrindo a conexão com SQL Server
                conn.Open();

                // crando o comando para add os times no banco de dados
                var cmd = new SqlCommand(@"
                                        INSERT INTO Time (Nome) 
                                        VALUES (@Nome);
                                        SELECT SCOPE_IDENTITY();", conn);

                // preenchendo os parâmetros com os valores do objeto Jogadores
                cmd.Parameters.AddWithValue("@Nome", times.Nome);

                int novoId = Convert.ToInt32(cmd.ExecuteScalar());
                return novoId;
            }
        }
    }
}