using Domain.Layer;
using Services.Layer.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace Services.Layer
{
    public interface IProductService
    {
        List<Producto> GetListProducts(int numberPage, int QuantityPage);
    }

    public class ProductService : IProductService
    {
        private readonly IConnection _connection;

        public ProductService(IConnection connection)
        {
            _connection = connection;
        }

        public List<Producto> GetListProducts(int numberPage, int quantityPage)
        {
            try
            {
                using SqlConnection conn = _connection.Get();
                conn.Open();

                SqlCommand cmd = new SqlCommand("[api].[usp_Productos_Listar]", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@NumberPage", numberPage);
                cmd.Parameters.AddWithValue("@QuantityPatge", quantityPage);

                var dataReader = cmd.ExecuteScalar();
                List<Producto> lista = new List<Producto>();
                if (dataReader != null)
                {
                    string result = dataReader.ToString();
                    lista = JsonSerializer.Deserialize<List<Producto>>(result);
                    lista.ForEach(item =>
                    {
                        item.Presentacion = JsonSerializer.Deserialize<Presentacion>(item.PresentacionStr);
                    });
                }
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
