using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControledeEstoque.Web.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string Login, string senha)
        {
            bool ret = false;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EstoqueWeb;Integrated Security=True";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("SELECT count(*) from usuarios where login = '{0}' and senha = '{1}';", Login, senha);
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
                conexao.Close();
            }
            return ret;
        }
    }
}