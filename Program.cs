using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Conexion_GastosDB
{
    public class Program
    {
      
        private const string CadenaConexion =
            @"Server=(localdb)\MSSQLLocalDB;" +
            @"Database=GastosDB;" +
            @"Trusted_Connection=True;" +
            @"TrustServerCertificate=True;";

        public static void Main(string[] args)
        {
            List<Gasto> listaGastos = CargarGastosDesdeBD();

            if (listaGastos.Count == 0)
            {
                Console.WriteLine("No hay gastos registrados.");
            }
            else
            {
                Console.WriteLine("GASTOS REGISTRADOS EN LA BASE DE DATOS GastosDB");
                Console.WriteLine($"{"Id",-3} {"Descripcion",-20} Q {"Monto",-8:N2} {"Categoria",-15}");
              

                decimal totalGastado = 0;
                foreach (Gasto g in listaGastos)
                {
                    Console.WriteLine(g);
                    totalGastado += g.Monto;
                }

               
                Console.WriteLine($"TOTAL GASTADO: Q {totalGastado:N2}");
            }
        }

      private static List<Gasto> CargarGastosDesdeBD()
        {
          var gastos = new List<Gasto>();
          string sql = "SELECT Id, Descripcion, Monto, Categoria FROM Gastos";

    using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();

      using (SqlCommand comando = new SqlCommand(sql, conexion))
               {
              
                 using (SqlDataReader lector = comando.ExecuteReader())
                    {

                    while (lector.Read())
                    {

                      gastos.Add(new Gasto
                          {
                            Id = lector.GetInt32(0),
                            Descripcion = lector.GetString(1),
                            Monto = lector.GetDecimal(2),
                            Categoria = lector.GetString(3)
                            });
                        }
                    }
                }
            }

            return gastos;
        }
    }
}