using Financeiro.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace Financeiro.Repository
{
    public class TituloRepository : ITituloRepository
    {
        private IConfiguration _configuration;

        public TituloRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("TituloConnection").Value;
            return connection;
        }

        public int Add(Titulo titulo)
        {

            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Titulos(ValorTotal, ValorJuros, QuantidadeParcelas,DataCompra) VALUES(@ValorTotal, @ValorJuros, @QuantidadeParcelas,@DataCompra);";
                    count = con.Execute(query, titulo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public int Edit(Titulo titulo)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Titulos SET ValorTotal = @ValorTotal, ValorJuros = @ValorJuros, QuantidadeParcelas = @QuantidadeParcelas WHERE TituloId = " + titulo.TituloId;
                    count = con.Execute(query, titulo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public Titulo Get(int id)
        {
            var connectionString = this.GetConnection();
            Titulo titulo = new Titulo();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Titulos WHERE TituloId =" + id;
                    titulo = con.Query<Titulo>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return titulo;
            }
        }

        public List<Titulo> GetTitulo()
        {
            var connectionString = this.GetConnection();
            List<Titulo> titulos = new List<Titulo>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Titulos";
                    titulos = con.Query<Titulo>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return titulos;
            }
        }
    }
}
