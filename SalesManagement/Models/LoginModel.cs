﻿using SalesManagement.Utils;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SalesManagement.Models
{
    public class LoginModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Formato incorreto!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }

        //Existe um problema de Segurança grave com essa abordagem. (SQL Injection)
        //Estou utilizando apenas como um simples teste.
        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE EMAIL='{Email}' AND SENHA= {Senha}";
            DAL objDAL = new DAL();
            DataTable dataTable = objDAL.RetDataTable(sql);

            if (dataTable.Rows.Count == 1)
            {
                Id = dataTable.Rows[0]["ID"].ToString();
                Nome = dataTable.Rows[0]["NOME"].ToString();
                return true;
            }

            return false;
        }
    }
}