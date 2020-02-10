using Domain.Dto.Layer;
using Domain.Layer;
using Services.Layer.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;

namespace Services.Layer
{
    public interface IAuthService
    {
        User Login(UserLoginDto userLoginDto);
    }

    public class AuthService : IAuthService
    {
        private readonly IConnection _connection;

        public AuthService(IConnection connection)
        {
            _connection = connection;
        }

        public User Login(UserLoginDto userLoginDto)
        {
            try
            {
                using SqlConnection conn = _connection.Get();
                conn.Open();

                using SqlCommand cmd = new SqlCommand("[api].[usp_Login]", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("username", userLoginDto.Usuario);
                cmd.Parameters.AddWithValue("pass", userLoginDto.Password);

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    string result = dataReader.GetValue(0).ToString();
                    return JsonSerializer.Deserialize<List<User>>(result)[0];
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
